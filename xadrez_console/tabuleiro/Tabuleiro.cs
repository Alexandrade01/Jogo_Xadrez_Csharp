

namespace tabuleiro
{
    class Tabuleiro
    {
        public int Lines { get; set; }
        public int Colunms { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int lines, int colunms)
        {
            Lines = lines;
            Colunms = colunms;
            pecas = new Peca[lines, colunms];
        }

        public Peca Peca(int line, int colunm)
        {
            return pecas[line, colunm];
        }
        public void colocarPeca(Peca p, Posicao pos)
        { // marca a posicao no tabuleiro
            pecas[pos.Line, pos.Column] = p;
            // marca a posicao na peça
            p.Posicao = pos;
        }

    }
}
