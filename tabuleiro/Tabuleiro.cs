namespace tabuleiro {
    //classe do tabuleiro
    class Tabuleiro {

        public int linhas {get; set;}
        public int colunas {get; set;}
        private peca[,] pecas;

        public Tabuleiro(int linhas, int colunas) { //construtor do tabuleiro
            this.linhas = linhas;
            this.colunas = colunas;
            pieces = new piece[linhas, colunas];
        }

        public Pecas pecas(int linha, int coluna) { //As peças recebem as posições da matriz linha e coluna
            return pecas[linha, coluna];
        }

        public Pecas pecas(Position pos) {
            return pieces[pos.linha, pos.coluna];
        }

        public bool existePeca(Posicao pos) {
            posicaoAceita(pos);
            return peca(pos) != null;
        }

        public void colocarPeca(peca p, posicao pos) { //método para colocar uma peça
            if(existePeca(pos)) { //exceção caso já exista uma peça na posição escolhida
                throw new TabuleiroException("Já existe uma peça nessa posição"); 
            }
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }

        public Pecas removePeca(Posicao pos) { //método para retirar a peça
            if(peca(pos) == null) {
                return null;
            }
            peca aux = peca(pos);
            aux.posicao = null;
            pecas[pos.linha, pos.coluna] = null;
            return aux;
        }

        /*
            Método que valida a posição das peças. Se a posição da linha for menor do que zero, 
            receber um valor maior do que o total de linhas; ou a posição da coluna for menor
            do que zero ou receber uma posição maior do que o número de colunas. Retorna falso. 
            Não existe linha ou coluna "-1", por exemplo. E se o número total de linhas for 8, 
            não temos como colocar a peça na linha 9, por exemplo. Pois não existe.
        */
        public bool posicaoValida(Posicao pos) { //
            if(pos.linha <0 || pos.linha >=linhas || pos.coluna<0 || pos.coluna>=colunas) {
                return false;
            }
            return true;
        }

        //Método de exceção para posição inválida. Se um dos casos acima for verdadeiro, teremos um retorno de erro
        public void posicaoAceita(Posicao pos) {
            if(!posicaoValida(pos)) {
                throw new TabuleiroException("Posição Inválida!");
            }
        }
    }
}