using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public static int kugis1 = 0; // skaitītājs kuģim ar izmēru 1
        public static int kugis2 = 0; // skaitītāks kuģim ar izmēru 2 u.t.t.
        public static int kugis3 = 0;
        public static int kugis4 = 0;

        public static int g; // kuģa garums

        // Spēlētājs ievada kuģus savā laukumā
        public static void SpeletajaIevade(int nr, String[,] laukums)
        {
            bool ievadits = false;
            Console.WriteLine("********   " + nr + ". speletajs ievada savus kugus   ********");
            Console.WriteLine();
            do
            {
                // Jāpievieno kuģa ievade horizontāli vai vertikāli
                // by default kuģis horizontāls
                Console.WriteLine("Ievadiet kuģa garumu no 1 līdz 4:");
                do
                {
                    String temp = Console.ReadLine();
                    if (Regex.IsMatch(temp, @"^[0-9]+$")) // pārbauda vai tikai cipari ir ievadīti
                    {
                        g = Convert.ToInt32(temp); // ja tikai cipari - konvertē par integer
                    }

                    if (g < 5 && g > 0) // pārbauda vai ir starp 1 un 4
                    {
                        ievadits = true;
                    }
                    else
                    {
                        Console.WriteLine("Kļūda ievadē! Jaizvēlas kuga garums no 1 lidz 4, ievadiet garumu velreiz:");
                    }

                    bool parDaudzKugu = false;

                    switch (g) // pārbauda vai jau ir ievadīti kuģi ar noteikto garumu
                    {
                        case 1:
                            if (kugis1 == 4)
                            {
                                parDaudzKugu = true;
                            }
                            break;
                        case 2:
                            if (kugis2 == 3)
                            {
                                parDaudzKugu = true;
                            }
                            break;
                        case 3:
                            if (kugis3 == 2)
                            {
                                parDaudzKugu = true;
                            }
                            break;
                        case 4:
                            if (kugis4 == 1)
                            {
                                parDaudzKugu = true;
                            }
                            break;
                    }

                    if (parDaudzKugu == true)
                    {
                        Console.WriteLine("Kugi ar sadu izmeru jau ir ievaditi! Izvelies citu garumu: ");
                        ievadits = false;
                    }

                } while (ievadits == false);
                ievadits = false;

                // koordinātas kuģu ievadīšanai
                int x = 0; // piešķirta default vērtībā
                int y = 0;
                String kol = ""; // String prieks kolonnu ievades

                do
                {
                    try
                    {
                        Console.WriteLine("Ievadiet sakumpunkta rindu no 1 līdz 10");
                        String temp;

                        do
                        {
                            temp = Console.ReadLine();

                            if (Regex.IsMatch(temp, @"^[0-9]+$")) // pārbauda vai tikai cipari ir ievadīti
                            {
                                x = Convert.ToInt32(temp); // ja tikai cipari - konvertē par integer
                            }

                            if (x < 11 && x > 0)
                            {
                                ievadits = true;
                            }
                            else
                            {
                                Console.WriteLine("Kļūda ievadē! Jāievada skaitlis no 1 līdz 10:");
                                ievadits = false;
                            }
                        } while (ievadits == false);
                        ievadits = false;

                        Console.WriteLine("Ievadiet sakumpunkta kolonnu no K līdz S");
                        do
                        {
                            temp = Console.ReadLine();
                            if (Regex.IsMatch(temp, @"^[a-zA-Z]+$")) // pārbauda vai tikai burti ir ievadīti
                            {
                                kol = temp.ToUpper();
                                ievadits = true;
                            }
                            else
                            {
                                Console.WriteLine("Ievadits skaitlis, ievadiet kolonnas burtu no K lidz S vlereiz:");
                                ievadits = false;
                            }

                        } while (ievadits == false);
                        ievadits = false;

                        switch (kol)
                        {
                            case "K":
                                y = 1;
                                break;
                            case "A":
                                y = 2;
                                break;
                            case "R":
                                y = 3;
                                break;
                            case "T":
                                y = 4;
                                break;
                            case "U":
                                y = 5;
                                break;
                            case "P":
                                y = 6;
                                break;
                            case "E":
                                y = 7;
                                break;
                            case "L":
                                y = 8;
                                break;
                            case "I":
                                y = 9;
                                break;
                            case "S":
                                y = 10;
                                break;
                            default:
                                y = 11;
                                break;
                        }

                        if ((x > 0 && x < 11) && (y > 0 && y < 11))
                        {
                            ievadits = true;
                        }
                        else
                        {
                            ievadits = false;
                        }

                        bool jauAiznemts = false; // nosaka vai koordinātas ievadāmajam kuģim ir jau aizņemtas

                        switch (g)
                        {
                            case 1:
                                {
                                    if (laukums[x - 1, y - 1] != "X")
                                    {
                                        laukums[x - 1, y - 1] = "X";
                                        kugis1++;
                                    }
                                    else
                                    {
                                        jauAiznemts = true;
                                    }
                                    break;
                                }
                            case 2:
                                {
                                    if (laukums[x - 1, y - 1] == "X" || laukums[x - 1, y] == "X")
                                    {
                                        jauAiznemts = true;
                                    }
                                    else
                                    {
                                        laukums[x - 1, y - 1] = "X";
                                        laukums[x - 1, y] = "X"; // ievada arī blakus lauciņu
                                        kugis2++;
                                    }
                                    break;
                                }
                            case 3:
                                {
                                    if (laukums[x - 1, y - 1] == "X" || laukums[x - 1, y] == "X" || laukums[x - 1, y + 1] == "X")
                                    {
                                        jauAiznemts = true;
                                    }
                                    else
                                    {
                                        laukums[x - 1, y - 1] = "X";
                                        laukums[x - 1, y] = "X";
                                        laukums[x - 1, y + 1] = "X";
                                        kugis3++;
                                    }
                                    break;
                                }
                            case 4:
                                {
                                    if (laukums[x - 1, y - 1] == "X" || laukums[x - 1, y] == "X" || laukums[x - 1, y + 1] == "X" || laukums[x - 1, y + 2] == "X")
                                    {
                                        jauAiznemts = true;
                                    }
                                    else
                                    {
                                        laukums[x - 1, y - 1] = "X";
                                        laukums[x - 1, y] = "X";
                                        laukums[x - 1, y + 1] = "X";
                                        laukums[x - 1, y + 2] = "X";
                                        kugis4++;
                                    }
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("Ievadīts nepareizs kuģa izmērs");
                                    break;
                                }
                        }

                        if (jauAiznemts == true)
                        {
                            Console.WriteLine("Izvēlētās koordinātas jau ir aizņemtas ar citu kuģi!");
                            ievadits = false;
                        }
                    }
                    catch
                    {
                        Console.WriteLine();
                        Console.WriteLine("Kļūda ievadē! Izvēlets burts, kas nav vārdā 'KARTUPELIS' vai daļa ievadītā kuģa atrodas ārpus laukuma! Ievadiet citu sākumpunktu!");
                        Console.WriteLine();
                        ievadits = false;
                    }
                } while (ievadits == false);
                ievadits = false;

                Laukumi.Laukums(laukums);

                if (kugis1 == 4 && kugis2 == 3 && kugis3 == 2 && kugis4 == 1)
                {
                    ievadits = true; // ja visi kuģi ievadīti, iziet no do-while cikla
                }
            } while (ievadits == false);
        }

        public static void Gajiens(int nr, String[,] laukums, String[,] laukumsIevade) // jāpievieno pretinieku laukumi 
        {
            bool trapijums; // nosaka vai gājiena laikā ir trāpīts, ja true - Gajiens atkārtojas

            Console.WriteLine("***************************************");
            Console.WriteLine("********   " + nr + ". spēlētājs sauj   ********\n");
            Console.WriteLine("Līdz šim sašauts:");
            Console.WriteLine(); // atstarpe
            Laukumi.Laukums(laukumsIevade); // parāda līdzšinējo laukumu pirms šaušanas
            Console.WriteLine(); 

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

                    Console.WriteLine("\n*****   TRAPITS   *****\n");
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

        public static bool uzvara = false; // pārbauda vai izpilījušies uzvaras nosacījumi

        public static void Spelet()
        {
            int gajiens = 1; // gājiena skaitītājs, default == 1 jo sāk 1. spēlētājs

            do
            {
                if (gajiens == 1)
                {
                    Gajiens(1, laukums2, laukumsIevade1); // gājiens 1. spēlētājam
                    gajiens++;
                    UzvarasParbaude(1); // pārbauda vai 1. spēlētājs ir uzvarējis
                }
                else
                {
                    Gajiens(2, laukums1, laukumsIevade2); // gājiens 2. spēlētājam
                    gajiens--;
                    UzvarasParbaude(2); // pārbauda vai 2. spēlētājs ir uzvarējis
                }

                

            } while (uzvara == false); 
        }

        public static void UzvarasParbaude(int nr)
        {
            // nosacījumi uzvarai
        }
        
    }
}
