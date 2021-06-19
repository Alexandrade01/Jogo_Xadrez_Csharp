using tabuleiro;

namespace pecas_do_Xadrez
{
    class Torre : Peca
    {
        public Torre(Cor cor, Tabuleiro tab) : base(cor, tab)
        {
        }


        private bool PodeMover(Posicao posicao)
        {
            Peca p = Tab.Peca(posicao);
            return p == null || p.Cor != Cor;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Lines, Tab.Colunms];
            Posicao posicao = new Posicao(0, 0);
            #region Acima
            posicao.DefinirValores(Posicao.Line - 1, Posicao.Column);
            while (Tab.PosicaoValida(posicao) && PodeMover((posicao)))
            {
                mat[posicao.Line, posicao.Column] = true;
                if(Tab.Peca(posicao) != null && Tab.Peca(posicao).Cor != Cor) { break; }
                posicao.Line = posicao.Line - 1;

            }
            #endregion

            #region Abaixo
            posicao.DefinirValores(Posicao.Line + 1, Posicao.Column);
            while (Tab.PosicaoValida(posicao) && PodeMover((posicao)))
            {
                mat[posicao.Line, posicao.Column] = true;
                if (Tab.Peca(posicao) != null && Tab.Peca(posicao).Cor != Cor) { break; }
                posicao.Line = posicao.Line + 1;

            }
            #endregion
            #region Direita
            posicao.DefinirValores(Posicao.Line, Posicao.Column+1);
            while (Tab.PosicaoValida(posicao) && PodeMover((posicao)))
            {
                mat[posicao.Line, posicao.Column] = true;
                if (Tab.Peca(posicao) != null && Tab.Peca(posicao).Cor != Cor) { break; }
                posicao.Column = posicao.Column + 1;

            }
            #endregion

            #region Esquerda
            posicao.DefinirValores(Posicao.Line, Posicao.Column-1);
            while (Tab.PosicaoValida(posicao) && PodeMover((posicao)))
            {
                mat[posicao.Line, posicao.Column] = true;
                if (Tab.Peca(posicao) != null && Tab.Peca(posicao).Cor != Cor) { break; }
                posicao.Column = posicao.Column - 1;

            }
            #endregion

            return mat;
        }
        public override string ToString()
        {
            return "T";
        }
    }
}
