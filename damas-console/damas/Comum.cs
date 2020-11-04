using tabuleiro;

namespace damas {
    class Comum : Peca {
        public Comum(Tabuleiro tab, Cor cor) : base(tab, cor) {
        }

        public override string ToString() {
            return "C";
        }

    }
}
