using System;
using System.Threading.Tasks;
using tabuleiro;
using pecas_do_Xadrez;
using System.Collections.Generic;

namespace xadrez_console
{
    class Tela
    {
        public static void ImprimirPartida(PartidaDeXadrez partida)
        {
            ImprimirTabuleiro(partida.Tab);

            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine("Turno: " + partida.turno);
            Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);
        }

        public static void ImprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças Capturadas: ");
            
            Console.Write("Brancas : ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Pretas : ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
            Console.ResetColor();
        }


        public static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("*");
            foreach (var x in conjunto) { Console.Write(x + " "); }
            Console.Write("* \n");
        }
        public static void ImprimirTabuleiro(Tabuleiro tab)
        {

            for (int x = 0; x < tab.Lines; x++)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(8 - x + " ");
                Console.ResetColor();

                for (int y = 0; y < tab.Colunms; y++)
                {
                    ImprimirPeca(tab.Peca(x, y));
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("  a b c d e f g h ");
            Console.ResetColor();


        }
        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] possiveisMovimentos)
        {


            for (int x = 0; x < tab.Lines; x++)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(8 - x + " ");
                Console.ResetColor();

                for (int y = 0; y < tab.Colunms; y++)
                {
                    if (possiveisMovimentos[x, y]) { Console.BackgroundColor = ConsoleColor.DarkGray; }
                    else { Console.ResetColor(); }
                    ImprimirPeca(tab.Peca(x, y));
                    Console.ResetColor();
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("  a b c d e f g h ");
            Console.ResetColor();
        }
        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string cardinal = Console.ReadLine();
            char line = cardinal[0];
            int colunm = int.Parse(cardinal[1].ToString());
            return new PosicaoXadrez(line, colunm);
        }

        public static void ImprimirPeca(Peca peca)
        {

            if (peca == null) { Console.Write("- "); }
            else
            {
                if (peca.Cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor fundoNormal = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(peca);
                    Console.ForegroundColor = fundoNormal;
                }
                Console.Write(" ");
            }

        }

    }
}







