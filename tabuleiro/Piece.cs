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
    }
}