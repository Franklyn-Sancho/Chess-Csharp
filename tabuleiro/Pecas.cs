namespace tabuleiro {
    //Classe genérica das peças
    class Pecas {

        public Posicao posicao {get; set;} //vai ter uma posição
        public Cor cor {get; protected set;} //uma cor

        public int qtMovimentos {get;protected set;} //quantidade de movimentos
        public Tabuleiro tab {get; protected set;} //E estará num tabuleiro

        public Pecas(Tabuleiro tabuleiro, Cor cor) { //Construtor das peças
            this.posicao = null;
            this.tab = tab;
            this.cor = cor;
            this.qtMovimentos = 0;
        }

        public void incrementarMovimentos() {
            qtMovimentos++;
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

            class peças ->
            
            A abtração acontece porque essa classe é abstrata. Como sabemos, um jogo 
            de xadrez tem mais de um tipo de peça e cada tem sua particularidade, regra e movimento.
            Nesta classe só teremos métodos e características que funcionam para todas as peças. 
            Por exemplo: Todas as peças se movimentam, tem cor e uma posição, então devemos implementar aqui 
            (imagina que essa classe seja o universo de todas as peças). A classe "TORRE", diferente
            do classe "BISPO", só se movimenta na horizontal e vertical. Então a criar a classe "TORRE" e "BISPO", 
            que seria uma herança da classe peças, podemos subscrever esse método dentro da realidade de cada delas.
        */
        public abstract bool[,] movimentosPossiveis();
    }
}