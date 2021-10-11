using tabuleiro;

namespace xadrez_console {
    class Tela {
        public static void imprimirTabuleiro(Tabuleiro tab) {
            for(int i = 0; i < tab.linhas; i++) {
                for (int j = 0; j < tab.colunas; j++) {
                    if (tab_piece(i, j) == null) {
                        Console.Write("- ");
                    } else {
                         xadrez_console.Write(tab.piece(i,j) + " ");
                    }
                   
                }
                Console.WriteLine();
            }
        }
    }
}