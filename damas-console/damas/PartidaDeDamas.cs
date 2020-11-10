using System.Collections.Generic;
using tabuleiro;

namespace damas {
    class PartidaDeDamas {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        //public int tamanho { get; private set; }
        
        public PartidaDeDamas(int tamanho) {
            //this.tamanho = tamanho;
            //tab = new Tabuleiro(this.tamanho, this.tamanho);
            tab = new Tabuleiro(tamanho, tamanho);
            //tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            //colocarPecas(this.tamanho);
            colocarPecas(tamanho);
        }

        public void executarMovimento(Posicao origem, Posicao destino) {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQteMovimentos();
            //Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
            //if (pecaCapturada != null) {
            //    capturadas.Add(pecaCapturada);
            //}

            //return pecaCapturada;
        }

        public void realizarJogada(Posicao origem, Posicao destino) {
            executarMovimento(origem, destino);
            //Peca pecaCapturada = executarMovimento(origem, destino);

            Peca p = tab.peca(destino);

            turno++;
            mudarJogador();
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

        private void colocarPecas(int tamanho) {
            if(tamanho == 6) {
            //tab.colocarPeca(new Comum(tab, Cor.Branca), new PosicaoDamas('a', 1).toPosicao(tamanho));
            //tab.colocarPeca(new Comum(tab, Cor.Branca), new PosicaoDamas('f', 2).toPosicao(tamanho));

            } else if (tamanho == 8) { 
            tab.colocarPeca(new Comum(tab, Cor.Branca), new PosicaoDamas('a', 1).toPosicao());
            tab.colocarPeca(new Comum(tab, Cor.Branca), new PosicaoDamas('f', 2).toPosicao());
            tab.colocarPeca(new Dama(tab, Cor.Branca), new PosicaoDamas('f', 6).toPosicao());
            tab.colocarPeca(new Comum(tab, Cor.Branca), new PosicaoDamas('b', 2).toPosicao());
            tab.colocarPeca(new Comum(tab, Cor.Preta), new PosicaoDamas('b', 8).toPosicao());
            tab.colocarPeca(new Comum(tab, Cor.Preta), new PosicaoDamas('a', 7).toPosicao());
            tab.colocarPeca(new Dama(tab, Cor.Preta), new PosicaoDamas('d', 4).toPosicao());
            } else if(tamanho == 10) {
            //tab.colocarPeca(new Comum(tab, Cor.Branca), new PosicaoDamas('a', 1).toPosicao(tamanho));
            //tab.colocarPeca(new Comum(tab, Cor.Branca), new PosicaoDamas('f', 2).toPosicao(tamanho));

            } else {
                throw new TabuleiroException("Tamanho inválido!");
            }
        }
    }
}
