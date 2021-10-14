using tabuleiro;

namespace xadrez
{
    //classe para a peça Rei
    class Rei : Piece //Conceito de herança, pois a classe Rei herda de Peça
    {

        public Rei(Tabuleiro tab, Color color) : base(tab, color)
        {

        }
        public override string ToString()
        {
            return "R";
        }

        //O método verifica duas coisas:
        //O rei pode mover se a casa estiver vazia ou com uma peça adversária.
        private bool podeMover(Position pos) {
            Piece p = tab.piece(tab);
            return p == null || p.color !=this.color; //
        }


        /*

            class rei => 

            Primeiro devemos lembrar que a classe Rei é uma herança da classe Peças. Lembra que criamos esse
            mesmo método lá, só que como um método abstrato? Então, aqui na classe "Rei" também podemos chama-lo,
            só que com o modificador override, que tem o poder de subscrever os métodos dentro das regras filha.
        */
        public override bool[,] movimentosPossiveis() { //classe abstrata
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Position pos = new Position(0, 0);

            //acima
            pos.definirValores(position.linha - 1, position.coluna);
                if(tab.validPosition(pos) && podeMover(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
            //Nordeste
            pos.definirValores(position.linha - 1, position.coluna + 1);
                if(tab.validPosition(pos) && podeMover(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
            //leste
            pos.definirValores(position.linha, position.coluna + 1);
                if(tab.validPosition(pos) && podeMover(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
            //sudeste
            pos.definirValores(position.linha + 1, position.coluna + 1);
                if(tab.validPosition(pos) && podeMover(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
            //abaixo
            pos.definirValores(position.linha + 1, position.coluna);
                if(tab.validPosition(pos) && podeMover(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
            //sudoeste
            pos.definirValores(position.linha + 1, position.coluna - 1);
                if(tab.validPosition(pos) && podeMover(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
            //oeste
             pos.definirValores(position.linha, position.coluna - 1);
                if(tab.validPosition(pos) && podeMover(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
            //noroeste
             pos.definirValores(position.linha - 1, position.coluna - 1);
                if(tab.validPosition(pos) && podeMover(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
            return mat;
        }

    }
}