using tabuleiro;

namespace xadrez
{   
    //Classe para a pela torre
    class Torre : Piece //conceito de herança, pois a classe torre herda da geral peças
    {

        public Torre(Tabuleiro tab, Color color) : base(tab, color)
        {

        }
        public override string ToString()
        {
            return "T";
        }

        public override bool[,] movimentosPossiveis() { //classe abstrata
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Position pos = new Position(0, 0);

            //acima
            pos.definirValores(position.linha - 1, position.coluna);
            while(tab.validPosition(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if(tab.piece(pos) != null && tab.piece(pos).color != color) {
                    break;
                }
                pos.linha = pos.linha - 1;
            }

            //abaixo
            pos.definirValores(position.linha + 1, position.coluna);
            while(tab.validPosition(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if(tab.piece(pos) != null && tab.piece(pos).color != color) {
                    break;
                }
                pos.linha = pos.linha + 1;
            }

            //direita
            pos.definirValores(position.linha, position.coluna + 1);
            while(tab.validPosition(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if(tab.piece(pos) != null && tab.piece(pos).color != color) {
                    break;
                }
                pos.coluna = pos.coluna + 1;
            }
            
            //esquerda
            pos.definirValores(position.linha, position.coluna - 1);
            while(tab.validPosition(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if(tab.piece(pos) != null && tab.piece(pos).color != color) {
                    break;
                }
                pos.coluna = pos.coluna - 1;
            }

        }

    }
}