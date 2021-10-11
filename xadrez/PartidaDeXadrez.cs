using System;
using tabuleiro;

namespace xadrez {
    class PartidaDeXadrez {

        public Tabuleiro tab{get; private set;}
        private int turno;
        private Color jogadorAtual;

        public PartidaDeXadrez() {
            tab = new Tabuleiro(8,8); //recebe tabuleiro que tem uma matriz de 8 por 8
            turno = 1; //turno começa no primeiro
            jogadorAtual = Color.branca; //O jogo sempre começa pelas peças brancas
        }

        public void ExecutaMovimento(Position origin, Position destiny) { //função que executa o movimento
            Piece p = tab.removePiece(origin);
            p.incrementMoviment();
            Piece capturedPiece = tab.removePiece(destiny);
            tab.putPiece(p, destiny);

        }
    }
}