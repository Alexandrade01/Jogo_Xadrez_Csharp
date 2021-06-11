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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(8 - x + " ");
                Console.ResetColor();
                for (int y = 0; y < tab.Colunms; y++)
                {
                    if (tab.Peca(x, y) == null) { Console.Write("- "); }

                    else if (tab.Peca(x, y).Cor == Cor.Preta)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(tab.Peca(x, y) + " ");
                        Console.ResetColor();
                    }
                    else
                    {

                        Console.Write(tab.Peca(x, y) + " ");

                    }
                  
                }
                Console.WriteLine();
            }
            
            Console.ForegroundColor = ConsoleColor.Red;
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

    }
}

