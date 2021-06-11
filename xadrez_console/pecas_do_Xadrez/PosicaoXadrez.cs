using System;
using tabuleiro;

namespace pecas_do_Xadrez
{
    class PosicaoXadrez
    {
        public char Colunm { get; set; }
        public int Line { get; set; }
        public PosicaoXadrez(char colunm, int line)
        {
            this.Colunm = colunm;
            this.Line = line;
        }

        /// <summary>
        /// Indice interno para a localização do tabuleiro
        /// </summary>
        /// <returns></returns>
        public Posicao toPosicao()
        {// pelo tabueleiro ser formado de cima para baixo, o numero 8 - a posicao desejada e achamos o indice no tabuleiro
            // na coluna sera a diferença entre os caracteres, a - a = 0, b-a = 1, c-a =2
            //serve para numerar o tabuleiro, ja que esse vai de A-H e 0-7
            return new Posicao(8 - Line, Colunm - 'a');
        }
        public override string ToString()
        {
            return "" + Colunm + Line;
        }




    }
}
