using tabuleiro;

namespace xadrez
{
    //classe para a peça Rei
    class Rei : Pecas //Conceito de herança, pois a classe Rei herda de Peça
    {

        private PartidaDeXadrez partida;

        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
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

        private bool testeTorreParaRoque(Posicao pos) {
            Pecas p = tab.peca(pos);
            return p != null && p is Torre && p.cor == cor %% p.qtMovimentos == 0;
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


            // #Jogada especial Roque pequeno
            if(qtMovimentos == 0 && !partida.xeque) {
                Posicao posT1 = new Posicao(posicao.linha, posicao.coluna + 3);
                if (testeTorreParaRoque(posT1)) {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna + 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna + 2);
                    if(tab.peca(p1)==null && tab.peca(p2)==null) {
                        mat[posicao.linha, posicao.coluna + 2] = true;
                    }
                }
                // #jogada especial roque grande
                Posicao posT2 = new Posicao(posicao.linha, posicao.coluna - 4);
                if (testeTorreParaRoque(posT2)) {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna - 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna - 2);
                    Posicao p3 = new Posicao(posicao.linha, posicao.coluna - 3);
                    if(tab.peca(p1)==null && tab.peca(p2)==null && tab.peca(p3) == null) {
                        mat[posicao.linha, posicao.coluna - 2] = true;
                    }
                }
            }


            return mat;
        }

    }
}