

namespace xadrez_console.tabuleiro
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

        public Peca peca(int line, int colunm)
        {
            return pecas[line, colunm];
        }
      
    }
}
