namespace tabuleiro {
    //classe genéricas de posição das peças
    class Position {
        public int linha {get; set;} //vai ter linhas
        public int coluna {get; set;} //colunas

        public Position(int linha, int coluna) { //construtor da posição, recebendo o this
            this.linha = linha;
            this.coluna = coluna;
        }

        public void definirValores(int linha, int coluna) {
            this.linha = linha;
            this.coluna = coluna;
        }

        public override string ToString()
        {
            return linha + "," + coluna;
        }
    }
}