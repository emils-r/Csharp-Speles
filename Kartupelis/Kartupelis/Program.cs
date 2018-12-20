using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kartupelis
{
    class Program
    {
        static void Main(string[] args)
        {
            // izveido visus laukumus un aizpilda ar " " 
            Ievade.LaukumaIevade(Ievade.laukums1); // 1. spēlētāja laukums ievadīts ar " "
            Ievade.LaukumaIevade(Ievade.laukums2); // 2. spēlētāja laukums ievadīts ar " "
            Ievade.LaukumaIevade(Ievade.laukumsIevade1); // izveido 1. spēlētāja ievades laukumu
            Ievade.LaukumaIevade(Ievade.laukumsIevade2); // izveido 2. spēlētāja ievades laukumu
            
            // sākas spēle, no šejienes atveras konsole
            Console.WriteLine("***********   KUGI   ************\n");
            Laukumi.Laukums(Ievade.laukums1); // kā paraugs parādīts spēles sākumā
            At();

            // spēlētāji ievada savus kuģus
            Ievade.SpeletajaIevade(1, Ievade.laukums1); // 1. spēlētājs ievada kuģus
            At();
            Console.WriteLine("***   1. spēlētājs laukumu ir ievadījis   ***\n");
            Laukumi.Laukums(Ievade.laukums2); // 2. spēlētāja laukums kā paraugs pirms kuģu ievadīšanas
            At();

            Ievade.kugis1 = 0; // reseto kuģu skaitītāju
            Ievade.kugis2 = 0;
            Ievade.kugis3 = 0;
            Ievade.kugis4 = 0;
            Ievade.SpeletajaIevade(2, Ievade.laukums2); // 2. spēlētājs ievada kuģus

            At();
            At();
            At();
            Console.WriteLine("***   Visi kuģi ir ievadīti! Laiks vinus sašaut! ***\n");

            // notiek gājieni (šaušana)
            Ievade.Spelet();
            

            Console.ReadKey();
        }

        public static void At()
        {
            Console.WriteLine();
        }
    }
}
