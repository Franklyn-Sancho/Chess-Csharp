using System;
using tabuleiro;

namespace xadrez_controle {
    class Program {
        static void MAIN(string[] args) {
            Position P;

            P = new Position(3, 4);

            Console.WriteLine("Position: " + P);
            Console.ReadLine();
        }
    }
}