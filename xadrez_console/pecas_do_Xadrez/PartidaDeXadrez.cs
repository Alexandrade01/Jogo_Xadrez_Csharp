using System;
using tabuleiro;
using xadrez_console;
using System.Collections.Generic;


namespace pecas_do_Xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool finalizarjogada { get; private set; }
        private HashSet<Peca> HashdePecas;
        private HashSet<Peca> HashdePecasCapturadas;
        public bool xeque { get; private set; }





        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            finalizarjogada = false;
            xeque = false;
            HashdePecas = new HashSet<Peca>();
            HashdePecasCapturadas = new HashSet<Peca>();
            colocarPecas();

        }


        public Peca ExecutaroMovimento(Posicao origem, Posicao destino)
        {// retira peça do lugar original
            Peca p = Tab.RetirarPeca(origem);
            // aumenta os movimentos
            p.IncrementarQtdeMovimentos();
            // retira peça do movimento final
            Peca pecaCapturada = Tab.RetirarPeca(destino);
            // insere a peça do movimento no destino
            Tab.ColocarPeca(p, destino);
            if (pecaCapturada != null) { HashdePecasCapturadas.Add(pecaCapturada); }
            return pecaCapturada;
        }

        public void DesfazoMovimento(Posicao origem, Posicao destino, Peca pecacapturada)
        {
            Peca p = Tab.RetirarPeca(destino);
            p.DescrescerQtdeMovimentos();
            if (pecacapturada != null)
            {
                Tab.ColocarPeca(pecacapturada, destino);
                HashdePecasCapturadas.Remove(pecacapturada);

            }
            Tab.ColocarPeca(p, origem);

        }
        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = ExecutaroMovimento(origem, destino);
            if (Xeque(jogadorAtual))
            {
                DesfazoMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em cheque!");
            }
            if (Xeque(Adversaria(jogadorAtual))) { xeque = true; }
            else { xeque = false; }

            if (Xeque(Adversaria(jogadorAtual)))
            {
                finalizarjogada = true;
            }
            else
            {
                turno++;
                MudarJogador();
            }


        }
        /// <summary>
        /// Validação de movimentos iniciais
        /// </summary>
        /// <param name="pos"></param>
        public void ValidarPosicaoOrigem(Posicao pos)
        {// se for selecionado um espaço vazio retorna exceção
            if (Tab.Peca(pos) == null) { throw new TabuleiroException("Não existe peça na posicão escolhida !"); }
            // se a peça escolhida for do seu oponente retorna exceção
            if (jogadorAtual != Tab.Peca(pos).Cor) { throw new TabuleiroException("A peça de origem escolhida não é sua !"); }
            // checagem da matriz booleana para verificação se existe movimentos possiveis
            if (!Tab.Peca(pos).ExisteMovimentosPossiveis()) { throw new TabuleiroException("Não existe movimentos possiveis para a peça escolhida !"); }

        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!Tab.Peca(origem).podeMoverPara(destino)) { throw new TabuleiroException("Não possivel fazer essa movimentação !"); }
        }
        public void MudarJogador()
        {
            if (jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else jogadorAtual = Cor.Branca;
        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in HashdePecasCapturadas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> PecasEMJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in HashdePecas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            // lista com pecas de jogo exceto as peças capturadas dessa determinada cor
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        private Cor Adversaria(Cor cor)
        {
            if (cor == Cor.Branca) { return Cor.Preta; }
            else return Cor.Branca;
        }
        /// <summary>
        /// Procurar o rei para aplicar o Xeque 
        /// </summary>
        /// <param name="cor"></param>
        /// <returns></returns>
        private Peca ProcuraRei(Cor cor)
        {
            foreach (Peca x in PecasEMJogo(cor))
            {
                if (x is Rei) { return x; }
            }
            return null;
        }

        public bool Xeque(Cor cor)
        {
            Peca R = ProcuraRei(cor);
            if (R == null) { throw new TabuleiroException("Não tem Rei da cor " + cor + " no tabuleiro"); }
            foreach (Peca x in PecasEMJogo(Adversaria(cor)))
            {// cria a matriz com os movimentos possiveis novamente
                bool[,] mat = x.movimentosPossiveis();
                //se a coordenada do rei for true ele retorna
                if (mat[R.Posicao.Line, R.Posicao.Column]) { return true; }

            }
            return false;
        }

        public bool XequeMate(Cor cor)
        {
            if (!Xeque(cor)) { return false; }
            foreach (Peca z in PecasEMJogo(cor))
            {
                bool[,] matrix = z.movimentosPossiveis();
                for (int x = 0; x < Tab.Lines; x++)
                {
                    for (int y = 0; y < Tab.Colunms; y++)
                    {
                        if (matrix[x, y])
                        {
                            Posicao origem = z.Posicao;
                            Posicao destino = new Posicao(x, y);
                            Peca pecaCapturada = ExecutaroMovimento(origem, destino);
                            bool testeXeque = Xeque(cor);
                            DesfazoMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque) { return false; }
                        }
                    }
                }

            }
            return true;
        }
        public void ColocarNovaPeca(char colunm, int line, Peca peca)
        {// ira adicionar itens em  uma lista haskset 
            Tab.ColocarPeca(peca, new PosicaoXadrez(colunm, line).PosicaodeMatriz());
            HashdePecas.Add(peca);
        }
        public void colocarPecas()
        {
            /* ColocarNovaPeca('c', 1, new Torre(Cor.Branca, Tab));
             ColocarNovaPeca('c', 2, new Torre(Cor.Branca, Tab));
             ColocarNovaPeca('d', 1, new Rei(Cor.Branca, Tab));
             ColocarNovaPeca('d', 2, new Torre(Cor.Branca, Tab));
             ColocarNovaPeca('e', 1, new Torre(Cor.Branca, Tab));
             ColocarNovaPeca('e', 2, new Torre(Cor.Branca, Tab));

             ColocarNovaPeca('c', 8, new Torre(Cor.Preta, Tab));
             ColocarNovaPeca('c', 7, new Torre(Cor.Preta, Tab));
             ColocarNovaPeca('d', 8, new Rei(Cor.Preta, Tab));
             ColocarNovaPeca('d', 7, new Torre(Cor.Preta, Tab));
             ColocarNovaPeca('e', 8, new Torre(Cor.Preta, Tab));
             ColocarNovaPeca('e', 7, new Torre(Cor.Preta, Tab));*/

            ColocarNovaPeca('d', 1, new Rei(Cor.Branca, Tab));
            ColocarNovaPeca('c', 1, new Torre(Cor.Branca, Tab));
            ColocarNovaPeca('h', 7, new Torre(Cor.Branca, Tab));


            ColocarNovaPeca('a', 8, new Rei(Cor.Preta, Tab));
            ColocarNovaPeca('b', 8, new Torre(Cor.Preta, Tab));







        }
    }
}
