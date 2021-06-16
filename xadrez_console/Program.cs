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
                    try
                    {
                        Console.Clear();
                        Tela.ImprimirPartida(partida);

                        Console.Write("\n\nOrigem:");
                        Posicao origin = Tela.LerPosicaoXadrez().PosicaodeMatriz();
                        partida.ValidarPosicaoOrigem(origin);
                        bool[,] movimentosPossiveis = partida.Tab.Peca(origin).movimentosPossiveis();

                        Console.Clear();

                        Tela.ImprimirTabuleiro(partida.Tab, movimentosPossiveis);
                        Console.WriteLine();
                        Console.Write("Destiny:");
                        Posicao destiny = Tela.LerPosicaoXadrez().PosicaodeMatriz();
                        partida.ValidarPosicaoDestino(origin, destiny);

                        partida.RealizaJogada(origin, destiny);
                    }

                    catch (TabuleiroException e)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(e.Message);
                        Console.ResetColor();
                        Console.ReadKey();
                    }
                    catch (Exception e)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine(e.Message);
                        Console.ResetColor();
                        Console.ReadKey();
                    }



                }



                Console.Clear();
                Tela.ImprimirPartida(partida);
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();




        }
    }
}




