using tabuleiro;

namespace xadrez
{
    class Torre : Piece
    {

        public Torre(Tabuleiro tab, Color color) : base(tab, color)
        {

        }
        public override string ToString()
        {
            return "T";
        }

    }
}