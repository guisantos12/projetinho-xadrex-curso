using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XadrexConsole.tabuleiro
{
    class peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimento { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        public peca(Posicao posicao, Tabuleiro tabi, Cor cor)
        {
            this.posicao = posicao;
            this.tab = tabi;
            this.cor = cor;
            this.qteMovimento = 0;
        }
    }
}
