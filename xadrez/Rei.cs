using tabuleiro;

namespace xadrez
{
    //classe para a peça Rei
    class Rei : Piece //Conceito de herança, pois a classe Rei herda de Peça
    {

        public Rei(Tabuleiro tab, Color color) : base(tab, color)
        {

        }
        public override string ToString()
        {
            return "R";
        }

    }
}