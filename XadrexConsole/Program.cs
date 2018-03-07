using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadrexConsole.tabuleiro;
using XadrexConsole.Xadrez;

namespace XadrexConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab;
            tab = new Tabuleiro(8,8);

            tab.colocarPeca(new Torre(tab, Cor.preta), new Posicao(0, 0));
            tab.colocarPeca(new Torre(tab, Cor.preta), new Posicao(1, 3));
            tab.colocarPeca(new Rei(tab, Cor.preta), new Posicao(2, 4));

            Tela.imprimirTabuleiro(tab);
            Console.ReadLine();
        }
    }
}
