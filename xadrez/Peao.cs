using tabuleiro;

namespace xadrez
{
    //classe para a peça Rei
    class Peao : Pecas //Conceito de herança, pois a classe Rei herda da classe Pecas
    {

        public Peao(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }
        public override string ToString()
        {
            return "P";
        }

        //O método verifica duas coisas:
        //O rei pode mover se a casa estiver vazia ou com uma peça adversária.
        private bool existeInimigo(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p.cor != cor;
        }

        //O atributo é privado porque apenas a classe terá acesso a ela.
        private bool livre(Posicao pos)
        {
            return tab.peca(pos) == null;
        }

        /**
            Aqui temos o modificador override, responsável por subscrever a classe movimentosPossiveis 
            da classe Pecas dentro da particularidade da classe peão. 
         */
        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            /**
                Aqui temos a movimentação das peças brancas.
             */
            if (cor == Cor.Branca)
            {
                //Uma casa a frente se tiver livre
                pos.definirValores(posicao.linha - 1, posicao.coluna);
                if (tab.posicaoValida(pos) && livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                //Se a peça tem zero quantidade de movimentos, poderá se movimentar duas casas a frente
                pos.definirValores(posicao.linha - 2, posicao.coluna);
                if (tab.posicaoValida(pos) && livre(pos) && qteMovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha - 1, posicao.coluna - 1); //captura na diagonal
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha - 1, posicao.coluna + 1); //captura na diagonal
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
            }
            //movimento das peças pretas.
            else
            {
                //Movimento normal, pra frente, caso não haja nenhuma outra peça
                pos.definirValores(posicao.linha + 1, posicao.coluna);
                if (tab.posicaoValida(pos) && livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                //se movimenta duas casas caso a quantidade de movimentos seja zero
                pos.definirValores(posicao.linha + 2, posicao.coluna);
                if (tab.posicaoValida(pos) && livre(pos) && qteMovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha + 1, posicao.coluna - 1); //Captura na diaginal
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha + 1, posicao.coluna + 1); //captura na diagonal
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
            }

            return mat;

        }

    }
}
