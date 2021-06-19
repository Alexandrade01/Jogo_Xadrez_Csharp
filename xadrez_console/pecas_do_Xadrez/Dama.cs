using tabuleiro;
namespace pecas_do_Xadrez
{
    class Dama : Peca
    {
        public Dama(Cor cor, Tabuleiro tab) : base(cor, tab)
        {
        }

        public override string ToString()
        {
            return "D";
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

            // esquerda
            pos.DefinirValores(pos.Line, pos.Column - 1);
            while (Tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Line, pos.Column - 1);
            }

            // direita
            pos.DefinirValores(Posicao.Line, Posicao.Column + 1);
            while (Tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Line, pos.Column + 1);
            }

            // acima
            pos.DefinirValores(Posicao.Line - 1, Posicao.Column);
            while (Tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Line - 1, pos.Column);
            }

            // abaixo
            pos.DefinirValores(Posicao.Line + 1, Posicao.Column);
            while (Tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Line + 1, pos.Column);
            }

            // NO
            pos.DefinirValores(Posicao.Line - 1, Posicao.Column - 1);
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
            pos.DefinirValores(Posicao.Line - 1, Posicao.Column + 1);
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
            pos.DefinirValores(Posicao.Line + 1, Posicao.Column + 1);
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
            pos.DefinirValores(Posicao.Line + 1, Posicao.Column - 1);
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
