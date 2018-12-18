using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desas
{
    class Laukums
    {
        public static void LaukumsRindas()
        {
            String rinda1 = "1   |2   |3   ";
            String rinda4 = "4   |5   |6   ";
            String rinda7 = "7   |8   |9   ";

            String rinda123 = "  " + Rezultats.ievade[0] + " |  " + Rezultats.ievade[1] + " |  " + Rezultats.ievade[2];
            String rinda456 = "  " + Rezultats.ievade[3] + " |  " + Rezultats.ievade[4] + " |  " + Rezultats.ievade[5];
            String rinda789 = "  " + Rezultats.ievade[6] + " |  " + Rezultats.ievade[7] + " |  " + Rezultats.ievade[8];

            String rindaStarp1 = "    |    |    ";
            String rindaStarp2 = "--------------";

            Console.WriteLine(rinda1);
            Console.WriteLine(rinda123);
            Console.WriteLine(rindaStarp1);
            Console.WriteLine(rindaStarp2);
            Console.WriteLine(rinda4);
            Console.WriteLine(rinda456);
            Console.WriteLine(rindaStarp1);
            Console.WriteLine(rindaStarp2);
            Console.WriteLine(rinda7);
            Console.WriteLine(rinda789);
            Console.WriteLine(rindaStarp1);
            Console.WriteLine();
            
        }
        
    }
}
