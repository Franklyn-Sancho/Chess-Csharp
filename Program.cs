using System;
using tabuleiro;
using xadrez;

namespace xadrez_controle
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                try
                {
                    while (!partida.terminada)
                    {
                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab);
                        Console.WriteLine();
                        Console.WriteLine("turno: " + partida.turno);
                        Console.WriteLine("aguardando jogada: " + partida.jogadorAtual);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Position origem = Tela.lerPosicaoXadrez().toPosition();
                        partida.validarPosicaoDeOrigem(origem);

                        bool[,] posicoesPossiveis = partida.tab.pecas(origem).movimentosPossiveis();

                        Console.Clear();
                        TypeLoadException.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Position destino = Tela.lerPosicaoXadrez().toPosition();

                    }
                }
                catch (TabuleiroException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }



            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.message);
            }
            Console.ReadLine();
        }
    }
}