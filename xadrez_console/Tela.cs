using System;
using System.Threading.Tasks;
using tabuleiro;
using pecas_do_Xadrez;

namespace xadrez_console
{
    class Tela
    {
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
        public static void ImprimirTabuleiro(Tabuleiro tab,bool[,] possiveisMovimentos)
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




                   


