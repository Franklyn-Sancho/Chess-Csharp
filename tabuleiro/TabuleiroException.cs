//Classe para a criação das exceções do nosso projeto

using System;

namespace tabuleiro {
    class TabuleiroException: Exception {

        public TabuleiroException(string msg) : base(msg) {
            
        }

    } 
}