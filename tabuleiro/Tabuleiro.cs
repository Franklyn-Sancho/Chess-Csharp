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

        public Piece piece(Position pos) {
            return pieces[pos.linha, pos.coluna];
        }

        public bool existPiece(Position pos) {
            acceptPosition(pos);
            return piece(pos) != null;
        }

        public void putPiece(piece p, position pos) {
            if(existPiece(pos)) {
                throw new TabuleiroException("Já existe uma peça nessa posição");
            }
            pieces[pos.linha, pos.coluna] = p;
            p.position = pos;
        }

        public bool validPosition(Position pos) {
            if(pos.linha <0 || pos.linha >=linhas || pos.coluna<0 || pos.coluna>=colunas) {
                return false;
            }
            return true;
        }

        public void acceptPosition(Position pos) {
            if(!validPosition(pos)) {
                throw new TabuleiroException("Posição Inválida!");
            }
        }
    }
}