using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kartupelis
{
    class Ievade
    {
        public static String[,] laukums1 = new string[10, 10]; // 1. spēlētāja laukums ar ievadītajiem kuģiem
        public static String[,] laukumsIevade1 = new string[10, 10]; // 1. spēlētāja ievades laukums 
        public static String[,] laukums2 = new string[10, 10]; // 2. spēlētāja laukums ar kuģiem
        public static String[,] laukumsIevade2 = new string[10, 10]; // 2. spēlētāja ievade

        public static void LaukumaIevade(String[,] laukums)
        {

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    laukums[i, j] = " ";

                }

            }
        }

        public static int sp1k1 = 0; // spēlētājs 1 kuģis ar izmēru 1
        public static int sp1k2 = 0; // spēlētājs 1 kuģis ar izmēru 2 u.t.t.
        public static int sp1k3 = 0;
        public static int sp1k4 = 0;

        public static void SpeletajaIevade(int nr, String[,] laukums)
        {

            do
            {

                Console.WriteLine("********   " + nr + ". speletajs ievada savus kugus   ********");

                // Jāpievieno kuģa ievade horizontāli vai vertikāli
                // by default kuģis horizontāls

                Console.WriteLine("Ievadiet kuģa garumu:"); // no 1 līdz 4
                int g = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ievadiet sakumpunkta rindu:");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ievadiet sakumpunkta kolonnu:");
                int y = Convert.ToInt32(Console.ReadLine());
                
                switch (g)
                {
                    case 1:
                        {
                            laukums[x - 1, y - 1] = "X"; 
                            sp1k1++;           // jānosaka arī limits kuģu ievadei ar if
                            break;
                        }
                    case 2:
                        {
                            laukums[x - 1, y - 1] = "X";
                            laukums[x - 1, y] = "X"; // ievada arī blakus lauciņu
                            sp1k2++;
                            break;
                        }
                    case 3:
                        {
                            laukums[x - 1, y - 1] = "X";
                            laukums[x - 1, y] = "X";
                            laukums[x - 1, y + 1] = "X";
                            sp1k3++;
                            break;
                        }
                    case 4:
                        {
                            laukums[x - 1, y - 1] = "X";
                            laukums[x - 1, y] = "X";
                            laukums[x - 1, y + 1] = "X";
                            laukums[x - 1, y + 2] = "X";
                            sp1k4++;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Ievadīts nepareizs kuģa izmērs");
                            break;
                        }
                }

                Laukumi.Laukums(laukums);

            } while (/*sp1k1 < 4 || sp1k2 < 3 || sp1k3 < 2 ||*/ sp1k4 < 1); // komentārs kamēr spēli testējam
            
        }

        public static void Gajiens(int nr, String[,] laukums, String[,] laukumsIevade) // jāpievieno pretinieku laukumi 
        {
            bool trapijums; // nosaka vai gājiena laikā ir trāpīts, ja true - Gajiens atkārtojas

            Console.WriteLine("***************************************");
            Console.WriteLine("********   " + nr + ". spēlētājs sauj   ********");
            Console.WriteLine("Līdz šim sašauts:");
            Console.WriteLine(); // atstarpe
            Laukumi.Laukums(laukumsIevade); // parāda līdzšinējo laukumu pirms šaušanas
            Console.WriteLine(); // atstarpe

            do
            {
                
                Console.WriteLine("Ievadiet saviena rindu:");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ievadiet saviena kolonnu:");
                int y = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                if (laukums[x - 1, y - 1] == "X") // pārbauda pretinieka laukumu, vai tajā vietā ir kuģis
                {
                    laukumsIevade[x - 1, y - 1] = "X"; // trāpijumā aizvieto Ievades laukuma konkrēto vietu ar X
                    trapijums = true;
                    
                    Console.WriteLine("****   TRAPITS   ****");
                }
                else
                {
                    laukumsIevade[x - 1, y - 1] = "O"; // ja netrāpa - Ievades laukumu aizvieto ar O
                    trapijums = false;
                }
                
                Console.WriteLine("Laukums pēc šāviena:");
                Laukumi.Laukums(laukumsIevade); // izvada laukumu pēc šāviena 
                Console.WriteLine();

            } while (trapijums == true);

        }

        public static void Spelet()
        {
            int gajiens = 1;

            do
            {
                if (gajiens == 1)
                {
                    Gajiens(1, laukums2, laukumsIevade1); // gājiens 1. spēlētājam
                    gajiens++;
                }
                else
                {
                    Gajiens(2, laukums1, laukumsIevade2); // gājiens 2. spēlētājam
                    gajiens--;
                }

            } while (true); // pagaidām kamēr spēli testējam
        }

    }
}
