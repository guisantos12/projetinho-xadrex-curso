﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadrexConsole.tabuleiro;

namespace XadrexConsole.Xadrez
{
    class Rei:peca
    {
        public Rei(Tabuleiro tab, Cor cor ) : base(tab, cor)
        {

        }

        public override string ToString()
        {
            return "R";
        }
    }
}
