using tabuleiro;

namespace damas {
    class Comum : Peca {
        public Comum(Tabuleiro tab, Cor cor) : base(tab, cor) {
        }

        public override string ToString() {
            return "C";
        }

        //private bool podeCapturar(Posicao pos) {
        //    Peca p1 = tab.peca(pos);
        //}

        public override bool[,] movimentosPossiveis() {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            if (cor == Cor.Branca) {
                // Testando casa nordeste livre
                pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
                if (tab.posicaoValida(pos) && casaLivre(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }

                // Testando casa nordeste após peça adversária
                pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos)) {
                    pos.definirValores(posicao.linha - 2, posicao.coluna + 2);
                    if (tab.posicaoValida(pos) && casaLivre(pos)) {
                        mat[pos.linha, pos.coluna] = true;
                    }
                }

                // Testando casa noroeste livre
                pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
                if (tab.posicaoValida(pos) && casaLivre(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }

                // Testando casa noroeste após peça adversária
                pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos)) {
                    pos.definirValores(posicao.linha - 2, posicao.coluna - 2);
                    if (tab.posicaoValida(pos) && casaLivre(pos)) {
                        mat[pos.linha, pos.coluna] = true;
                    }
                }

                // Testando casa sudeste após peça adversária
                pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos)) {
                    pos.definirValores(posicao.linha + 2, posicao.coluna + 2);
                    if (tab.posicaoValida(pos) && casaLivre(pos)) {
                        mat[pos.linha, pos.coluna] = true;
                    }
                }

                // Testando casa sudoeste após peça adversária
                pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos)) {
                    pos.definirValores(posicao.linha + 2, posicao.coluna - 2);
                    if (tab.posicaoValida(pos) && casaLivre(pos)) {
                        mat[pos.linha, pos.coluna] = true;
                    }
                }

            } else {
                // Testando casa sudeste livre
                pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
                if (tab.posicaoValida(pos) && casaLivre(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }

                // Testando casa sudeste após peça adversária
                pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos)) {
                    pos.definirValores(posicao.linha + 2, posicao.coluna + 2);
                    if (tab.posicaoValida(pos) && casaLivre(pos)) {
                        mat[pos.linha, pos.coluna] = true;
                    }
                }

                // Testando casa sudoeste livre
                pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
                if (tab.posicaoValida(pos) && casaLivre(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }

                // Testando casa sudoeste após peça adversária
                pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos)) {
                    pos.definirValores(posicao.linha + 2, posicao.coluna - 2);
                    if (tab.posicaoValida(pos) && casaLivre(pos)) {
                        mat[pos.linha, pos.coluna] = true;
                    }
                }

                // Testando casa nordeste após peça adversária
                pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos)) {
                    pos.definirValores(posicao.linha - 2, posicao.coluna + 2);
                    if (tab.posicaoValida(pos) && casaLivre(pos)) {
                        mat[pos.linha, pos.coluna] = true;
                    }
                }

                // Testando casa noroeste após peça adversária
                pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos)) {
                    pos.definirValores(posicao.linha - 2, posicao.coluna - 2);
                    if (tab.posicaoValida(pos) && casaLivre(pos)) {
                        mat[pos.linha, pos.coluna] = true;
                    }
                }
            }

            return mat;
        }
    }
}
