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

                        bool[,] pecasNoTabuleiro;
                        if (partida.possibilidadeCaptura()) {
                            pecasNoTabuleiro = partida.pecasParaCaptura();
                        } else {
                            pecasNoTabuleiro = partida.pecasParaMovimento();
                        }
                        Tela.imprimirTabuleiro(partida, pecasNoTabuleiro);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosicaoDamas(partida.tab).toPosicao();
                        partida.validarPosicaoDeOrigem(origem);

                        if (partida.possibilidadeCaptura()) {
                            pecasNoTabuleiro = partida.tab.peca(origem).capturasPossiveis();
                        } else {
                            pecasNoTabuleiro = partida.tab.peca(origem).movimentosPossiveis();
                        }

                        Peca capturando;
                        SentidoDoMovimento movimentacao;

                        Console.Clear();
                        Tela.imprimirTabuleiro(partida, pecasNoTabuleiro);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoDamas(partida.tab).toPosicao();
                        partida.validarPosicaoDeDestino(origem, destino);

                        partida.realizarJogada(origem, destino);

                        capturando = partida.tab.peca(destino);
                        movimentacao = partida.deslocamento;

                        if (partida.houveCaptura && !partida.promocaoComum) {
                            if (partida.possibilidadeCaptura(capturando, movimentacao)) {
                                pecasNoTabuleiro = partida.tab.peca(destino).capturasPossiveis(movimentacao);
                                origem = destino;
                                partida.turno--;
                                partida.mudarJogador();
                            }

                            while (partida.possibilidadeCaptura(capturando, movimentacao)) {
                                try {
                                    Console.Clear();
                                    Tela.imprimirTabuleiro(partida, pecasNoTabuleiro);

                                    Console.WriteLine();
                                    Console.Write("Destino: ");
                                    destino = Tela.lerPosicaoDamas(partida.tab).toPosicao();
                                    partida.validarPosicaoDeDestino(origem, destino, movimentacao);

                                    partida.realizarJogada(origem, destino);

                                    capturando = partida.tab.peca(destino);
                                    movimentacao = partida.deslocamento;

                                    if (partida.houveCaptura) {
                                        if (partida.possibilidadeCaptura(capturando, movimentacao)) {
                                            pecasNoTabuleiro = partida.tab.peca(destino).capturasPossiveis(movimentacao);
                                            origem = destino;
                                            partida.turno--;
                                            partida.mudarJogador();
                                        }
                                    }
                                } catch (TabuleiroException e) {
                                    Console.WriteLine(e.Message);
                                    Console.ReadKey(true);
                                }
                            }
                        }
                    } catch (TabuleiroException e) {
                        Console.WriteLine(e.Message);
                        Console.ReadKey(true);
                    } catch (Exception e) {
                        Console.WriteLine(e.Message);
                        Console.WriteLine(e.StackTrace);
                        Console.ReadKey(true);
                    }
                }
                Console.Clear();
                Tela.imprimirPartida(partida);
            } catch (TabuleiroException e) {
                Console.WriteLine(e.Message);

                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla para sair...");
                Console.ReadKey(true);
            }
        }
    }
}
