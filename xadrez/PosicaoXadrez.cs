using tabuleiro;

namespace xadrez {
    class PosicaoXadrez {

        //A coluna num tabuleiro de xadrez recebe o valor de letras: a1, c4 e etc
        public char coluna{get;set;} 
        //Os atributos são privados e aceitam os métodos get e set. 
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
