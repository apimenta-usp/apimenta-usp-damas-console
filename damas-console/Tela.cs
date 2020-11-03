using System;
using System.Collections.Generic;
using tabuleiro;
using damas;

namespace damas_console {
    class Tela {

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
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Criado e projetado por:");
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
