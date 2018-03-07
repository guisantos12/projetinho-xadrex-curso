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
            Posicao p;

            p = new Posicao(4, 5);

            Console.WriteLine("Posição: "+p);
            Console.ReadLine();
        }
    }
}
