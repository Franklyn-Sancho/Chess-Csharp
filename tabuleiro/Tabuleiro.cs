namespace tabuleiro {
    class Tabuleiro {

        public int linhas {get; set;}
        public int colunas {get; set;}
        private piece[,] pieces;

        public Tabuleiro(int linhas, int colunas) {
            this.linhas = linhas;
            this.colunas = colunas;
            pieces = new piece[linhas, colunas];
        }

        public Piece piece(int linha, int coluna) {
            return pieces[linha, coluna];
        }

        public void putPiece(piece p, position pos) {
            pieces[pos.linha, pos.coluna] = p;
        }
    }
}