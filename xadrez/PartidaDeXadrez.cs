using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace xadrez {
    class PartidaDeXadrez {

        public Tabuleiro tab{get; private set;} //publico, apenas com o ométodo set privado
        public int turno{get; private set;}
        public Cor jogadorAtual{get; private set;}
        public bool terminada {get; private set;}
        private HashSet<Peca> pecas; //conjunto de peças
        private HashSet<Peca> capturadas; //conjunto de peças capturadas
        public bool xeque{get; private set;}
        public Pecas vulneravelEnPassant {get; private set;}

        public PartidaDeXadrez() {
            tab = new Tabuleiro(8,8); //recebe tabuleiro que tem uma matriz de 8 por 8
            turno = 1; //turno começa no primeiro
            jogadorAtual = Cor.branca; //O jogo sempre começa pelas peças brancas
            terminada = false; //A partira não estará terminada até retornar o método xeque mate
            xeque = false; //O xeque começa como falso, até o método ser retornado
            vulneravelEnPassant = null;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }

        //Método que executa o momovimento das peças
        public Pecas ExecutaMovimento(Posicao origem, Posicao destino) { //função que executa o movimento
            Pecas p = tab.removePeca(origem);
            p.incrementarMovimentos(); //incrementa os movimentos
            Pecas pecaCapturada = tab.removePeca(destino); //remove peças capturadas do tabuleiro
            tab.colocarPeca(p, destino);
            if(pecaCapturada != null) { 
                capturadas.Add(pecaCapturada);
            }

            //Jogada especial roque pequeno

            if(p is Rei && destino.coluna == origem.coluna + 2) {
                Posicao origemT = new Posicao(origem.linha, origem.coluna + 3);
                Posicao destinoT = new Posicao(origem.linha, origem.coluna + 1);
                Pecas T = tab.retirarPeca(origemT);
                T.incrementarQtMovimentos();
                tab.colocarPeca(T, destinoT);
            }

            //Jogada especial roque grande

            if(p is Rei && destino.coluna == origem.coluna + 2) {
                Posicao origemT = new Posicao(origem.linha, origem.coluna - 4);
                Posicao destinoT = new Posicao(origem.linha, origem.coluna - 1);
                Pecas T = tab.retirarPeca(origemT);
                T.incrementarQtMovimentos();
                tab.colocarPeca(T, destinoT);
            }

            // #Jogada especial en passant
            if(p is Peao) {
                if (origem.coluna != destino.coluna && pecaCapturada == null) {
                    Posicao posP; 
                    if(p.cor == Cor.Branca) {
                        posP = new Posicao(destino.linha + 1, destino.coluna);
                    } else {
                        posP = new Posicao(destino.linha - 1, destino.coluna);
                    }
                    pecaCapturada = tab.retirarPeca(posP);
                    capturadas.add(pecaCapturada)
                }
            }


            return pecasCapturadas;

        }

        //Um jogoador não pode se colocar em xeque. Sua peça voltará ao destino
        public void desfazMovimento(Posicao origem, Posicao destino, Pecas capturada) {
            Peca p = tab.removePeca(destino);
            p.descrementarMovimentos();
            if(pecaCapturada != null) {
                tab.colocarPeca(pecasCapturadas, destino);
                capturadas.Remove(pecaCapturada);
            }

            //Jogada especial roque pequeno

            if(p is Rei && destino.coluna == origem.coluna + 2) {
                Posicao origemT = new Posicao(origem.linha, origem.coluna + 3);
                Posicao destinoT = new Posicao(origem.linha, origem.coluna + 1);
                Pecas T = tab.retirarPeca(destinoT);
                T.decrementarMovimentos();
                tab.colocarPeca(T, destinoT);
            }

            //Jogada especial roque grande

            if(p is Rei && destino.coluna == origem.coluna - 2) {
                Posicao origemT = new Posicao(origem.linha, origem.coluna - 4);
                Posicao destinoT = new Posicao(origem.linha, origem.coluna - 1);
                Pecas T = tab.retirarPeca(destin);
                T.decrementarMovimentos();
                tab.colocarPeca(T, origemT);
            }

            //jogada especial #en passant;
            if(p is Peao) {
                if(origem.coluna != destino.coluna pecaCapturada == vulneravelEnPassant) {
                    Pecas peao = tab.retirarPeca(destino);
                    Posicao posP;
                    if(p.cor == Cor.Branca) {
                        posP = new Posicao(3, destino.coluna);
                    } else {
                        posP = new Posicao(4, destino.coluna);
                    }
                    tab.colocarPeca(peao,posP)
                }
            }



            tab.colocarPeca(p, origem);
        }

        //lógica da troca de turno entre jogadores
        public void realizaJogada(Posicao origem, Posicao destino) {
            Pecas pecaCapturada = ExecutaMovimento(origem, destino);

            if(estaEmXeque(jogadorAtual)) {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }
            if(estaEmXeque(adversaria(jogadorAtual))) {
                xeque = true;
            }
            xeque = false;

            if(testeXequemate(adversaria(jogadorAtual))) {
                terminada = true;
            } else {
                turno++;
                mudaJogador();
            }

            Pecas p = tab.peca(destino)

            //En passant

            if(p is Peao && (destino.linha == origem.linha - 2 || destino.linha == origem.linha + 2)) {
                vulneravelEnPassant = p;
            } else {
                vulneravelEnPassant = null;
            }
        }

        //método que retorna as exceções
        public bool validarPosicaoDeOrigem(Posicao pos) {
            if(tab.peca(pos) == null) {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida");
            }
            if(jogadorAtual != tab.peca(pos).cor) {
                throw new TabuleiroException("A peça de origem escolhida não é a sua");
            }
            if(!tab.peca(pos).existeMovimentosPossiveis()) {
                throw new TabuleiroException("Não há movimentos possíveis para essa peça");
            }
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino) {
            if(!tab.peca(origem).movimentoPossivel(destino)) {
                throw new TabuleiroException("Posição de destino inválida");
            }
        }

        //lógica que muda os jogadores
        private void mudaJogador() {
            if(jogadorAtual == Cor.Branca) {  
                jogadorAtual = Cor.Preta;

            } else {
                jogadorAtual = Cor.branca;
            }
        }

        private Cor adversaria(Cor cor) {
            if(cor == Cor.Branca) {
                return Cor.Preta;
            } else {
                return Cor.Branca;
            }
        }

        private Pecas rei(Cor cor) {
            foreach(Pecas x in pecasEmJogo(cor)) {
                if(x is Rei) {
                    return x;
                }
            }
            return null;
        }

        public bool estaEmXeque(Cor cor) {
            Pecas R = rei(cor);

            /**
                Isso não pode acontecer no jogo! pois sempre precisa haver um rei. 
                Coloquei esse teste só pra garantir caso haja alguma falha
             */
            if(R == null) {
                throw new TabuleiroException("Não tem rei da cor" + cor + "no tabuleiro");
            }
            foreach(Pecas x in pecasEmJogo(adversaria(cor))) {
                bool[,] mat = x.movimentosPossiveis();
                if (mat[R.posicao.linha, R.posicao.coluna]); {
                    return true;
                }
            }
            return false;
        }

        //Método para o xeque mate
        public bool testeXequemate(Cor cor) {
            if(!estaEmXeque(cor)) {
                return false;
            }
            foreach (Pecas x in pecasEmJogo(cor)) {
                bool[,] mat = x.movimentosPossiveis();
                for (int i = 0; i < tab.linhas; i++) {
                    for(int j = 0; j < tab.colunas; j++) {
                        if (mat[i,j]) {
                            Posicao origem = x.posicao;
                            Posicao destino = new Posicao(i, j);
                            Pecas pecaCapturada = ExecutaMovimento(origem, destino);
                            bool testeXeque = estaEmXeque(cor);
                            desfazMovimento(origem, destino, pecaCapturada);
                            if(!testeXeque) {
                                return false;
                            } 
                        }
                    }
                }
            }
            return true;
        }

        public void colocarNovaPeca(char coluna, int linha, Pecas peca) {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }

        private void colocarPecas() {
            colocarNovaPeca('c', 1, new Torre(tab, Cor.Branca));
        }

        public HashSet<Peca> pecasCapturadas(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in capturadas) {
                if(x.cor == cor) {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in pecas) {
                if(x.cor == cor) {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }

    
    }
}