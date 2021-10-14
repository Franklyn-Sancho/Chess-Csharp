using System;
using tabuleiro;
using xadrez;

namespace xadrez {
    class PartidaDeXadrez {

        public Tabuleiro tab{get; private set;}
        public int turno{get; private set;}
        public Cor jogadorAtual{get; private set;}
        public bool terminada {get; private set;}

        public PartidaDeXadrez() {
            tab = new Tabuleiro(8,8); //recebe tabuleiro que tem uma matriz de 8 por 8
            turno = 1; //turno começa no primeiro
            jogadorAtual = Cor.branca; //O jogo sempre começa pelas peças brancas
            terminada = false;
        }

        //lógica da troca de turno entre jogadores
        public void realizaJogada(Posicao origem, Posicao destino) {
            ExecutaMovimento(origem, destino);
            turno++;
            mudaJogador();
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

        public ConsoleModifiers validarPosicaoDeDestino(Posicao origem, Posicao destino) {
            if(!tab.peca(origem).podeMoverPara(destino)) {
                throw new TabuleiroException("Posição de destino inválida");
            }
        }

        //lógica que muda os jogadores
        private void mudaJogador() {
            if(jogadorAtual == Cor.Branca) {  
                jogadorAtual - Cor.Preta;

            } else {
                jogadorAtual = Cor.branca;
            }
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino) { //função que executa o movimento
            Piece p = tab.removePeca(origem);
            p.incrementarMovimentos();
            Piece pecaCapturada = tab.removePeca(destino);
            tab.colocarPeca(p, destino);

        }
    }
}