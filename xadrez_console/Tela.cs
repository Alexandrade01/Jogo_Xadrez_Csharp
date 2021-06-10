using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrez_console.tabuleiro;

namespace xadrez_console
{
    class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            for(int x = 0; x < tab.Lines; x++)
            {
                for(int y = 0; y < tab.Colunms; y++)
                {
                    if (tab.peca(x, y) == null) { Console.Write("- "); }
                    else { Console.WriteLine(tab.peca(x,y) + " "); }
                }
                Console.WriteLine();
            }
        }
    }
}
