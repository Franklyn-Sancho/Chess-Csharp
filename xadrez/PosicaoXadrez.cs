using tabuleiro;

namespace xadrez {
    class PosicaoXadrez {

        public char coluna{get;set;} 
        public int linha {get;set;}

        public PosicaoXadrez(char coluna, int linha) {
            this.coluna = coluna;
            this.linha = linha;
        }

        public Posicao toPosition() { //convertendo a posição do array do c# para o tabuleiro de xadrez - (0, 0) = (a, 1)
            return new Posicao(8 - linha, coluna - 'a');
        }

        public override string ToString()
        {
            return "" + coluna + linha;
        }
    }
}
