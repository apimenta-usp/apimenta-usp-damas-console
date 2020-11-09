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

        private void colocarPecas(int tamanho) {
            if(tamanho == 6) {
            //tab.colocarPeca(new Comum(tab, Cor.Branca), new PosicaoDamas('a', 1).toPosicao(tamanho));
            //tab.colocarPeca(new Comum(tab, Cor.Branca), new PosicaoDamas('f', 2).toPosicao(tamanho));

            } else if (tamanho == 8) { 
            tab.colocarPeca(new Comum(tab, Cor.Branca), new PosicaoDamas('a', 1).toPosicao());
            tab.colocarPeca(new Comum(tab, Cor.Branca), new PosicaoDamas('f', 2).toPosicao());
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
