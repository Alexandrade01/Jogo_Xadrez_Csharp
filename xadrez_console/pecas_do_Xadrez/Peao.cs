using tabuleiro;

namespace pecas_do_Xadrez
{
    class Peao:Peca
    {
        private PartidaDeXadrez partida;

        public Peao( Cor cor, Tabuleiro Tab, PartidaDeXadrez partida) : base(cor, Tab)
        {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool ExisteInimigo(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p != null && p.Cor != Cor;
        }

        private bool Livre(Posicao pos)
        {
            return Tab.Peca(pos) == null;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Lines, Tab.Colunms];

            Posicao pos = new Posicao(0, 0);

            if (Cor == Cor.Branca)
            {
                pos.DefinirValores(pos.Line - 1, pos.Column);
                if (Tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.DefinirValores(pos.Line - 2, pos.Column);
                Posicao p2 = new Posicao(pos.Line - 1, pos.Column);
                if (Tab.PosicaoValida(p2) && Livre(p2) && Tab.PosicaoValida(pos) && Livre(pos) && QtdeMovimentos == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.DefinirValores(pos.Line - 1, pos.Column - 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.DefinirValores(pos.Line - 1, pos.Column + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
            }
            else
            {
                pos.DefinirValores(pos.Line + 1, pos.Column);
                if (Tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.DefinirValores(pos.Line + 2, pos.Column);
                Posicao p2 = new Posicao(pos.Line + 1, pos.Column);
                if (Tab.PosicaoValida(p2) && Livre(p2) && Tab.PosicaoValida(pos) && Livre(pos) && QtdeMovimentos == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.DefinirValores(pos.Line + 1, pos.Column - 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.DefinirValores(pos.Line + 1, pos.Column + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

              
            }

            return mat;
        }
    }
}
