using tabuleiro;

namespace pecas_do_Xadrez
{
    class Bispo : Peca
    {
        public Bispo(Cor cor, Tabuleiro Tab) : base(cor, Tab)
        {
        }

        public override string ToString()
        {
            return "B";
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

            // NO
            pos.DefinirValores(pos.Line - 1, pos.Column - 1);
            while (Tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Line - 1, pos.Column - 1);
            }

            // NE
            pos.DefinirValores(pos.Line - 1, pos.Column + 1);
            while (Tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Line - 1, pos.Column + 1);
            }

            // SE
            pos.DefinirValores(pos.Line + 1, pos.Column + 1);
            while (Tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Line + 1, pos.Column + 1);
            }

            // SO
            pos.DefinirValores(pos.Line + 1, pos.Column - 1);
            while (Tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Line + 1, pos.Column - 1);
            }

            return mat;
        }
    }
}
