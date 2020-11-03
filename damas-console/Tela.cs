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
            Console.WriteLine("Origem: c4");
            Console.WriteLine("Destino: e6");
            Console.WriteLine();
            Console.WriteLine("C = Peça Comum");
            Console.WriteLine("D = Dama");
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey(true);
        }

        public static void imprimirTabuleiro(Tabuleiro tab) {

        }
    }
}
