using tabuleiro;

namespace xadrez {
    class PositionChess {

        public char coluna{get;set;} 
        public int linha {get;set;}

        public PositionChess(char coluna, int linha) {
            this.coluna = coluna;
            this.linha = linha;
        }

        public Position toPosition() { //convertendo a posição do array do c# para o tabuleiro de xadrez - (0, 0) = (a, 1)
            return new Position(8 - linha, coluna - 'a');
        }

        public override string ToString()
        {
            return "" + coluna + linha;
        }
    }
}
