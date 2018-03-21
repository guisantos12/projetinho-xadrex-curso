using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XadrexConsole.tabuleiro
{
    abstract class peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimento { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        public peca(Tabuleiro tabi, Cor cor)
        {
            this.posicao = null;
            this.tab = tabi;
            this.cor = cor;
            this.qteMovimento = 0;
        }

        public void IncrementarQteMovimentos()
        {
            qteMovimento++;
        }

        public bool existemMovimentosPossiveis()
        {
            bool[,] mat = movimentosPossiveis();
            for (int i =0;i<tab.linhas;i++)
            {
                for (int j =0;j<tab.colunas;j++)
                {
                    if (mat[i,j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public abstract bool[,] movimentosPossiveis();

        public bool podeMoverPara(Posicao pos)
        {
            return movimentosPossiveis()[pos.linha, pos.coluna];
        }
        
    }
}
