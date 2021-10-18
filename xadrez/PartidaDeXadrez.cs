using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace xadrez {
    class PartidaDeXadrez {

        public Tabuleiro tab{get; private set;}
        public int turno{get; private set;}
        public Cor jogadorAtual{get; private set;}
        public bool terminada {get; private set;}
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        public bool xeque{get; private set;}

        public PartidaDeXadrez() {
            tab = new Tabuleiro(8,8); //recebe tabuleiro que tem uma matriz de 8 por 8
            turno = 1; //turno começa no primeiro
            jogadorAtual = Cor.branca; //O jogo sempre começa pelas peças brancas
            terminada = false;
            xeque = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }

        public Pecas ExecutaMovimento(Posicao origem, Posicao destino) { //função que executa o movimento
            Pecas p = tab.removePeca(origem);
            p.incrementarMovimentos();
            Pecas pecaCapturada = tab.removePeca(destino);
            tab.colocarPeca(p, destino);
            if(pecaCapturada != null) {
                capturadas.Add(pecaCapturada);
            }
            return pecasCapturadas;

        }

        public void desfazMovimento(Posicao origem, Posicao destino, Pecas capturada) {
            Peca p = tab.removePeca(destino);
            p.descrementarMovimentos();
            if(pecaCapturada != null) {
                tab.colocarPeca(pecasCapturadas, destino);
                capturadas.Remove(pecaCapturada);
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