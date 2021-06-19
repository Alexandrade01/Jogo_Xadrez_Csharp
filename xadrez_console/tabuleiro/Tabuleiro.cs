

namespace tabuleiro
{
    class Tabuleiro
    {
        public int Lines { get; set; }
        public int Colunms { get; set; }
        private Peca[,] Pecas;

        public Tabuleiro(int lines, int colunms)
        {
            Lines = lines;
            Colunms = colunms;
            Pecas = new Peca[lines, colunms];
        }

        public Peca Peca(int line, int colunm) 
        {
            return Pecas[line, colunm];
        }
        public Peca Peca(Posicao pos)
        {
            return Pecas[pos.Line,pos.Column];
        }
        public void ColocarPeca(Peca p, Posicao pos)
        {
            if (ExistePeca(pos)) { throw new TabuleiroException("Essa posição ja existe uma peça !"); }
            // marca a posicao no tabuleiro
            Pecas[pos.Line, pos.Column] = p;
            // marca a posicao na peça
            p.Posicao = pos;
        }
        public Peca RetirarPeca(Posicao pos)
        {
            if(Peca(pos)== null) { return null; }
            Peca aux = Peca(pos);
            aux.Posicao = null;
            Pecas[pos.Line, pos.Column] = null;
            return aux;
        }
        public bool PosicaoValida(Posicao pos)
        {
            if(pos.Line<0 || pos.Line>=Lines || pos.Column<0 || pos.Column >= Colunms) { return false; }
            return true;
         
        }
        public void ValidarPosicao(Posicao pos)
        {
            if(!PosicaoValida(pos)) { throw new TabuleiroException("Posição Invalida !"); }
        }

        public bool ExistePeca(Posicao pos)
        {
            ValidarPosicao(pos);
            return Peca(pos) != null;
        }

    }
}
