using tabuleiro;

namespace xadrez_console
{
    //inicio da classe tela
    class Tela
    {   
        //Função que constrói o tabuleiro na linha de comando
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (tab_piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        imprimirPeca(tab.piece(i, j));
                        Console.Write(" ");
                    }

                }
                Console.WriteLine();
            }
            //As colunas do tabuleiro são letras de A até H
            Console.WriteLine("  a b c d e f g h");
        }

        //  função responsável por imprimir as peças 
        public static void imprimirPeca(Piece piece) {
            if (piece.color == Color.Branca) {
                Console.Write(piece);
            } else {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }
    }
}