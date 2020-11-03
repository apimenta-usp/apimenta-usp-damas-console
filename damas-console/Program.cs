using System;
using tabuleiro;
using damas;

namespace damas_console {
    class Program {
        static void Main(string[] args) {

            Tela.imprimirTelaInicial();

            Console.Clear();
            Tabuleiro tab = new Tabuleiro(8, 8);
            Tela.imprimirTabuleiro(tab);


            Console.WriteLine();
        }
    }
}
