//implementação da dama. Não usamos Raínha para não confundir com a peça rei 

using tabuleiro;

namespace xadrez
{
    //classe para a peça Rei
    class Dama : Pecas //Conceito de herança, pois a classe Rei herda de Peça
    {

        public Dama(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }
        public override string ToString()
        {
            return "D";
        }

        private bool podeMover(Posicao pos)
        {
            Pecas p = tab.pecas(tab);
            return p == null || p.cor != this.cor; //
        }


        public override bool[,] movimentosPossiveis()
        { //classe abstrata
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

            //no
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





        }

    }
}