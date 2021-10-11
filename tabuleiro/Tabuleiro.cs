namespace tabuleiro {
    //classe do tabuleiro
    class Tabuleiro {

        public int linhas {get; set;}
        public int colunas {get; set;}
        private piece[,] pieces;

        public Tabuleiro(int linhas, int colunas) { //construtor do tabuleiro
            this.linhas = linhas;
            this.colunas = colunas;
            pieces = new piece[linhas, colunas];
        }

        public Piece piece(int linha, int coluna) { //As peças recebem as posições da matriz linha e coluna
            return pieces[linha, coluna];
        }

        public Piece piece(Position pos) {
            return pieces[pos.linha, pos.coluna];
        }

        public bool existPiece(Position pos) {
            acceptPosition(pos);
            return piece(pos) != null;
        }

        public void putPiece(piece p, position pos) { //método para colocar uma peça
            if(existPiece(pos)) { //exceção caso já exista uma peça na posição escolhida
                throw new TabuleiroException("Já existe uma peça nessa posição"); 
            }
            pieces[pos.linha, pos.coluna] = p;
            p.position = pos;
        }

        public Piece removePiece(Position pos) { //método para retirar a peça
            if(piece(pos) == null) {
                return null;
            }
            Piece aux = piece(pos);
            aux.position = null;
            pieces[pos.linha, pos.coluna] = null;
            return aux;
        }

        /*
            Método que valida a posição das peças. Se a posição da linha for menor do que zero, 
            receber um valor maior do que o total de linhas; ou a posição da coluna for menor
            do que zero ou receber uma posição maior do que o número de colunas. Retorna falso. 
            Não existe linha ou coluna "-1", por exemplo. E se o número total de linhas for 8, 
            não temos como colocar a peça na linha 9, por exemplo. Pois não existe.
        */
        public bool validPosition(Position pos) { //
            if(pos.linha <0 || pos.linha >=linhas || pos.coluna<0 || pos.coluna>=colunas) {
                return false;
            }
            return true;
        }

        //Método de exceção para posição inválida. Se um dos casos acima for verdadeiro, teremos um retorno de erro
        public void acceptPosition(Position pos) {
            if(!validPosition(pos)) {
                throw new TabuleiroException("Posição Inválida!");
            }
        }
    }
}