using tabuleiro;

namespace xadrez
{
    //classe para a peça Rei
    class Rei : Pecas //Conceito de herança, pois a classe Rei herda de Peça
    {

        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }
        public override string ToString()
        {
            return "R";
        }

        //O método verifica duas coisas:
        //O rei pode mover se a casa estiver vazia ou com uma peça adversária.
        private bool podeMover(Posicao pos) {
            Pecas p = tab.pecas(tab);
            return p == null || p.cor !=this.cor; //
        }


        /*

            class rei => 

            Primeiro devemos lembrar que a classe Rei é uma herança da classe Peças. Lembra que criamos esse
            mesmo método lá, só que como um método abstrato? Então, aqui na classe "Rei" também podemos chama-lo,
            só que com o modificador override, que tem o poder de subscrever os métodos dentro das regras filha.
        */
        public override bool[,] movimentosPossiveis() { //classe abstrata
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            //acima
            pos.definirValores(posicao.linha - 1, posicao.coluna);
                if(tab.posicaoValida(pos) && podeMover(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
            //Nordeste
            pos.definirValores(position.linha - 1, position.coluna + 1);
                if(tab.posicaoValida(pos) && podeMover(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
            //leste
            pos.definirValores(position.linha, position.coluna + 1);
                if(tab.posicaoValida(pos) && podeMover(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
            //sudeste
            pos.definirValores(position.linha + 1, position.coluna + 1);
                if(tab.posicaoValida(pos) && podeMover(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
            //abaixo
            pos.definirValores(position.linha + 1, position.coluna);
                if(tab.posicaoValida(pos) && podeMover(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
            //sudoeste
            pos.definirValores(position.linha + 1, position.coluna - 1);
                if(tab.posicaoValida(pos) && podeMover(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
            //oeste
             pos.definirValores(position.linha, position.coluna - 1);
                if(tab.posicaoValida(pos) && podeMover(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
            //noroeste
             pos.definirValores(position.linha - 1, position.coluna - 1);
                if(tab.posicaoValida(pos) && podeMover(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
            return mat;
        }

    }
}