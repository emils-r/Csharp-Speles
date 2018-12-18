using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desas
{
    class Program
    {
        static void Main(string[] args)
        {
            String atbilde;
            do
            {
                Console.WriteLine("Spelejam desas! Speles laukums sakuma:");
                Console.WriteLine();

                Rezultats.Ievade();
                Laukums.LaukumsRindas();

                Console.WriteLine("1. speletajs ir O; 2. speletajs ir X");
                Console.WriteLine();

                int skaititajs = 0;
                do
                {
                    Rezultats.Gajiens();
                    skaititajs++;

                    if (skaititajs == 9)
                    {
                        Console.WriteLine("NEIZSKIRTS!!");
                        break;
                    }

                } while (Rezultats.status == false);

                Console.WriteLine();
                Console.WriteLine("Raksti 'yes', lai velreiz speletu desas!");
                atbilde = Console.ReadLine();
                Console.WriteLine();

            } while (atbilde == "yes");
            
        }
    }
}
