using System;
using tabuleiro;
using xadrez;

namespace xadrez_controle {
    class Program {
        static void Main(string[] args) {
            
            try {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while(!partida.terminada) {
                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Position origem = Tela.lerPosicaoXadrez().toPosition();

                    bool[,] posicoesPossiveis = partida.tab.piece(origem).movimentosPossiveis();

                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                    Console.Write("Destino: ");
                    Position destino = Tela.lerPosicaoXadrez().toPosition();

                    partida.ExecutaMovimento(origem, destino);
                    
                }

                
            } catch(TabuleiroException e) {
                Console.WriteLine(e.message);
            }
            Console.ReadLine();
        }
    }
}