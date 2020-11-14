using System;
using System.Collections.Generic;
using tabuleiro;
using damas;

namespace damas_console {
    class Tela {
        //public Tabuleiro tab { get; private set; }

        public static void imprimirTelaInicial() {
            Console.Clear();
            ConsoleColor corPadrao = Console.ForegroundColor;
            Console.WriteLine();
            Console.WriteLine("#  #  #  #  #  #  #  #  #");
            Console.WriteLine("#                       #");
            Console.Write("#     ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("JOGO DE DAMAS");
            Console.ForegroundColor = corPadrao;
            Console.WriteLine("     #");
            Console.Write("#        ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("CONSOLE");
            Console.ForegroundColor = corPadrao;
            Console.WriteLine("        #");
            Console.WriteLine("#                       #");
            Console.WriteLine("#  #  #  #  #  #  #  #  #");
            Console.WriteLine();
            Console.WriteLine("Criado e projetado por:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Adriano Pimenta");
            Console.ForegroundColor = corPadrao;
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey(true);
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Como jogar:");
            Console.WriteLine("1) Digite as coordenadas da peça");
            Console.WriteLine("   a ser movida (origem);");
            Console.WriteLine("2) Digite as coordenadas do local");
            Console.WriteLine("   para onde mover a peça (destino).");
            Console.WriteLine();
            Console.WriteLine("Exemplo:");
            Console.WriteLine("Origem: c3");
            Console.WriteLine("Destino: d4");
            Console.WriteLine();
            Console.WriteLine("C = peça Comum");
            Console.WriteLine("D = Dama");
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey(true);
        }

        public static void imprimirPartida(PartidaDeDamas partida) {
            Tela.imprimirTabuleiro(partida.tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.turno);
            if (!partida.terminada) {
                Console.Write("Aguardando jogada: ");
                if (partida.jogadorAtual == Cor.Preta) {
                    ConsoleColor corPadrao = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(partida.jogadorAtual);
                    Console.ForegroundColor = corPadrao;
                } else {
                    Console.WriteLine(partida.jogadorAtual);
                }
                //if (partida.promocaoPecaComum) {
                //    Console.WriteLine("\nPeca promovida a Dama!");
                //}
            } else {
                Console.WriteLine("\nFIM DA PARTIDA!");
                Console.Write("Vencedor: ");
                if (partida.jogadorAtual == Cor.Preta) {
                    ConsoleColor corPadrao = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(partida.jogadorAtual);
                    Console.ForegroundColor = corPadrao;
                } else {
                    Console.WriteLine(partida.jogadorAtual);
                }
            }
        }

        public static void imprimirPecasCapturadas(PartidaDeDamas partida) {
            ConsoleColor corPadrao = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Peças capturadas:");
            Console.ForegroundColor = corPadrao;
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Pretas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            Console.ForegroundColor = corPadrao;
            Console.WriteLine();
        }

        public static void imprimirConjunto(HashSet<Peca> conjunto) {
            int comum = 0;
            int dama = 0;
            Console.Write("[ ");
            foreach (Peca p in conjunto) {
                if (p is Comum) {
                    comum++;
                }
                if (p is Dama) {
                    dama++;
                }
            }
            if (comum > 0) {
                Console.Write(comum + "C ");
            } else Console.Write("");
            if (dama > 0) {
                Console.Write(dama + "D ");
            } else Console.Write("");
            Console.Write("]");
        }

        public static void imprimirTabuleiro(Tabuleiro tab) {

            for (int i = 0; i < tab.linhas; i++) {
                imprimirNumero(tab, i);
                for (int j = 0; j < tab.colunas; j++) {
                    imprimirPeca(tab.peca(i, j), i, j);
                }
                Console.WriteLine();
            }
            imprimirLetra(tab);
        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis) {

            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.linhas; i++) {
                imprimirNumero(tab, i);
                for (int j = 0; j < tab.colunas; j++) {
                    if (posicoesPossiveis[i, j]) {
                        Console.BackgroundColor = fundoAlterado;
                    } else {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    imprimirPeca(tab.peca(i, j), i, j);
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
                Console.BackgroundColor = fundoOriginal;
            }
            imprimirLetra(tab);
        }

        private static bool validarLinha(Tabuleiro tab, int linha) {
            for (int i = 1; i <= tab.linhas; i++) {
                if (linha == i) {
                    return true;
                }
            }
            return false;
        }

        private static bool validarColuna(Tabuleiro tab, char coluna) {
            for (int i = 0; i < tab.colunas; i++) {
                if (coluna == 'a' + i) {
                    return true;
                }
            }
            return false;
        }

        public static PosicaoDamas lerPosicaoDamas(Tabuleiro tab) {
            string leitura = Console.ReadLine();
            string s = leitura.Trim();
            if (s.Length != 2) {
                throw new TabuleiroException("Digitação incorreta!");
            }
            char coluna = s[0];
            int linha;
            if (!(int.TryParse((s[1] + ""), out linha))) {
                throw new TabuleiroException("Digitação incorreta!");
            } else {
                linha = int.Parse(s[1] + "");
                /* Na linha acima, para o programa entender o Parse do char na posição 1, foi 
                   preciso acrescentar as aspas para fazer uma conversão explícita para string. */
            }
            if (validarLinha(tab, linha) && validarColuna(tab, coluna)) {
                return new PosicaoDamas(coluna, linha);
            } else {
                throw new TabuleiroException("Digitação incorreta!");
            }
        }

        public static void imprimirPeca(Peca peca, int i, int j) {
            if (peca == null) {
                imprimirTraco(i, j);
                Console.Write(" ");
            } else {
                if (peca.cor == Cor.Branca) {
                    Console.Write(peca);
                } else {
                    ConsoleColor corPadrao = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = corPadrao;
                }
                Console.Write(" ");
            }
        }

        public static void imprimirTraco(int i, int j) {
            if (i % 2 == 0 && j % 2 == 0 || i % 2 == 1 && j % 2 == 1) {
                Console.Write("-");
            } else {
                ConsoleColor corPadrao = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("-");
                Console.ForegroundColor = corPadrao;
            }
        }

        public static void imprimirLetra(Tabuleiro tab) {
            ConsoleColor corPadrao = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (tab.linhas < 10) {
                Console.Write("  ");
            } else {
                Console.Write("   ");
            }
            char letra = 'a';
            for (int i = 0; i < tab.colunas; i++) {
                Console.Write((char)(letra + i) + " ");
            }
            Console.WriteLine();
            Console.ForegroundColor = corPadrao;
        }

        public static void imprimirNumero(Tabuleiro tab, int i) {
            ConsoleColor corPadrao = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (tab.linhas < 10) {
                Console.Write(tab.linhas - i + " ");
            } else if (tab.linhas - i < 10) {
                Console.Write(" " + (tab.linhas - i) + " ");
            } else {
                Console.Write(tab.linhas - i + " ");
            }
            Console.ForegroundColor = corPadrao;
        }
    }
}
