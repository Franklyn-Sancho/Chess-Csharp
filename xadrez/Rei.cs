using tabuleiro;

namespace xadrez {
    class Rei : Piece{
        
        public Rei(Tabuleiro tab, Color color) : base(tab, color) {
            
        }
        public override string ToString() {
                return "R";
            }

    }
}