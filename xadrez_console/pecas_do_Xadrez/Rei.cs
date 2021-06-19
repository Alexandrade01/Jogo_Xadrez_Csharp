using tabuleiro;

namespace pecas_do_Xadrez
{
    class Rei : Peca
    {
        public Rei(Cor cor, Tabuleiro tab) : base(cor, tab)
        {
        }
        /// <summary>
        /// Verifica se a posicao esta vazia e se nao tem outra peça do jogador
        /// </summary>
        /// <param name="posicao"></param>
        /// <returns></returns>
        private bool PodeMover(Posicao posicao)
        {// retorna a posicao respectiva do objeto da classe Posicao
            Peca p = Tab.Peca(posicao);
            return (p == null || p.Cor != Cor);
        }


        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Lines, Tab.Colunms];
            Posicao posicao = new Posicao(0, 0);


            // move up
            posicao.DefinirValores(Posicao.Line - 1, Posicao.Column);
            if (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Line, posicao.Column] = true;
            }
            // ne
            posicao.DefinirValores(Posicao.Line - 1, Posicao.Column+1);
            if (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Line, posicao.Column] = true;
            }
            // right
            posicao.DefinirValores(Posicao.Line, Posicao.Column + 1);
            if (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Line, posicao.Column] = true;
            }
            // se
            posicao.DefinirValores(Posicao.Line+1, Posicao.Column + 1);
            if (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Line, posicao.Column] = true;
            }
            // move down
            posicao.DefinirValores(Posicao.Line + 1, Posicao.Column);
            if (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Line, posicao.Column] = true;
            }
            // so
            posicao.DefinirValores(Posicao.Line+1, Posicao.Column - 1);
            if (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Line, posicao.Column] = true;
            }
            // esquerda
            posicao.DefinirValores(Posicao.Line , Posicao.Column - 1);
            if (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Line, posicao.Column] = true;
            }
            // no
            posicao.DefinirValores(Posicao.Line - 1, Posicao.Column - 1);
            if (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Line, posicao.Column] = true;
            }
            return mat;









        }



        public override string ToString()
        {
            return "R";
        }
    }
}
