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

                while (!partida.terminada) {

                    try {
                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosicaoDamas(partida.tab).toPosicao();
                        partida.validarPosicaoDeOrigem(origem);

                        bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoDamas(partida.tab).toPosicao();
                        partida.validarPosicaoDeDestino(origem, destino);

                        partida.realizarJogada(origem, destino);
                    } catch (TabuleiroException e) {
                        Console.WriteLine(e.Message);
                        Console.ReadKey(true);
                    } catch (Exception e) {
                        Console.WriteLine(e.Message);
                        //Console.WriteLine(e.StackTrace);
                        Console.ReadKey(true);
                    }
                }
                Console.Clear();
                Tela.imprimirTabuleiro(partida.tab);
            } catch (TabuleiroException e) {
                Console.WriteLine(e.Message);

                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla para sair...");
                Console.ReadKey(true);
            }
        }
    }
}
