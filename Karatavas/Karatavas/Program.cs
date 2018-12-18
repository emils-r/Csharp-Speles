using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karatavas
{
    class Program
    {
        static void Main(string[] args)
        {
            String atbilde = "yes";
            do
            {
                Darbibas.ievadits = 0;
                Darbibas.VaditajaIevade();
                Darbibas.Gajiens();

                if (Darbibas.ievadits == Darbibas.ievade.Length)
                {
                    Console.WriteLine("Speletajs uzvar!");
                    Console.WriteLine();
                }

                Console.WriteLine("Raksti 'yes', lai atkārtotu");
                atbilde = Console.ReadLine();

            } while (atbilde == "yes");

            Console.ReadLine();
        }
    }
}
