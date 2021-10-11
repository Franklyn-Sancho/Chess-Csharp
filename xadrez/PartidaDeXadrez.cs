using System;
using tabuleiro;

namespace xadrez {
    class PartidaDeXadrez {

        public Tabuleiro tab{get; private set;}
        private int turno;
        private Color jogadorAtual;

        public PartidaDeXadrez() {
            tab = new Tabulieor(8,8);
            turno = 1;
            jogadorAtual = Color.branca;
        }

        public void ExecutaMovimento(Position origin, Position destiny) {
            Piece p = tab.removePiece(origin);
            p.incrementMoviment();
            Piece capturedPiece = tab.removePiece(destiny);
            tab.putPiece(p, destiny);

        }
    }
}