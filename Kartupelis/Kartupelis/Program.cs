using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kugi
{
    class Program
    {
        static void Main(string[] args)
        {
            String atkartot; // spēles atkārtošanai
            do
            {
                // reseto punktu skaitu
                Ievade.punkti1 = 0;
                Ievade.punkti2 = 0;

                // reseto kuģu skaitītāju
                Ievade.kugis1 = 0; 
                Ievade.kugis2 = 0;
                Ievade.kugis3 = 0;
                Ievade.kugis4 = 0;

                // izveido visus laukumus un aizpilda ar " " 
                Ievade.LaukumaIevade(Ievade.laukums1); // 1. spēlētāja laukums 
                Ievade.LaukumaIevade(Ievade.laukums2); // 2. spēlētāja laukums 
                Ievade.LaukumaIevade(Ievade.laukumsIevade1); // 1. spēlētāja ievades laukums
                Ievade.LaukumaIevade(Ievade.laukumsIevade2); // 2. spēlētāja ievades laukums

                // sākas spēle, no šejienes atveras konsole
                Console.WriteLine("***********   KUGI   ************\n\n");

                // spēlētāji ievada savus vārdus
                Console.WriteLine("\n\n1. spēlētājs ievada savu vārdu:");
                Ievade.speletajs1 = Console.ReadLine();
                Console.WriteLine("\n2. spēlētājs ievada savu vārdu:");
                Ievade.speletajs2 = Console.ReadLine();

                // spēlētāji ievada savus kuģus
                Ievade.SpeletajaIevade(1, Ievade.laukums1, Ievade.speletajs1); // 1. spēlētājs ievada kuģus
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n***   " + Ievade.speletajs1 + " laukums ir ievadīts   ***\n");

                // reseto kuģu skaitītājus pirms 2. spēlētāja ievades
                Ievade.kugis1 = 0; 
                Ievade.kugis2 = 0;
                Ievade.kugis3 = 0;
                Ievade.kugis4 = 0;
                
                Ievade.SpeletajaIevade(2, Ievade.laukums2, Ievade.speletajs2); // 2. spēlētājs ievada kuģus
                
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n***   Visi kuģi ir ievadīti! Laiks vinus sašaut! ***\n");

                // notiek gājieni (šaušana)
                Ievade.Spelet();

                // pēc kāda spēlētāja uzvaras piedāvā atkārtot spēli
                Console.WriteLine("Spēle beigusies! Raksi 'yes', lai atkārtotu!");
                atkartot = Console.ReadLine();

            } while (atkartot == "yes");
            Console.ReadKey();
        }
    }
}
