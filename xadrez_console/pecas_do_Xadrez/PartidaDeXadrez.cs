using System;
using tabuleiro;
using xadrez_console;


namespace pecas_do_Xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool finalizarjogada { get; private set; }



        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            finalizarjogada = false;
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
        public void colocarPecas()
        {
            Tab.ColocarPeca(new Torre(Cor.Branca, Tab), new PosicaoXadrez('c', 1).PosicaodeMatriz());
            Tab.ColocarPeca(new Torre(Cor.Branca, Tab), new PosicaoXadrez('c', 2).PosicaodeMatriz());
            Tab.ColocarPeca(new Torre(Cor.Branca, Tab), new PosicaoXadrez('d', 2).PosicaodeMatriz());
            Tab.ColocarPeca(new Torre(Cor.Branca, Tab), new PosicaoXadrez('e', 2).PosicaodeMatriz());
            Tab.ColocarPeca(new Torre(Cor.Branca, Tab), new PosicaoXadrez('e', 1).PosicaodeMatriz());
            Tab.ColocarPeca(new Rei(Cor.Branca, Tab), new PosicaoXadrez('d', 1).PosicaodeMatriz());

            Tab.ColocarPeca(new Torre(Cor.Preta, Tab), new PosicaoXadrez('c', 8).PosicaodeMatriz());
            Tab.ColocarPeca(new Torre(Cor.Preta, Tab), new PosicaoXadrez('c', 7).PosicaodeMatriz());
            Tab.ColocarPeca(new Torre(Cor.Preta, Tab), new PosicaoXadrez('d', 7).PosicaodeMatriz());
            Tab.ColocarPeca(new Torre(Cor.Preta, Tab), new PosicaoXadrez('e', 7).PosicaodeMatriz());
            Tab.ColocarPeca(new Torre(Cor.Preta, Tab), new PosicaoXadrez('e', 8).PosicaodeMatriz());
            Tab.ColocarPeca(new Torre(Cor.Preta, Tab), new PosicaoXadrez('d', 8).PosicaodeMatriz());


        }
    }
}
