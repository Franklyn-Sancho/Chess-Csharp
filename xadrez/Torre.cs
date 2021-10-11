using tabuleiro;

namespace xadrez
{   
    //Classe para a pela torre
    class Torre : Piece //conceito de herança, pois a classe torre herda da geral peças
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