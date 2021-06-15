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



        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            finalizarjogada = false;
            HashdePecas = new HashSet<Peca>();
            HashdePecasCapturadas = new HashSet<Peca>();
            colocarPecas();

        }


        public void ExecutaroMovimento(Posicao origem, Posicao destino)
        {// retira peça do lugar original
            Peca p = Tab.RetirarPeca(origem);
            // aumenta os movimentos
            p.IncrementarQtdeMovimentos();
            // retira peça do movimento final
            Peca pecaCapturada = Tab.RetirarPeca(destino);
            // insere a peça do movimento no destino
            Tab.ColocarPeca(p, destino);
            if (pecaCapturada != null) { HashdePecasCapturadas.Add(pecaCapturada); }
        }
        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaroMovimento(origem, destino);
            turno++;
            MudarJogador();

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
            foreach(Peca x in HashdePecasCapturadas)
            {
                if(x.Cor == cor)
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
        public void ColocarNovaPeca(char colunm, int line, Peca peca)
        {// ira adicionar itens em  uma lista haskset 
            Tab.ColocarPeca(peca, new PosicaoXadrez(colunm, line).PosicaodeMatriz());
            HashdePecas.Add(peca);
        }
        public void colocarPecas()
        {
            ColocarNovaPeca('c', 1, new Torre(Cor.Branca, Tab));
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
            ColocarNovaPeca('e', 7, new Torre(Cor.Preta, Tab));





        }
    }
}
