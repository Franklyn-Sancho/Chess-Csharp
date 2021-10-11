namespace tabuleiro {
    class Piece {

        public Position position {get; set;}
        public Color color {get; protected set;}

        public int qtMoviments {get;protected set;}
        public Tabuleiro tab {get; protected set;}

        public Piece(Tabuleiro tabuleiro, Color color) {
            this.position = null;
            this.tab = tab;
            this.color = color;
            this.qtMoviments = 0;
        }
    }
}