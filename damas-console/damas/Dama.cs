using tabuleiro;

namespace damas {
    class Dama : Peca {
        public Dama(Tabuleiro tab, Cor cor) : base(tab, cor) {
        }

        public override string ToString() {
            return "D";
        }

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

            // Testando casas sudeste livres
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
            while (tab.posicaoValida(pos) && casaLivre(pos)) {
                mat[pos.linha, pos.coluna] = true;
                pos.linha++;
                pos.coluna++;
            }

            // Testando casas sudoeste livres
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            while (tab.posicaoValida(pos) && casaLivre(pos)) {
                mat[pos.linha, pos.coluna] = true;
                pos.linha++;
                pos.coluna--;
            }

            // Testando casas noroeste livres
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
            while (tab.posicaoValida(pos) && casaLivre(pos)) {
                mat[pos.linha, pos.coluna] = true;
                pos.linha--;
                pos.coluna--;
            }

            return mat;
        }

        public override bool[,] capturasPossiveis() {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            // Testando casas nordeste após peça adversária
            for (int i = 1; i <= tab.linhas; i++) {
                pos.definirValores(posicao.linha - i, posicao.coluna + i);
                if (tab.posicaoValida(pos) && existeAmigo(pos)) {
                    break;
                }
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

            // Testando casas sudeste após peça adversária
            for (int i = 1; i <= tab.linhas; i++) {
                pos.definirValores(posicao.linha + i, posicao.coluna + i);
                if (tab.posicaoValida(pos) && existeAmigo(pos)) {
                    break;
                }
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

            // Testando casas sudoeste após peça adversária
            for (int i = 1; i <= tab.linhas; i++) {
                pos.definirValores(posicao.linha + i, posicao.coluna - i);
                if (tab.posicaoValida(pos) && existeAmigo(pos)) {
                    break;
                }
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

            // Testando casas noroeste após peça adversária
            for (int i = 1; i <= tab.linhas; i++) {
                pos.definirValores(posicao.linha - i, posicao.coluna - i);
                if (tab.posicaoValida(pos) && existeAmigo(pos)) {
                    break;
                }
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

        public override bool[,] capturasPossiveis(SentidoDoMovimento movimentacao) {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            // Testando casas nordeste após peça adversária
            if (movimentacao != SentidoDoMovimento.Sudoeste) {
                for (int i = 1; i <= tab.linhas; i++) {
                    pos.definirValores(posicao.linha - i, posicao.coluna + i);
                    if (tab.posicaoValida(pos) && existeAmigo(pos)) {
                        break;
                    }
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
            }

            // Testando casas sudeste após peça adversária
            if (movimentacao != SentidoDoMovimento.Noroeste) {
                for (int i = 1; i <= tab.linhas; i++) {
                    pos.definirValores(posicao.linha + i, posicao.coluna + i);
                    if (tab.posicaoValida(pos) && existeAmigo(pos)) {
                        break;
                    }
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
            }

            // Testando casas sudoeste após peça adversária
            if (movimentacao != SentidoDoMovimento.Nordeste) {
                for (int i = 1; i <= tab.linhas; i++) {
                    pos.definirValores(posicao.linha + i, posicao.coluna - i);
                    if (tab.posicaoValida(pos) && existeAmigo(pos)) {
                        break;
                    }
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
            }

            // Testando casas noroeste após peça adversária
            if (movimentacao != SentidoDoMovimento.Sudeste) {
                for (int i = 1; i <= tab.linhas; i++) {
                    pos.definirValores(posicao.linha - i, posicao.coluna - i);
                    if (tab.posicaoValida(pos) && existeAmigo(pos)) {
                        break;
                    }
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
            }

            return mat;
        }
    }
}
