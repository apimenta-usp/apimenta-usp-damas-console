using tabuleiro;

namespace damas {
    class Comum : Peca {
        public Comum(Tabuleiro tab, Cor cor) : base(tab, cor) {
        }

        public override string ToString() {
            return "C";
        }

        private bool podeMover(Posicao pos) {
            Peca p = tab.peca(pos);
            return p == null;
        }

        //private bool podeCapturar(Posicao pos) {
        //    Peca p1 = tab.peca(pos);
        //}

        public override bool[,] movimentosPossiveis() {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            if (cor == Cor.Branca) {
                // Testando casa nordeste
                pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
                if (tab.posicaoValida(pos) && podeMover(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }

                // Testando casa noroeste
                pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
                if (tab.posicaoValida(pos) && podeMover(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }

            } else {
                // Testando casa sudeste
                pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
                if (tab.posicaoValida(pos) && podeMover(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }

                // Testando casa sudoeste
                pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
                if (tab.posicaoValida(pos) && podeMover(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
            }

            return mat;
        }
    }
}
