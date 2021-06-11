using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;
using pecas_do_Xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {

            /*PosicaoXadrez posteste = new PosicaoXadrez('b', 3);
            Console.WriteLine(posteste);
            Console.WriteLine(posteste.toPosicao());*/
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();
                while (!partida.finalizarjogada)
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tab);

                    Console.WriteLine("\n\nOrigem:");
                    Posicao origin = Tela.LerPosicaoXadrez().PosicaodeMatriz();
                    Console.WriteLine("Destiny:");
                    Posicao destiny = Tela.LerPosicaoXadrez().PosicaodeMatriz();
                    partida.ExecutaroMovimento(origin, destiny);
                }
               
            }
            catch(TabuleiroException e)
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
            catch(Exception e)
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }

        }
    }
}


            
            
