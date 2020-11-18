using System;
using System.Collections.Generic;
using tabuleiro;

namespace damas {
    class PartidaDeDamas {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        //public int tamanho { get; private set; }

        public PartidaDeDamas(int tamanho) {
            //this.tamanho = tamanho;
            //tab = new Tabuleiro(this.tamanho, this.tamanho);
            tab = new Tabuleiro(tamanho, tamanho);
            //tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            //colocarPecas(this.tamanho);
            colocarPecas(tamanho);
        }

        public Peca executarMovimento(Posicao origem, Posicao destino) {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQteMovimentos();
            tab.colocarPeca(p, destino);
            Peca pecaCapturada = capturarPeca(origem, destino);
            if (pecaCapturada != null) {
                capturadas.Add(pecaCapturada);
            }

            return pecaCapturada;
        }

        public void realizarJogada(Posicao origem, Posicao destino) {
            //executarMovimento(origem, destino);
            Peca pecaCapturada = executarMovimento(origem, destino);

            //Peca p = tab.peca(destino);

            turno++;
            mudarJogador();
        }

        private bool existeAdversario(Posicao pos) {
            Peca p = tab.peca(pos);
            return p != null && p.cor != jogadorAtual;
        }
        
        private Peca capturarPeca(Posicao origem, Posicao destino) {
            int diferencaLinha = destino.linha - origem.linha;
            int diferencaColuna = destino.coluna - origem.coluna;
            Posicao pos = new Posicao(0, 0);

            if (diferencaLinha == 0 || Math.Abs(diferencaLinha) == 1 ||
                diferencaColuna == 0 || Math.Abs(diferencaColuna) == 1) {
                return null;
            }

            if (diferencaLinha < -1 && diferencaColuna > 1) {
                for (int i = 1; i < Math.Abs(diferencaLinha); i++) {
                    pos.definirValores(origem.linha - i, origem.coluna + i);
                    Peca aux = tab.peca(pos);

                    if (tab.posicaoValida(pos) && existeAdversario(pos)) {
                        aux.posicao = null;
                        tab.pecas[pos.linha, pos.coluna] = null;
                        return aux;
                    }
                }
            }

            if (diferencaLinha > 1 && diferencaColuna < -1) {
                for (int i = 1; i < Math.Abs(diferencaLinha); i++) {
                    pos.definirValores(origem.linha + i, origem.coluna - i);
                    Peca aux = tab.peca(pos);

                    if (tab.posicaoValida(pos) && existeAdversario(pos)) {
                        aux.posicao = null;
                        tab.pecas[pos.linha, pos.coluna] = null;
                        return aux;
                    }
                }
            }

            if (diferencaLinha > 1 && diferencaColuna > 1) {
                for (int i = 1; i < Math.Abs(diferencaLinha); i++) {
                    pos.definirValores(origem.linha + i, origem.coluna + i);
                    Peca aux = tab.peca(pos);

                    if (tab.posicaoValida(pos) && existeAdversario(pos)) {
                        aux.posicao = null;
                        tab.pecas[pos.linha, pos.coluna] = null;
                        return aux;
                    }
                }
            }

            if (diferencaLinha < -1 && diferencaColuna < -1) {
                for (int i = 1; i < Math.Abs(diferencaLinha); i++) {
                    pos.definirValores(origem.linha - i, origem.coluna - i);
                    Peca aux = tab.peca(pos);

                    if (tab.posicaoValida(pos) && existeAdversario(pos)) {
                        aux.posicao = null;
                        tab.pecas[pos.linha, pos.coluna] = null;
                        return aux;
                    }
                }
            }

            return null;
        }

