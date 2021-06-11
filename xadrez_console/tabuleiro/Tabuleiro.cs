

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
        public Peca Peca(Posicao pos)
        {
            return pecas[pos.Line,pos.Column];
        }
        public void ColocarPeca(Peca p, Posicao pos)
        {
            if (ExistePeca(pos)) { throw new TabuleiroException("Essa posição ja existe uma peça !"); }
            // marca a posicao no tabuleiro
            pecas[pos.Line, pos.Column] = p;
            // marca a posicao na peça
            p.Posicao = pos;
        }
        public bool PosicaoValida(Posicao pos)
        {
            if(pos.Line<0 || pos.Line>=Lines || pos.Column<0 || pos.Column >= Colunms) { return true; }
            return false;
         
        }
        public void ValidarPosicao(Posicao pos)
        {
            if(PosicaoValida(pos)) { throw new TabuleiroException("Posicação Invalida !"); }
        }

        public bool ExistePeca(Posicao pos)
        {
            ValidarPosicao(pos);
            return Peca(pos) != null;
        }

    }
}
