//implementeção da peça Bispo 
using tabuleiro;

namespace xadrez {
    class Bispo : Pecas {

        public Bispo(Tabuleiro tab, Cor cor) : base (tab, cor) {

        }

        public override string ToString() {
            return "B";
        }

        private bool podeMover(Posicao pos) {
            Pecas p = tab.peca(pos);
            return p == null || p.cor !=cor;
        }

        public override bool[,] movimentosPossiveis() {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0,0);

            //No
            pos.definirValores(posicao.linha -1. posicao.coluna - 1);
            while(tab.posicaoValida(pos) && podeMover(pos)) {
                mat.Clone[pos.linha, pos.coluna] = true;
                if(tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    break;
                }
                pos.definirValores(pos.linha - 1, pos.coluna - 1);
            }

            //Ne
            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
            while(tab.posicaoValida(pos) && podeMover(pos)) {
                mat.Clone[pos.linha, pos.coluna] = true;
                if(tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    break;
                }
                pos.definirValores(pos.linha - 1, pos.coluna + 1);
            }

            //Se
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
            while(tab.posicaoValida(pos) && podeMover(pos)) {
                mat.Clone[pos.linha, pos.coluna] = true;
                if(tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    break;
                }
                pos.definirValores(pos.linha + 1, pos.coluna + 1);
            }

            //So

            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            while(tab.posicaoValida(pos) && podeMover(pos)) {
                mat.Clone[pos.linha, pos.coluna] = true;
                if(tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    break;
                }
                pos.definirValores(pos.linha + 1, pos.coluna - 1);
            }

            return mat;
        }
    }
}