

namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdeMovimentos { get; protected set; }
        public Tabuleiro Tab { get; protected set; }
        public Peca(Cor cor, Tabuleiro tab)
        {
            this.Posicao = null;
            this.Cor = cor;
            this.QtdeMovimentos = 0;
            this.Tab = tab;
        }

        public void IncrementarQtdeMovimentos()
        {
            QtdeMovimentos++;
        }
        public abstract bool[,] movimentosPossiveis();
        public bool ExisteMovimentosPossiveis()
        {
            bool[,] matrix = movimentosPossiveis();
            foreach(var elemento in matrix)
            {
                if (elemento)
                {
                    return true;
                }

            }
            return false;
        }
        public bool podeMoverPara(Posicao pos)
        {
            return movimentosPossiveis()[pos.Line, pos.Column];
        }

    }
}
