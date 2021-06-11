using System;
using tabuleiro;
using xadrez_console;


namespace pecas_do_Xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tab { get; private set; }
        private int turno;
        private Cor jogadorAtual;
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
