using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    //inicio da classe tela
    class Tela
    {

        public static void imprimirPartida(PartidaDeXadrez partida)
        {
            imprimirTabuleiro(partida.tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("turno: " + partida.turno);
            if(!partida.terminada) {
                Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);
                if(partida.xeque) {
                    Console.WriteLine("XEQUE!");
                }
            } else {
                Console.WriteLine("XEQUEMATE!");
                Console.WriteLine("Vencedor: " + partida.jogadorAtual);
            }
            
        }

        public static void imprimirPecasCapturadas(PartidaDeXadrez partida) {
            Console.WriteLine("Peças Capturadas");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.WriteLine("Pretas: ");
            //mostra o conjunto com a cor das peças capturadas;
            ConsoleColor aux = Console.ForegroundColor;
            ConsoleColor.ForegroundColor = ConsoleColor.Yellow; 
            imprimirConjunto(partida.pecasCapturadas(Cor.Pretas));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void imprimirConjunto(HashSet<Peca> conjunto) {
            Console.Write("[");
            foreach(Pecas x in conjunto) {
                Console.Write(x + " ");
            }
            Console.WriteLine("]");
        }

        //Função que constrói o tabuleiro na linha de comando
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    imprimirPeca(tab.peca(i, j));
                }
                Console.WriteLine();
            }
            //As colunas do tabuleiro são letras de A até H
            Console.WriteLine("  a b c d e f g h");
        }

        //sobrecarga que mostra os movimentos possíveis da peça na tela
        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {

            ConsoleColor fundoOriginal = Console.BackgroundColor; //original
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray; //o que será marcado como fundos possíveis

            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    imprimirPeca(tab.piece(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            //As colunas do tabuleiro são letras de A até H
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }

        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PositionChess(coluna, linha);
        }

        //  função responsável por imprimir as peças 
        public static void imprimirPeca(Piece piece)
        {

            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.color == Color.Branca)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }


        }
    }
}