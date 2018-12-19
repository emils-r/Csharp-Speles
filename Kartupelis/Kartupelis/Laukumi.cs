using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kartupelis
{
    class Laukumi
    {
        
        public static void Laukums(String[,] b)
        {
            String rinda1 = "   |K|A|R|T|U|P|E|L|I|S|";
            String a = "|";
            String rindaElementi1 = "  " + a + b[0, 0] + a + b[0, 1] + a + b[0, 2] + a + b[0, 3] + a + b[0, 4] + a + b[0, 5] + a + b[0, 6] + a + b[0, 7] + a + b[0, 8] + a + b[0, 9] + a;
            String rindaElementi2 = "  " + a + b[1, 0] + a + b[1, 1] + a + b[1, 2] + a + b[1, 3] + a + b[1, 4] + a + b[1, 5] + a + b[1, 6] + a + b[1, 7] + a + b[1, 8] + a + b[1, 9] + a;
            String rindaElementi3 = "  " + a + b[2, 0] + a + b[2, 1] + a + b[2, 2] + a + b[2, 3] + a + b[2, 4] + a + b[2, 5] + a + b[2, 6] + a + b[2, 7] + a + b[2, 8] + a + b[2, 9] + a;
            String rindaElementi4 = "  " + a + b[3, 0] + a + b[3, 1] + a + b[3, 2] + a + b[3, 3] + a + b[3, 4] + a + b[3, 5] + a + b[3, 6] + a + b[3, 7] + a + b[3, 8] + a + b[3, 9] + a;
            String rindaElementi5 = "  " + a + b[4, 0] + a + b[4, 1] + a + b[4, 2] + a + b[4, 3] + a + b[4, 4] + a + b[4, 5] + a + b[4, 6] + a + b[4, 7] + a + b[4, 8] + a + b[4, 9] + a;
            String rindaElementi6 = "  " + a + b[5, 0] + a + b[5, 1] + a + b[5, 2] + a + b[5, 3] + a + b[5, 4] + a + b[5, 5] + a + b[5, 6] + a + b[5, 7] + a + b[5, 8] + a + b[5, 9] + a;
            String rindaElementi7 = "  " + a + b[6, 0] + a + b[6, 1] + a + b[6, 2] + a + b[6, 3] + a + b[6, 4] + a + b[6, 5] + a + b[6, 6] + a + b[6, 7] + a + b[6, 8] + a + b[6, 9] + a;
            String rindaElementi8 = "  " + a + b[7, 0] + a + b[7, 1] + a + b[7, 2] + a + b[7, 3] + a + b[7, 4] + a + b[7, 5] + a + b[7, 6] + a + b[7, 7] + a + b[7, 8] + a + b[7, 9] + a;
            String rindaElementi9 = "  " + a + b[8, 0] + a + b[8, 1] + a + b[8, 2] + a + b[8, 3] + a + b[8, 4] + a + b[8, 5] + a + b[8, 6] + a + b[8, 7] + a + b[8, 8] + a + b[8, 9] + a;
            String rindaElementi10 = " " + a + b[9, 0] + a + b[9, 1] + a + b[9, 2] + a + b[9, 3] + a + b[9, 4] + a + b[9, 5] + a + b[9, 6] + a + b[9, 7] + a + b[9, 8] + a + b[9, 9] + a;
            String rinda0 = "------------------------";
            
            Console.WriteLine(rinda1);
            Console.WriteLine(rinda0);
            Console.WriteLine(1 + rindaElementi1);
            Console.WriteLine(rinda0);
            Console.WriteLine(2 + rindaElementi2);
            Console.WriteLine(rinda0);
            Console.WriteLine(3 + rindaElementi3);
            Console.WriteLine(rinda0);
            Console.WriteLine(4 + rindaElementi4);
            Console.WriteLine(rinda0);
            Console.WriteLine(5 + rindaElementi5);
            Console.WriteLine(rinda0);
            Console.WriteLine(6 + rindaElementi6);
            Console.WriteLine(rinda0);
            Console.WriteLine(7 + rindaElementi7);
            Console.WriteLine(rinda0);
            Console.WriteLine(8 + rindaElementi8);
            Console.WriteLine(rinda0);
            Console.WriteLine(9 + rindaElementi9);
            Console.WriteLine(rinda0);
            Console.WriteLine(10 + rindaElementi10);
            Console.WriteLine(rinda0);
        }
    }
}
