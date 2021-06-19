using tabuleiro;

namespace pecas_do_Xadrez
{
    class Cavalo:Peca
    {

        public Cavalo(Cor Cor, Tabuleiro Tab ) : base(Cor, Tab)
        {
        }

        public override string ToString()
        {
            return "C";
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p == null || p.Cor != Cor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Lines, Tab.Colunms];

            Posicao pos = new Posicao(0, 0);

            pos.DefinirValores(pos.Line - 1, pos.Column - 2);
            if (Tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.DefinirValores(pos.Line - 2, pos.Column - 1);
            if (Tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.DefinirValores(pos.Line - 2, pos.Column + 1);
            if (Tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.DefinirValores(pos.Line - 1, pos.Column + 2);
            if (Tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.DefinirValores(pos.Line + 1, pos.Column + 2);
            if (Tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.DefinirValores(pos.Line + 2, pos.Column + 1);
            if (Tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.DefinirValores(pos.Line + 2, pos.Column - 1);
            if (Tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.DefinirValores(pos.Line + 1, pos.Column - 2);
            if (Tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            return mat;
        }
    }
}
