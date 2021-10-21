using tabuleiro;

namespace xadrez
{   
    //Classe para a pela torre
    class Torre : Pecas //conceito de herança, pois a classe torre herda da geral peças
    {

        public Torre(Tabuleiro tab, Cor cor) : base(tab, color)
        {

        }
        public override string ToString()
        {
            return "T";
        }

        public override bool[,] movimentosPossiveis() { //classe abstrata
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            //acima
            pos.definirValores(posicao.linha - 1, Posicao.coluna);
            while(tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if(tab.pecas(pos) != null && tab.pecas(pos).cor != cor) {
                    break;
                }
                pos.linha = pos.linha - 1;
            }

            //abaixo
            pos.definirValores(position.linha + 1, position.coluna);
            while(tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if(tab.pecas(pos) != null && tab.pecas(pos).cor != cor) {
                    break;
                }
                pos.linha = pos.linha + 1;
            }

            //direita
            pos.definirValores(position.linha, position.coluna + 1);
            while(tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if(tab.pecas(pos) != null && tab.pecas(pos).cor != cor) {
                    break;
                }
                pos.coluna = pos.coluna + 1;
            }
            
            //esquerda
            pos.definirValores(position.linha, position.coluna - 1);
            while(tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if(tab.pecas(pos) != null && tab.pecas(pos).cor != cor) {
                    break;
                }
                pos.coluna = pos.coluna - 1;
            }

            return mat;

        }

    }
}