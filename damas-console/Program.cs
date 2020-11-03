using System;
using tabuleiro;
using damas;

namespace damas_console {
    class Program {
        static void Main(string[] args) {

            try {
                Tela.imprimirTelaInicial();

                Console.Clear();
                Tabuleiro tab = new Tabuleiro(8, 8);
                Tela.imprimirTabuleiro(tab);

            } catch (TabuleiroException e) {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey(true);
        }
    }
}
