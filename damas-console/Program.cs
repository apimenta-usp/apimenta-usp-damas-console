using System;
using tabuleiro;
using damas;

namespace damas_console {
    class Program {
        static void Main(string[] args) {

            try {
                Tela.imprimirTelaInicial();

                //Console.Clear();
                int escolha;

                do {
                    Console.Clear();
                    Console.Write("\nEscolha o tamanho do tabuleiro (6/8/10): ");
                    int.TryParse(Console.ReadLine(), out escolha);
                    //escolha = int.Console.ReadLine();

                } while (escolha != 6 && escolha != 8 && escolha != 10);

                Console.Clear();
                Tabuleiro tab = new Tabuleiro(escolha, escolha);
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
