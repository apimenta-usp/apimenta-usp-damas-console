using tabuleiro;

namespace damas {
    class Dama : Peca {
        public Dama(Tabuleiro tab, Cor cor) : base(tab, cor) {
        }

        public override string ToString() {
            return "D";
        }
        
        //private bool podeCapturar(Posicao pos) {
        //    Peca p1 = tab.peca(pos);
        //}

        public override bool[,] movimentosPossiveis() {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            // Testando casas nordeste livres
            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
            while (tab.posicaoValida(pos) && casaLivre(pos)) {
                mat[pos.linha, pos.coluna] = true;
                pos.linha--;
                pos.coluna++;
            }

            // Testando casas nordeste após peça adversária
            for (int i = 1; i <= tab.linhas; i++) {
                pos.definirValores(posicao.linha - i, posicao.coluna + i);
                if (tab.posicaoValida(pos) && existeInimigo(pos)) {
                    pos.definirValores(posicao.linha - (i + 1), posicao.coluna + (i + 1));
                    while (tab.posicaoValida(pos) && casaLivre(pos)) {
                        mat[pos.linha, pos.coluna] = true;
                        pos.linha--;
                        pos.coluna++;
                    }
                    break;
                }
            }

            // Testando casas sudeste livres
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
            while (tab.posicaoValida(pos) && casaLivre(pos)) {
                mat[pos.linha, pos.coluna] = true;
                pos.linha++;
                pos.coluna++;
            }

            // Testando casas sudeste após peça adversária
            for (int i = 1; i <= tab.linhas; i++) {
                pos.definirValores(posicao.linha + i, posicao.coluna + i);
                if (tab.posicaoValida(pos) && existeInimigo(pos)) {
                    pos.definirValores(posicao.linha + (i + 1), posicao.coluna + (i + 1));
                    while (tab.posicaoValida(pos) && casaLivre(pos)) {
                        mat[pos.linha, pos.coluna] = true;
                        pos.linha++;
                        pos.coluna++;
                    }
                    break;
                }
            }

            // Testando casas sudoeste livres
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            while (tab.posicaoValida(pos) && casaLivre(pos)) {
                mat[pos.linha, pos.coluna] = true;
                pos.linha++;
                pos.coluna--;
            }

            // Testando casas sudoeste após peça adversária
            for (int i = 1; i <= tab.linhas; i++) {
                pos.definirValores(posicao.linha + i, posicao.coluna - i);
                if (tab.posicaoValida(pos) && existeInimigo(pos)) {
                    pos.definirValores(posicao.linha + (i + 1), posicao.coluna - (i + 1));
                    while (tab.posicaoValida(pos) && casaLivre(pos)) {
                        mat[pos.linha, pos.coluna] = true;
                        pos.linha++;
                        pos.coluna--;
                    }
                    break;
                }
            }

            // Testando casas noroeste livres
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
            while (tab.posicaoValida(pos) && casaLivre(pos)) {
                mat[pos.linha, pos.coluna] = true;
                pos.linha--;
                pos.coluna--;
            }

            // Testando casas noroeste após peça adversária
            for (int i = 1; i <= tab.linhas; i++) {
                pos.definirValores(posicao.linha - i, posicao.coluna - i);
                if (tab.posicaoValida(pos) && existeInimigo(pos)) {
                    pos.definirValores(posicao.linha - (i + 1), posicao.coluna - (i + 1));
                    while (tab.posicaoValida(pos) && casaLivre(pos)) {
                        mat[pos.linha, pos.coluna] = true;
                        pos.linha--;
                        pos.coluna--;
                    }
                    break;
                }
            }

            return mat;
        }
    }
}
