using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
