using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadrexConsole.tabuleiro;

namespace XadrexConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab;
            tab = new Tabuleiro(8,8);

            Tela.imprimirTabuleiro(tab);
            Console.ReadLine();
        }
    }
}
