//implementação da peça cavalo

using tabuleiro;

namespace xadrez {
    class Cavalo : Pecas {

        public Cavalo(Tabuleiro tab, Cor cor) : base (tab, cor) {

        }

        public override string ToString() {
            return "C";
        }

        private bool podeMover(Posicao pos) {
            Pecas p = tab.peca(pos);
            return p == null || p.cor !=cor;
        }

        public override bool[,] movimentosPossiveis() {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao posicao = new Posicao(0,0);

            pos.definirValores(posicao.linha - 1, posicao.coluna - 2);
            if(tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            pos.definirValores(posicao.linha - 2, posicao.coluna - 1);
            if(tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            pos.definirValores(posicao.linha - 2, posicao.coluna + 1);
            if(tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            pos.definirValores(posicao.linha - 1, posicao.coluna + 2);
            if(tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            pos.definirValores(posicao.linha + 1, posicao.coluna + 2);
            if(tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            pos.definirValores(posicao.linha + 2, posicao.coluna + 1);
            if(tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            pos.definirValores(posicao.linha - 2, posicao.coluna - 1);
            if(tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            pos.definirValores(posicao.linha + 1, posicao.coluna - 2);
            if(tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

            return mat;

        }
    }
}