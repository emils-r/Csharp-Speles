using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desas
{
    class Rezultats
    {
        public static String[] ievade = new string[9];
        public static bool status = false;
        public static int karta = 0;

        public static void Ievade()
        {
            for (int i = 0; i < ievade.Length; i++)
            {
                ievade[i] = "-";
            }
        }

        public static void Gajiens()
        {
            if (karta == 0)
            {
                GajienaDarbiba(1, "O");
                karta++;
            }
            else
            {
                GajienaDarbiba(2, "X");
                karta--;
            }
        }

        public static void GajienaDarbiba(int x, String a)
        {
            Console.WriteLine("Gajiens " + x + ". spēlētājam! Ievadi laucinu no 1 līdz 9:");
            bool pareiziba;
            do
            {
                int input = Convert.ToInt32(Console.ReadLine());

                if (ievade[input-1] == "O" || ievade[input-1] == "X")
                {
                    Console.WriteLine();
                    Console.WriteLine("LAUCINS JAU IR AIZNEMTS, " + x + ". speletajam jaievada velreiz:");
                    pareiziba = false;
                }
                else
                {
                    ievade[input - 1] = a;
                    pareiziba = true;
                }
            } while (pareiziba == false);

            Console.WriteLine();
            Console.WriteLine("Aktualais laukums:");
            Laukums.LaukumsRindas();

            status = Uzvara();
            if (status)
            {
                Console.WriteLine("SPELE BEIGUSIES! " + x + ". SPELETAJS UZVAR!!!");
            }
        }

        public static bool Uzvara()
        {
            bool uzv1 = ievade[0] == ievade[1] && ievade[0] == ievade[2] && ievade[0] != "-";
            bool uzv2 = ievade[3] == ievade[4] && ievade[3] == ievade[5] && ievade[3] != "-";
            bool uzv3 = ievade[6] == ievade[7] && ievade[6] == ievade[8] && ievade[6] != "-";
            bool uzv4 = ievade[0] == ievade[3] && ievade[0] == ievade[6] && ievade[0] != "-";
            bool uzv5 = ievade[1] == ievade[4] && ievade[1] == ievade[7] && ievade[1] != "-";
            bool uzv6 = ievade[2] == ievade[5] && ievade[2] == ievade[8] && ievade[2] != "-";
            bool uzv7 = ievade[0] == ievade[4] && ievade[0] == ievade[8] && ievade[0] != "-";
            bool uzv8 = ievade[2] == ievade[4] && ievade[2] == ievade[6] && ievade[2] != "-";

            if (uzv1 || uzv2 || uzv3 || uzv4 || uzv5 || uzv6 || uzv7 || uzv8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
