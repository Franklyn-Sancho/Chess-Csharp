using System;
using tabuleiro;
using xadrez;

namespace xadrez {
    class PartidaDeXadrez {

        public Tabuleiro tab{get; private set;}
        public int turno{get; private set;}
        public Color jogadorAtual{get; private set;}
        public bool terminada {get; private set;}

        public PartidaDeXadrez() {
            tab = new Tabuleiro(8,8); //recebe tabuleiro que tem uma matriz de 8 por 8
            turno = 1; //turno começa no primeiro
            jogadorAtual = Color.branca; //O jogo sempre começa pelas peças brancas
            terminada = false;
        }

        //lógica da troca de turno entre jogadores
        public void realizaJogada(position origem, Position destino) {
            ExecutaMovimento(origem, destino);
            turno++;
            mudaJogador();
        }

        //método que retorna as exceções
        public bool validarPosicaoDeOrigem(Position pos) {
            if(tab.piece(pos) == null) {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida");
            }
            if(jogadorAtual != tab.piece(pos).cor) {
                throw new TabuleiroException("A peça de origem escolhida não é a sua");
            }
            if(!tab.piece(pos).existeMovimentosPossiveis()) {
                throw new TabuleiroException("Não há movimentos possíveis para essa peça");
            }
        }

        //lógica que muda os jogadores
        private void mudaJogador() {
            if(jogadorAtual == Color.Branca) {  
                jogadorAtual - Color.Preta;

            } else {
                jogadorAtual = Color.branca;
            }
        }

        public void ExecutaMovimento(Position origem, Position destino) { //função que executa o movimento
            Piece p = tab.removePiece(origem);
            p.incrementMoviment();
            Piece capturedPiece = tab.removePiece(destino);
            tab.putPiece(p, destino);

        }
    }
}