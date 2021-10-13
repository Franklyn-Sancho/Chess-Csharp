namespace tabuleiro {
    //Classe genérica das peças
    class Piece {

        public Position position {get; set;} //vai ter uma posição
        public Color color {get; protected set;} //uma cor

        public int qtMoviments {get;protected set;} //quantidade de movimentos
        public Tabuleiro tab {get; protected set;} //E estará num tabuleiro

        public Piece(Tabuleiro tabuleiro, Color color) { //Construtor das peças
            this.position = null;
            this.tab = tab;
            this.color = color;
            this.qtMoviments = 0;
        }

        public void incrementMoviment() {
            qtMoviments++;
        }

        //esse método verifica se há movimentos possíveis, caso não haja, dará erro
        public bool existeMovimentosPossiveis() {
            bool[,] mat = movimentosPossiveis();
            for(int i=0; i < tab.linhas; i++) {
                for(int j=0; j < tab.colunas; j++) {
                    if(mat[i, j]) {
                        return true;
                    }
                }
            }
            return false;
        }

        /*
            A abtração acontece porque essa classe é genérica. Porém, como sabemos, um jogo 
            de xadrez tem mais de um tipo de peça e cada uma com sua particularidade e movimentos possíveis. 
            Nesta classe só teremos métodos que funcionam para todas as peças. Por exemplo: Todas as peças
            se movimentam, tem cor e uma posição, então podemos implementar aqui. Já a TORRE, diferente do BISPO, 
            só se movimenta na vertical e horizontal. Então vamos implementar esse método na classe "TORRE" (que 
            é uma herança da classe peça).
        */
        public abstract bool[,] movimentosPossiveis() { //classe abstrata

        }
    }
}