        public void validarPosicaoDeOrigem(Posicao pos) {
            if (tab.peca(pos) == null) {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if (jogadorAtual != tab.peca(pos).cor) {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!tab.peca(pos).existemMovimentosPossiveis()) {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino) {
            if (!tab.peca(origem).movimentoPossivel(destino)) {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        private void mudarJogador() {
            if (jogadorAtual == Cor.Branca) {
                jogadorAtual = Cor.Preta;
            } else {
                jogadorAtual = Cor.Branca;
            }
        }

        public HashSet<Peca> pecasCapturadas(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas) {
                if (x.cor == cor) {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas) {
                if (x.cor == cor) {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }

        public void colocarNovaPeca(Peca peca, char coluna, int linha) {
            tab.colocarPeca(peca, new PosicaoDamas(coluna, linha).toPosicao());
            pecas.Add(peca);
        }

        private void colocarPecas(int tamanho) {
            switch (tamanho) {
                case 6:
                    //tab.colocarPeca(new Comum(tab, Cor.Branca), new PosicaoDamas('a', 1).toPosicao(tamanho));
                    //tab.colocarPeca(new Comum(tab, Cor.Branca), new PosicaoDamas('f', 2).toPosicao(tamanho));
                    break;
                case 8:
                    //tab.colocarPeca(new Comum(tab, Cor.Branca), new PosicaoDamas('a', 1).toPosicao());
                    //tab.colocarPeca(new Comum(tab, Cor.Branca), new PosicaoDamas('e', 3).toPosicao());
                    //tab.colocarPeca(new Dama(tab, Cor.Branca), new PosicaoDamas('f', 6).toPosicao());
                    //tab.colocarPeca(new Comum(tab, Cor.Branca), new PosicaoDamas('b', 2).toPosicao());
                    //tab.colocarPeca(new Comum(tab, Cor.Preta), new PosicaoDamas('b', 8).toPosicao());
                    //tab.colocarPeca(new Comum(tab, Cor.Preta), new PosicaoDamas('a', 7).toPosicao());
                    //tab.colocarPeca(new Comum(tab, Cor.Preta), new PosicaoDamas('d', 2).toPosicao());
                    //tab.colocarPeca(new Dama(tab, Cor.Preta), new PosicaoDamas('d', 4).toPosicao());

                    colocarNovaPeca(new Dama(tab, Cor.Branca), 'd', 4);
                    colocarNovaPeca(new Comum(tab, Cor.Branca), 'b', 2);
                    colocarNovaPeca(new Comum(tab, Cor.Preta), 'b', 6);
                    colocarNovaPeca(new Comum(tab, Cor.Preta), 'c', 3);
                    colocarNovaPeca(new Dama(tab, Cor.Preta), 'g', 1);
                    colocarNovaPeca(new Dama(tab, Cor.Preta), 'g', 7);
                    break;
                case 10:
                    //tab.colocarPeca(new Dama(tab, Cor.Branca), new PosicaoDamas('e', 5).toPosicao());
                    //tab.colocarPeca(new Comum(tab, Cor.Preta), new PosicaoDamas('b', 8).toPosicao());
                    //tab.colocarPeca(new Comum(tab, Cor.Preta), new PosicaoDamas('d', 4).toPosicao());
                    //tab.colocarPeca(new Dama(tab, Cor.Preta), new PosicaoDamas('g', 7).toPosicao());
                    //tab.colocarPeca(new Dama(tab, Cor.Preta), new PosicaoDamas('i', 1).toPosicao());
                    //tab.colocarPeca(new Comum(tab, Cor.Branca), new PosicaoDamas('a', 1).toPosicao(tamanho));
                    //tab.colocarPeca(new Comum(tab, Cor.Branca), new PosicaoDamas('f', 2).toPosicao(tamanho));
                    break;
                default:
                    throw new TabuleiroException("Tamanho inválido!");
            }

            //if (tamanho == 6) {
            ////tab.colocarPeca(new Comum(tab, Cor.Branca), new PosicaoDamas('a', 1).toPosicao(tamanho));
            ////tab.colocarPeca(new Comum(tab, Cor.Branca), new PosicaoDamas('f', 2).toPosicao(tamanho));

            //} else if (tamanho == 8) { 
            //tab.colocarPeca(new Comum(tab, Cor.Branca), new PosicaoDamas('a', 1).toPosicao());
            //tab.colocarPeca(new Comum(tab, Cor.Branca), new PosicaoDamas('e', 3).toPosicao());
            //tab.colocarPeca(new Dama(tab, Cor.Branca), new PosicaoDamas('f', 6).toPosicao());
            //tab.colocarPeca(new Comum(tab, Cor.Branca), new PosicaoDamas('b', 2).toPosicao());
            //tab.colocarPeca(new Comum(tab, Cor.Preta), new PosicaoDamas('b', 8).toPosicao());
            //tab.colocarPeca(new Comum(tab, Cor.Preta), new PosicaoDamas('a', 7).toPosicao());
            //tab.colocarPeca(new Comum(tab, Cor.Preta), new PosicaoDamas('d', 2).toPosicao());
            //tab.colocarPeca(new Dama(tab, Cor.Preta), new PosicaoDamas('d', 4).toPosicao());
            //} else if(tamanho == 10) {
            ////tab.colocarPeca(new Comum(tab, Cor.Branca), new PosicaoDamas('a', 1).toPosicao(tamanho));
            ////tab.colocarPeca(new Comum(tab, Cor.Branca), new PosicaoDamas('f', 2).toPosicao(tamanho));

            //} else {
            //    throw new TabuleiroException("Tamanho inválido!");
            //}
        }
    }
}
