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

            Ievade.LaukumaIevade(Ievade.laukums1); // 1. spēlētāja laukums
            Laukumi.Laukums(Ievade.laukums1); // 1. spēlētāja laukums

            Console.WriteLine();

            Ievade.SpeletajaIevade(); // japievieno parametri - kurš spēlētājs ievada un tā paša spēlētāja laukums

            Ievade.LaukumaIevade(Ievade.laukumsIevade1); // izveido 1. spēlētāja ievades laukumu

            Console.WriteLine(); // pagaidu
            Console.WriteLine(); // pagaidu
            Console.WriteLine(); // pagaidu

            Console.WriteLine("Visi kuģi ir ievadīti! Laiks vinus sašaut! ");
            Laukumi.Laukums(Ievade.laukumsIevade1); // principā parāda tukšu laukumu

            Ievade.Spelet();
            

            Console.ReadKey();
        }
    }
}
