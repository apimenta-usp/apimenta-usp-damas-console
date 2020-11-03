using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace damas {
    class PartidaDeDamas {

        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }

        public PartidaDeDamas() {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
        }

    }
}
