using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadrexConsole.tabuleiro;

namespace XadrexConsole.Xadrez
{
    class PartidaDeXadrex
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<peca> pecas;
        private HashSet<peca> capturadas;

        public PartidaDeXadrex()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.branca;
            terminada = false;
            pecas = new HashSet<peca>();
            capturadas = new HashSet<peca>();
            colocarPecas();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            peca p = tab.retirarPeca(origem);
            p.IncrementarQteMovimentos();
            peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
            //PEGA AS PEÇAS CAPTURADAS
            if (pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            turno++;
            mudaJogador();
        }

        private void mudaJogador()
        {
            if (jogadorAtual == Cor.branca)
            {
                jogadorAtual = Cor.preta;
            }
            else
            {
                jogadorAtual = Cor.branca;
            }
        }

        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if (tab.Peca(pos) == null)
            {
                throw new TabuleiroException("Não tem peça meu parcero");
            }
            if (jogadorAtual != tab.Peca(pos).cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua !");
            }
            if (!tab.Peca(pos).existemMovimentosPossiveis())
            {
                throw new TabuleiroException("não há movimentos possíveis para a peça escolhida");
            }
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!tab.Peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroException("Posição invalida !!");
            }
        }
        
        //ULTILIZA PEÇAS CAPTURADAS
        public HashSet<peca> pecasCapturadas(Cor cor)
        {
            HashSet<peca> aux = new HashSet<peca>();
            foreach (peca x in capturadas)
            {
                if(x.cor == cor)
                {
                    aux.Add(x);
                }
                
            }
            return aux;
        }

        public HashSet<peca> pecasEmJogo(Cor cor)
        {
            HashSet<peca> aux = new HashSet<peca>();
            foreach (peca x in pecas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
                return aux;
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }
        public void colocarNovaPeca(char coluna, int linha, peca peza)
        {
            tab.colocarPeca(peza, new PosicaoXadrez(coluna,linha).toPosicao());
            pecas.Add(peza);
        }
        private void colocarPecas()
        {
            colocarNovaPeca('c', 1, new Torre(tab, Cor.branca));
            colocarNovaPeca('c', 2, new Torre(tab, Cor.branca));
            colocarNovaPeca('d', 2, new Torre(tab, Cor.branca));
            colocarNovaPeca('e', 2, new Torre(tab, Cor.branca));
            colocarNovaPeca('e', 1, new Torre(tab, Cor.branca));
            colocarNovaPeca('d', 1, new Rei(tab, Cor.branca));

            colocarNovaPeca('c', 7, new Torre(tab, Cor.preta));
            colocarNovaPeca('c', 8, new Torre(tab, Cor.preta));
            colocarNovaPeca('d', 7, new Torre(tab, Cor.preta));
            colocarNovaPeca('e', 7, new Torre(tab, Cor.preta));
            colocarNovaPeca('e', 8, new Torre(tab, Cor.preta));
            colocarNovaPeca('d', 8, new Rei(tab, Cor.preta));
           
            
        }
    }
}
