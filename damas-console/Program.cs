using System;
using tabuleiro;
using damas;

namespace damas_console {
    class Program {
        static void Main(string[] args) {

            try {
                Tela.imprimirTelaInicial();

                //Console.Clear();
                int tamanho;

                do {
                    Console.Clear();
                    Console.Write("\nEscolha o tamanho do tabuleiro (6/8/10): ");
                    int.TryParse(Console.ReadLine(), out tamanho);
                } while (tamanho != 6 && tamanho != 8 && tamanho != 10);
                Console.Clear();
                PartidaDeDamas partida = new PartidaDeDamas(tamanho);               

                Tela.imprimirTabuleiro(partida.tab);

            } catch (TabuleiroException e) {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey(true);
        }
    }
}
