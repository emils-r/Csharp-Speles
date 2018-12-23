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
                    laukums[i, j] = " "; // savada visu laikumu ar " "
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
            bool ievadits = false; // šis tiks izmantots, lai noteiktu vai kuģis ir leģitīmi ievietots
            Console.WriteLine("***   " + nr + ". speletajs ievada savus kugus   ***");
            Console.WriteLine();

            do
            {
                Console.WriteLine("Ievadiet kuģa garumu no 1 līdz 4:");
                do
                {
                    String temp = Console.ReadLine();
                    if (Regex.IsMatch(temp, "[0-9]")) // pārbauda vai tikai cipari ir ievadīti
                    {
                        g = Convert.ToInt32(temp); // ja tikai cipari - konvertē par integer, ja nav - nākamajā else izmet "kļūda ievadē"
                    }

                    if (g < 5 && g > 0) // pārbauda vai ir starp 1 un 4
                    {
                        ievadits = true;
                    }
                    else
                    {
                        Console.WriteLine("Kļūda ievadē! Jaizvēlas kuga garums no 1 lidz 4, ievadiet garumu velreiz:");
                    }

                    bool parDaudzKugu = false; // šis tiek izmantots, lai kuģu skaits noteiktajā izmērā nepārsniedz atļauto

                    switch (g)
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
                            if (kugis4 == 4) // testa režīmā var būt 4
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
                ievadits = false; // tiek resetots uz false pēc katra do-while, lai neizskrien cauri citiem cikliem

                String virziens = "";

                Console.WriteLine("Horizontāli 'H' vai vertikāli 'V'?");
                do
                {
                    String virziensIevadits = Console.ReadLine();
                    if (Regex.IsMatch(virziensIevadits, "[a-zA-Z]")) // pieļauj ievadīt gan mazos burtus, gan lielos
                    {
                        virziens = virziensIevadits.ToUpper();  // pārveido visus par lielajiem, lai nav tālāk jāizmanto gan lielie, gan mazie
                    }

                    if (virziens == "V" || virziens == "H")
                    {
                        ievadits = true;
                    }
                    else
                    {
                        Console.WriteLine("Kļūda ievadē! Virziens jāizvēlas 'H' vai 'V'!");
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

                            if (Regex.IsMatch(temp, "[0-9]")) // pārbauda vai tikai cipari ir ievadīti
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
                            if (Regex.IsMatch(temp, "[a-zA-Z]")) // pārbauda vai tikai burti ir ievadīti
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



                        if (virziens == "H") // ja virziens horizontāls
                        {
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
                            }
                        }
                        else // ja virziens ir vertikāls
                        {
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
                                        if (laukums[x - 1, y - 1] == "X" || laukums[x, y - 1] == "X")
                                        {
                                            jauAiznemts = true;
                                        }
                                        else
                                        {
                                            laukums[x - 1, y - 1] = "X";
                                            laukums[x, y - 1] = "X"; // ievada arī blakus lauciņu
                                            kugis2++;
                                        }
                                        break;
                                    }
                                case 3:
                                    {
                                        if (laukums[x - 1, y - 1] == "X" || laukums[x, y - 1] == "X" || laukums[x + 1, y - 1] == "X")
                                        {
                                            jauAiznemts = true;
                                        }
                                        else
                                        {
                                            laukums[x - 1, y - 1] = "X";
                                            laukums[x, y - 1] = "X";
                                            laukums[x + 1, y - 1] = "X";
                                            kugis3++;
                                        }
                                        break;
                                    }
                                case 4:
                                    {
                                        if (laukums[x - 1, y - 1] == "X" || laukums[x, y - 1] == "X" || laukums[x + 1, y - 1] == "X" || laukums[x + 2, y - 1] == "X")
                                        {
                                            jauAiznemts = true;
                                        }
                                        else
                                        {
                                            laukums[x - 1, y - 1] = "X";
                                            laukums[x, y - 1] = "X";
                                            laukums[x + 1, y - 1] = "X";
                                            laukums[x + 2, y - 1] = "X";
                                            kugis4++;
                                        }
                                        break;
                                    }
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

                if (kugis1 == 4 && kugis2 == 3 && kugis3 == 2 /*&&*/ || kugis4 == 4) // testa režīmā pietiek ar 1x kugis4 vai 4x kugis 4
                {
                    ievadits = true; // ja visi kuģi ievadīti, iziet no do-while cikla
                }

            } while (ievadits == false);
        }

        public static bool uzvara = false; // pārbauda vai izpilījušies uzvaras nosacījumi
        public static int punkti1 = 0; // skaita punktus spēlētājam
        public static int punkti2 = 0;

        public static void Gajiens(int nr, String[,] laukums, String[,] laukumsIevade) // jāpievieno pretinieku laukumi 
        {
            bool trapijums = false; // nosaka vai gājiena laikā ir trāpīts, ja true - Gajiens atkārtojas

            Console.WriteLine("***************************************");
            Console.WriteLine("********   " + nr + ". spēlētājs sauj   ********\n");
            Console.WriteLine("Līdz šim sašauts:");
            Console.WriteLine(); // atstarpe
            Laukumi.Laukums(laukumsIevade); // parāda līdzšinējo laukumu pirms šaušanas
            Console.WriteLine();

            int x = 0; // koordinātas šāvieniem
            int y = 0;
            String kol = ""; // kolonnas burts
            do
            {
                do
                {
                    String temp;
                    try
                    {
                        Console.WriteLine("Ievadiet saviena rindu:");
                        do
                        {
                            temp = Console.ReadLine();

                            if (Regex.IsMatch(temp, "[0-9]"))
                            {
                                x = Convert.ToInt32(temp);
                            }
                            if (x < 11 && x > 0)
                            {
                                trapijums = true;
                            }
                            else
                            {
                                Console.WriteLine("Kļūda ievadē! Ievadiet vēlreiz rindu no 1 līdz 10:");
                                trapijums = false;
                            }

                        } while (trapijums == false);
                        trapijums = false;

                        Console.WriteLine("Ievadiet saviena kolonnu:");
                        do
                        {
                            temp = Console.ReadLine();
                            if (Regex.IsMatch(temp, "[a-zA-Z]"))
                            {
                                kol = temp.ToUpper();
                            }

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

                            if (y < 11 && y > 0)
                            {
                                trapijums = true;
                            }
                            else
                            {
                                Console.WriteLine("Kļūda ievadē! Ievadiet vēlreiz kolonno no K lidz S:");
                                trapijums = false;
                            }

                        } while (trapijums == false);

                    }
                    catch
                    {
                        Console.WriteLine("\nKļūda ievadē! Ievadiet šāviena koordinātas vēlreiz:");
                        trapijums = false;
                    }

                } while (trapijums == false);

                if (laukums[x - 1, y - 1] == "X" && laukumsIevade[x - 1, y - 1] != "X") // pārbauda pretinieka laukumu, vai tajā vietā ir kuģis
                {

                    trapijums = true;

                    Console.WriteLine("\n********   TRAPITS   ********\n");

                    KuguApkartneVaiVissKugisSasauts(x, y, laukums, laukumsIevade); // TESTĒJAM, izstrādes procesā

                    if (nr == 1)
                    {
                        punkti1++;
                    }
                    else
                    {
                        punkti2++;
                    }
                }
                else if (laukums[x - 1, y - 1] == "X")
                {
                    Console.WriteLine("\nŠis lauciņš jau ir sašauts! Izvēlies citu!");

                    trapijums = true;
                }
                else
                {
                    laukumsIevade[x - 1, y - 1] = "O"; // ja netrāpa - Ievades laukumu aizvieto ar O
                    trapijums = false;

                    Console.WriteLine("\n***   " + nr + ". spēlētājs netrāpa   ***\n");
                }

                Console.WriteLine("Laukums pēc šāviena:");
                Laukumi.Laukums(laukumsIevade); // izvada laukumu pēc šāviena 
                Console.WriteLine();

                UzvarasParbaude(); // pārbauda vai 1. spēlētājs ir uzvarējis

                if (uzvara == true)
                {
                    Console.WriteLine("\n\n*************************************************");
                    Console.WriteLine("******   Apsveicam! " + nr + ". spēlētājs uzvar!!   ******");
                    Console.WriteLine("*************************************************\n\n");
                    break;
                }
                else if (trapijums == true)
                {
                    Console.WriteLine("****   " + nr + ". spēlētājs sauj vēlreiz   ****\n");
                }

            } while (trapijums == true);
        }

        public static void Spelet()
        {
            int gajiens = 1; // gājiena skaitītājs, default == 1 jo sāk 1. spēlētājs

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
            } while (uzvara == false);
        }

        public static void UzvarasParbaude()
        {
            if (punkti1 == 22 || punkti2 == 22) // testa versijā 4 (jo tikai 1x kugis4) vai 22 (ja 4x kugis4 un 2x kugis3), pilnajā 20
            {
                uzvara = true;
            }
            else
            {
                uzvara = false;
            }
        }

        public static void KuguApkartneVaiVissKugisSasauts(int x, int y, String[,] laukums, String[,] laukumsIevade)
        {
            // līdz šim nonāk tikai tad, ja ir pirmais trāpījums konkrētajam lauciņam
            laukumsIevade[x - 1, y - 1] = "X"; // ieliek X sašautajā vietā

            //if (laukums[x - 1, y - 2] == "X" || laukums[x - 1, y] == "X" || laukums[x - 2, y - 1] == "X" || laukums[x, y - 1] == "X") // apkārtējie horizontāli un vertikāli

            // horizontāli pa kreisi (2. X)
            try
            {
                if (laukums[x - 1, y - 2] == "X" && laukums[x - 1, y - 2] == laukumsIevade[x - 1, y - 2]) // 2. pa kreisi IR
                {
                    try
                    {
                        if (laukums[x - 1, y - 3] == "X" && laukums[x - 1, y - 3] == laukumsIevade[x - 1, y - 3]) // 3. X ir
                        {
                            try
                            {
                                if (laukums[x - 1, y - 4] == "X" && laukums[x - 1, y - 4] == laukumsIevade[x - 1, y - 4]) // 4. X ir
                                {
                                    KuguApkartneViss(x, y - 3, laukums, laukumsIevade); // ievada visus 4
                                    KuguApkartneViss(x, y - 2, laukums, laukumsIevade);
                                    KuguApkartneViss(x, y - 1, laukums, laukumsIevade);
                                    KuguApkartneViss(x, y, laukums, laukumsIevade);
                                }

                                if (laukums[x - 1, y - 4] == " ") // 4. X pa kreisi nav
                                {
                                    try
                                    {
                                        if (laukums[x - 1, y] == "X" && laukums[x - 1, y] == laukumsIevade[x - 1, y]) // pirmais pa labi ir X
                                        {
                                            KuguApkartneViss(x, y + 1, laukums, laukumsIevade); // 1. pa labi apvelkas
                                            KuguApkartneViss(x, y - 2, laukums, laukumsIevade); // 2. pa kreisi
                                            KuguApkartneViss(x, y - 1, laukums, laukumsIevade); // 1. pa kreisi
                                            KuguApkartneViss(x, y, laukums, laukumsIevade);     // sašautais
                                        }
                                        if (laukums[x - 1, y] == " ")
                                        {
                                            KuguApkartneViss(x, y - 2, laukums, laukumsIevade);
                                            KuguApkartneViss(x, y - 1, laukums, laukumsIevade);
                                            KuguApkartneViss(x, y, laukums, laukumsIevade);
                                        }
                                    }
                                    catch
                                    {
                                        KuguApkartneViss(x, y - 2, laukums, laukumsIevade);
                                        KuguApkartneViss(x, y - 1, laukums, laukumsIevade);
                                        KuguApkartneViss(x, y, laukums, laukumsIevade);
                                    }
                                }
                            }
                            catch
                            {
                                if (laukums[x - 1, y] == "X" && laukums[x - 1, y] == laukumsIevade[x - 1, y]) // pirmais pa labi ir X
                                {
                                    KuguApkartneViss(x, y + 1, laukums, laukumsIevade); // 1. pa labi apvelkas
                                    KuguApkartneViss(x, y - 2, laukums, laukumsIevade); // 2. pa kreisi
                                    KuguApkartneViss(x, y - 1, laukums, laukumsIevade); // 1. pa kreisi
                                    KuguApkartneViss(x, y, laukums, laukumsIevade);     // sašautais
                                }
                                if (laukums[x - 1, y] == " ") // pirmais pa labi nav
                                {
                                    KuguApkartneViss(x, y - 2, laukums, laukumsIevade);
                                    KuguApkartneViss(x, y - 1, laukums, laukumsIevade);
                                    KuguApkartneViss(x, y, laukums, laukumsIevade);
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        if (laukums[x - 1, y - 3] == " ") // 3. X pa kreisi nav 
                        {
                            try
                            {
                                if (laukums[x - 1, y] == "X" && laukums[x - 1, y] == laukumsIevade[x - 1, y]) // 1. pa labi ir 
                                {
                                    try
                                    {
                                        if (laukums[x - 1, y + 1] == "X" && laukums[x - 1, y + 1] == laukumsIevade[x - 1, y + 1]) // 2. pa labi ir 
                                        {
                                            KuguApkartneViss(x, y + 2, laukums, laukumsIevade); // apvelk 2. pa labi
                                            KuguApkartneViss(x, y + 1, laukums, laukumsIevade); // apvelk 1. pa labi
                                            KuguApkartneViss(x, y, laukums, laukumsIevade); // apvelk arī sašauto
                                            KuguApkartneViss(x, y - 1, laukums, laukumsIevade); // un pa 1. kreisi
                                        }
                                        if (laukums[x - 1, y + 1] == " ") // 2. pa labi nav
                                        {
                                            KuguApkartneViss(x, y + 1, laukums, laukumsIevade); // apvelk 1 pa labi
                                            KuguApkartneViss(x, y, laukums, laukumsIevade); // apvelk arī sašauto
                                            KuguApkartneViss(x, y - 1, laukums, laukumsIevade); // un pa 1. kreisi
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                            catch // jo 2 izmēru kuģis pašā labajā malā
                            {
                                KuguApkartneViss(x, y, laukums, laukumsIevade); // apvelk arī sašauto
                                KuguApkartneViss(x, y - 1, laukums, laukumsIevade); // un pa 1. kreisi
                            }
                        }
                    }
                    catch
                    {
                        if (laukums[x - 1, y] == "X" && laukums[x - 1, y] == laukumsIevade[x - 1, y]) // 1. pa labi ir 
                        {
                            if (laukums[x - 1, y + 1] == "X" && laukums[x - 1, y + 1] == laukumsIevade[x - 1, y + 1]) // 2. pa labi ir
                            {
                                KuguApkartneViss(x, y + 2, laukums, laukumsIevade); // apvelk 2. pa labi
                                KuguApkartneViss(x, y + 1, laukums, laukumsIevade); // apvelk 1. pa labi
                                KuguApkartneViss(x, y, laukums, laukumsIevade); // apvelk arī sašauto
                                KuguApkartneViss(x, y - 1, laukums, laukumsIevade); // un pa 1. kreisi
                            }
                            if (laukums[x - 1, y + 1] == " ")
                            {
                                KuguApkartneViss(x, y + 1, laukums, laukumsIevade); // apvelk 1. pa labi
                                KuguApkartneViss(x, y, laukums, laukumsIevade); // apvelk arī sašauto
                                KuguApkartneViss(x, y - 1, laukums, laukumsIevade); // un pa 1. kreisi
                            }
                        }
                    }
                    try
                    {
                        if (laukums[x - 1, y] == " ") // 1. pa labi nav
                        {
                            try
                            {
                                if (laukums[x - 1, y - 3] == " ") // 1. pa kreisi nav
                                {
                                    KuguApkartneViss(x, y, laukums, laukumsIevade); // sašautais
                                    KuguApkartneViss(x, y - 1, laukums, laukumsIevade); // 1. pa kreisi
                                }
                            }
                            catch
                            {
                                KuguApkartneViss(x, y, laukums, laukumsIevade); // sašautais
                                KuguApkartneViss(x, y - 1, laukums, laukumsIevade); // 1. pa kreisi
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }



            // horizontāli pa labi 2. X
            try
            {
                if (laukums[x - 1, y] == "X") // 1. pa labi ir
                {
                    if (laukums[x - 1, y] == "X" && laukums[x - 1, y] == laukumsIevade[x - 1, y]) // 2. pa Labi IR
                    {
                        try
                        {
                            if (laukums[x - 1, y + 1] == "X" && laukums[x - 1, y + 1] == laukumsIevade[x - 1, y + 1]) // 3. X ir
                            {
                                try
                                {
                                    if (laukums[x - 1, y + 2] == "X" && laukums[x - 1, y + 2] == laukumsIevade[x - 1, y + 2]) // 4. X ir
                                    {
                                        KuguApkartneViss(x, y + 3, laukums, laukumsIevade); // ievada visus 4
                                        KuguApkartneViss(x, y + 2, laukums, laukumsIevade);
                                        KuguApkartneViss(x, y + 1, laukums, laukumsIevade);
                                        KuguApkartneViss(x, y, laukums, laukumsIevade);
                                    }
                                    if (laukums[x - 1, y + 2] == " ") // 4. X pa labi nav
                                    {
                                        try
                                        {
                                            if (laukums[x - 1, y - 2] == "X" && laukums[x - 1, y - 2] == laukumsIevade[x - 1, y - 2]) // pirmais pa kreisi ir X
                                            {
                                                KuguApkartneViss(x, y - 1, laukums, laukumsIevade); // 1. pa kreisi apvelkas
                                                KuguApkartneViss(x, y + 2, laukums, laukumsIevade); // 2. pa labi 
                                                KuguApkartneViss(x, y + 1, laukums, laukumsIevade); // 1. pa labi
                                                KuguApkartneViss(x, y, laukums, laukumsIevade);     // sašautais
                                            }
                                            if (laukums[x - 1, y - 2] == " ")
                                            {
                                                KuguApkartneViss(x, y + 2, laukums, laukumsIevade);
                                                KuguApkartneViss(x, y + 1, laukums, laukumsIevade);
                                                KuguApkartneViss(x, y, laukums, laukumsIevade);
                                            }
                                        }
                                        catch
                                        {
                                            KuguApkartneViss(x, y + 2, laukums, laukumsIevade); // 2. pa labi 
                                            KuguApkartneViss(x, y + 1, laukums, laukumsIevade); // 1. pa labi
                                            KuguApkartneViss(x, y, laukums, laukumsIevade);     // sašautais
                                        }
                                    }
                                }
                                catch
                                {
                                    if (laukums[x - 1, y - 2] == "X" && laukums[x - 1, y - 2] == laukumsIevade[x - 1, y - 2]) // pirmais pa kreisi ir X
                                    {
                                        KuguApkartneViss(x, y - 1, laukums, laukumsIevade); // 1. pa kreisi apvelkas
                                        KuguApkartneViss(x, y + 2, laukums, laukumsIevade); // 2. pa labi 
                                        KuguApkartneViss(x, y + 1, laukums, laukumsIevade); // 1. pa labi
                                        KuguApkartneViss(x, y, laukums, laukumsIevade);     // sašautais
                                    }
                                    if (laukums[x - 1, y - 2] == " ") // pirmais pa kreisi nav
                                    {
                                        KuguApkartneViss(x, y + 2, laukums, laukumsIevade); // 2. pa labi apvelkas
                                        KuguApkartneViss(x, y + 1, laukums, laukumsIevade); // 1. pa labi
                                        KuguApkartneViss(x, y, laukums, laukumsIevade);     // sašautais
                                    }
                                }
                            }

                            if (laukums[x - 1, y + 1] == " ") // 3. X pa labi nav 
                            {
                                try
                                {

                                    if (laukums[x - 1, y - 2] == "X" && laukums[x - 1, y - 2] == laukumsIevade[x - 1, y - 2]) // 1. pa kreisi ir 
                                    {
                                        if (laukums[x - 1, y - 3] == "X" && laukums[x - 1, y - 3] == laukumsIevade[x - 1, y - 3]) // 2. pa kreisi ir 
                                        {
                                            KuguApkartneViss(x, y - 2, laukums, laukumsIevade); // apvelk 2. pa kreisi
                                            KuguApkartneViss(x, y - 1, laukums, laukumsIevade); // apvelk 1. pa kreisi
                                            KuguApkartneViss(x, y, laukums, laukumsIevade); // apvelk arī sašauto
                                            KuguApkartneViss(x, y + 1, laukums, laukumsIevade); // un pa 1. labi
                                        }
                                        if (laukums[x - 1, y - 3] == " ") // 2. pa kreisi nav
                                        {
                                            KuguApkartneViss(x, y + 1, laukums, laukumsIevade); // apvelk 1 pa labi
                                            KuguApkartneViss(x, y, laukums, laukumsIevade); // apvelk arī sašauto
                                            KuguApkartneViss(x, y - 1, laukums, laukumsIevade); // un 1. pa kreisi
                                        }
                                    }
                                }
                                catch
                                {
                                    KuguApkartneViss(x, y, laukums, laukumsIevade); // apvelk arī sašauto
                                    KuguApkartneViss(x, y + 1, laukums, laukumsIevade); // un pa 1. labi
                                }
                            }
                        }
                        catch
                        {
                            if (laukums[x - 1, y - 2] == "X" && laukums[x - 1, y - 2] == laukumsIevade[x - 1, y - 2]) // 1. pa kreisi ir 
                            {
                                if (laukums[x - 1, y - 3] == "X" && laukums[x - 1, y - 3] == laukumsIevade[x - 1, y - 3]) // 2. pa kreisi ir
                                {
                                    KuguApkartneViss(x, y - 2, laukums, laukumsIevade); // apvelk 2. pa kreisi
                                    KuguApkartneViss(x, y + 1, laukums, laukumsIevade); // apvelk 1. pa labi
                                    KuguApkartneViss(x, y, laukums, laukumsIevade); // apvelk arī sašauto
                                    KuguApkartneViss(x, y - 1, laukums, laukumsIevade); // un pa 1. kreisi
                                }
                                if (laukums[x - 1, y - 3] == " ")
                                {
                                    KuguApkartneViss(x, y + 1, laukums, laukumsIevade); // apvelk 1. pa labi
                                    KuguApkartneViss(x, y, laukums, laukumsIevade); // apvelk arī sašauto
                                    KuguApkartneViss(x, y - 1, laukums, laukumsIevade); // un pa 1. kreisi
                                }
                            }
                        }
                        try
                        {
                            if (laukums[x - 1, y - 2] == " ") // 1. pa kreisi nav
                            {
                                try
                                {
                                    if (laukums[x - 1, y + 1] == " ") // 2. pa labi nav
                                    {
                                        KuguApkartneViss(x, y, laukums, laukumsIevade); // sašautais
                                        KuguApkartneViss(x, y + 1, laukums, laukumsIevade); // 1. pa labi
                                    }
                                }
                                catch
                                {
                                    KuguApkartneViss(x, y, laukums, laukumsIevade); // sašautais
                                    KuguApkartneViss(x, y + 1, laukums, laukumsIevade); // 1. pa labi
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                }
            }
            catch
            {
            }


            // vertikāli uz augšu
            try
            {
                if (laukums[x - 2, y - 1] == "X" && laukums[x - 2, y - 1] == laukumsIevade[x - 2, y - 1]) // 1. uz augšu ir
                {
                    try
                    {
                        if (laukums[x - 3, y - 1] == "X" && laukums[x - 3, y - 1] == laukumsIevade[x - 3, y - 1]) // 2. uz augšu ir X
                        {
                            try
                            {
                                if (laukums[x - 4, y - 1] == "X" && laukums[x - 4, y - 1] == laukumsIevade[x - 4, y - 1]) // 3. uz augšu ir X
                                {
                                    KuguApkartneViss(x - 3, y, laukums, laukumsIevade); // ievada visus 4
                                    KuguApkartneViss(x - 2, y, laukums, laukumsIevade);
                                    KuguApkartneViss(x - 1, y, laukums, laukumsIevade);
                                    KuguApkartneViss(x, y, laukums, laukumsIevade);
                                }

                                if (laukums[x - 4, y - 1] == " ") // 4. X uz augšu nav
                                {
                                    try
                                    {
                                        if (laukums[x, y - 1] == "X" && laukums[x, y - 1] == laukumsIevade[x, y - 1]) // pirmais uz leju ir X
                                        {
                                            KuguApkartneViss(x + 1, y, laukums, laukumsIevade); // 1. uz leju apvelkas
                                            KuguApkartneViss(x - 2, y, laukums, laukumsIevade); // 2. uz augšu
                                            KuguApkartneViss(x - 1, y, laukums, laukumsIevade); // 1. uz augšu
                                            KuguApkartneViss(x, y, laukums, laukumsIevade);     // sašautais
                                        }
                                        if (laukums[x, y - 1] == " ")
                                        {
                                            KuguApkartneViss(x - 2, y, laukums, laukumsIevade);
                                            KuguApkartneViss(x - 1, y, laukums, laukumsIevade);
                                            KuguApkartneViss(x, y, laukums, laukumsIevade);
                                        }
                                    }
                                    catch
                                    {
                                        KuguApkartneViss(x - 2, y, laukums, laukumsIevade);
                                        KuguApkartneViss(x - 1, y, laukums, laukumsIevade);
                                        KuguApkartneViss(x, y, laukums, laukumsIevade);
                                    }
                                }
                            }
                            catch
                            {
                                if (laukums[x, y - 1] == "X" && laukums[x, y - 1] == laukumsIevade[x, y - 1]) // pirmais uz leju ir X
                                {
                                    KuguApkartneViss(x + 1, y, laukums, laukumsIevade); // 1. pa labi apvelkas
                                    KuguApkartneViss(x - 2, y, laukums, laukumsIevade); // 2. pa kreisi
                                    KuguApkartneViss(x - 1, y, laukums, laukumsIevade); // 1. pa kreisi
                                    KuguApkartneViss(x, y, laukums, laukumsIevade);     // sašautais
                                }
                                if (laukums[x, y - 1] == " ") // pirmais uz leju nav
                                {
                                    KuguApkartneViss(x - 2, y, laukums, laukumsIevade);
                                    KuguApkartneViss(x - 1, y, laukums, laukumsIevade);
                                    KuguApkartneViss(x, y, laukums, laukumsIevade);
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        if (laukums[x - 3, y - 1] == " ") // 3. X uz augšu nav 
                        {
                            try
                            {
                                if (laukums[x, y - 1] == "X" && laukums[x, y - 1] == laukumsIevade[x, y - 1]) // 1. uz leju ir 
                                {
                                    try
                                    {
                                        if (laukums[x + 1, y - 1] == "X" && laukums[x + 1, y - 1] == laukumsIevade[x + 1, y - 1]) // 2. uz leju ir 
                                        {
                                            KuguApkartneViss(x + 2, y, laukums, laukumsIevade); // apvelk 2. uz leju
                                            KuguApkartneViss(x + 1, y, laukums, laukumsIevade); // apvelk 1. uz leju
                                            KuguApkartneViss(x, y, laukums, laukumsIevade); // apvelk arī sašauto
                                            KuguApkartneViss(x - 1, y, laukums, laukumsIevade); // un 1. uz augšu
                                        }
                                        if (laukums[x + 1, y - 1] == " ") // 2. uz leju nav
                                        {
                                            KuguApkartneViss(x + 1, y, laukums, laukumsIevade); // apvelk 1 uz leju
                                            KuguApkartneViss(x, y, laukums, laukumsIevade); // apvelk arī sašauto
                                            KuguApkartneViss(x - 1, y, laukums, laukumsIevade); // un 1. uz augšu
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                            catch // jo 2 izmēru kuģis pašā augšējā malā
                            {
                                KuguApkartneViss(x, y, laukums, laukumsIevade); // apvelk arī sašauto
                                KuguApkartneViss(x - 1, y, laukums, laukumsIevade); // un 1. uz augšu
                            }
                        }
                    }
                    catch
                    {
                        if (laukums[x, y - 1] == "X" && laukums[x, y - 1] == laukumsIevade[x, y - 1]) // 1. uz leju ir 
                        {
                            if (laukums[x + 1, y - 1] == "X" && laukums[x + 1, y - 1] == laukumsIevade[x + 1, y - 1]) // 2. uz leju ir
                            {
                                KuguApkartneViss(x + 2, y, laukums, laukumsIevade); // apvelk 2. uz leju
                                KuguApkartneViss(x + 1, y, laukums, laukumsIevade); // apvelk 1. uz leju
                                KuguApkartneViss(x, y, laukums, laukumsIevade); // apvelk arī sašauto
                                KuguApkartneViss(x - 1, y, laukums, laukumsIevade); // un 1. uz augšu
                            }
                            if (laukums[x + 1, y - 1] == " ")
                            {
                                KuguApkartneViss(x + 1, y, laukums, laukumsIevade); // apvelk 1. uz leju
                                KuguApkartneViss(x, y, laukums, laukumsIevade); // apvelk arī sašauto
                                KuguApkartneViss(x - 1, y, laukums, laukumsIevade); // un 1. uz augšu
                            }
                        }
                    }
                    try
                    {
                        if (laukums[x, y - 1] == " ") // 1. uz leju nav
                        {
                            try
                            {
                                if (laukums[x - 3, y - 1] == " ") // 2. uz augšu nav
                                {
                                    KuguApkartneViss(x, y, laukums, laukumsIevade); // sašautais
                                    KuguApkartneViss(x - 1, y, laukums, laukumsIevade); // 1. pa kreisi
                                }
                            }
                            catch // pie augšējās malas
                            {
                                KuguApkartneViss(x, y, laukums, laukumsIevade); // sašautais
                                KuguApkartneViss(x - 1, y, laukums, laukumsIevade); // 1. uz augšu
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }


            // vertikāli uz leju
            try
            {
                if (laukums[x, y - 1] == "X" && laukums[x, y - 1] == laukumsIevade[x, y - 1]) // 1. uz leju ir
                {
                    try
                    {
                        if (laukums[x + 1, y - 1] == "X" && laukums[x + 1, y - 1] == laukumsIevade[x + 1, y - 1]) // 2. uz leju ir X
                        {
                            try
                            {
                                if (laukums[x + 2, y - 1] == "X" && laukums[x + 2, y - 1] == laukumsIevade[x + 2, y - 1]) // 3. uz leju ir X
                                {
                                    KuguApkartneViss(x + 3, y, laukums, laukumsIevade); // ievada visus 4
                                    KuguApkartneViss(x + 2, y, laukums, laukumsIevade);
                                    KuguApkartneViss(x + 1, y, laukums, laukumsIevade);
                                    KuguApkartneViss(x, y, laukums, laukumsIevade);
                                }

                                if (laukums[x + 2, y - 1] == " ") // 4. X uz leju nav kuģis
                                {
                                    try
                                    {
                                        if (laukums[x - 2, y - 1] == "X" && laukums[x - 2, y - 1] == laukumsIevade[x - 2, y - 1]) // pirmais uz leju ir X
                                        {
                                            KuguApkartneViss(x + 1, y, laukums, laukumsIevade); // 1. uz leju apvelkas
                                            KuguApkartneViss(x + 2, y, laukums, laukumsIevade); // 2. uz leju
                                            KuguApkartneViss(x - 1, y, laukums, laukumsIevade); // 1. uz augšu
                                            KuguApkartneViss(x, y, laukums, laukumsIevade);     // sašautais
                                        }
                                        if (laukums[x - 2, y - 1] == " ")
                                        {
                                            KuguApkartneViss(x + 2, y, laukums, laukumsIevade);
                                            KuguApkartneViss(x + 1, y, laukums, laukumsIevade);
                                            KuguApkartneViss(x, y, laukums, laukumsIevade);
                                        }
                                    }
                                    catch
                                    {
                                        KuguApkartneViss(x + 2, y, laukums, laukumsIevade);
                                        KuguApkartneViss(x + 1, y, laukums, laukumsIevade);
                                        KuguApkartneViss(x, y, laukums, laukumsIevade);
                                    }
                                }
                            }
                            catch
                            {
                                if (laukums[x - 2, y - 1] == "X" && laukums[x - 2, y - 1] == laukumsIevade[x - 2, y - 1]) // pirmais uz leju ir X
                                {
                                    KuguApkartneViss(x + 1, y, laukums, laukumsIevade); // 1. uz leju apvelkas
                                    KuguApkartneViss(x + 2, y, laukums, laukumsIevade); // 2. uz leju
                                    KuguApkartneViss(x - 1, y, laukums, laukumsIevade); // 1. uz augšu
                                    KuguApkartneViss(x, y, laukums, laukumsIevade);     // sašautais
                                }
                                if (laukums[x - 2, y - 1] == " ") // pirmais uz augšu nav
                                {
                                    KuguApkartneViss(x + 2, y, laukums, laukumsIevade);
                                    KuguApkartneViss(x + 1, y, laukums, laukumsIevade);
                                    KuguApkartneViss(x, y, laukums, laukumsIevade);
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        if (laukums[x + 1, y - 1] == " ") // 2. X uz leju nav 
                        {
                            try
                            {
                                if (laukums[x - 2, y - 1] == "X" && laukums[x - 2, y - 1] == laukumsIevade[x - 2, y - 1]) // 1. uz augšu ir 
                                {
                                    try
                                    {
                                        if (laukums[x - 3, y - 1] == "X" && laukums[x - 3, y - 1] == laukumsIevade[x - 3, y - 1]) // 2. uz augšu ir 
                                        {
                                            KuguApkartneViss(x - 2, y, laukums, laukumsIevade); // apvelk 2. uz augšu
                                            KuguApkartneViss(x + 1, y, laukums, laukumsIevade); // apvelk 1. uz leju
                                            KuguApkartneViss(x, y, laukums, laukumsIevade); // apvelk arī sašauto
                                            KuguApkartneViss(x - 1, y, laukums, laukumsIevade); // un 1. uz augšu
                                        }
                                        if (laukums[x - 3, y - 1] == " ") // 2. uz leju nav
                                        {
                                            KuguApkartneViss(x + 1, y, laukums, laukumsIevade); // apvelk 1 uz leju
                                            KuguApkartneViss(x, y, laukums, laukumsIevade); // apvelk arī sašauto
                                            KuguApkartneViss(x - 1, y, laukums, laukumsIevade); // un 1. uz augšu
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                            catch // jo 2 izmēru kuģis pašā augšējā malā
                            {
                                KuguApkartneViss(x, y, laukums, laukumsIevade); // apvelk arī sašauto
                                KuguApkartneViss(x + 1, y, laukums, laukumsIevade); // un 1. uz leju
                            }
                        }
                    }
                    catch
                    {
                        if (laukums[x - 2, y - 1] == "X" && laukums[x - 2, y - 1] == laukumsIevade[x - 2, y - 1]) // 1. uz augšu ir 
                        {
                            if (laukums[x - 3, y - 1] == "X" && laukums[x - 3, y - 1] == laukumsIevade[x - 3, y - 1]) // 2. uz augšu ir
                            {
                                KuguApkartneViss(x - 2, y, laukums, laukumsIevade); // apvelk 2. uz augšu
                                KuguApkartneViss(x + 1, y, laukums, laukumsIevade); // apvelk 1. uz leju
                                KuguApkartneViss(x, y, laukums, laukumsIevade); // apvelk arī sašauto
                                KuguApkartneViss(x - 1, y, laukums, laukumsIevade); // un 1. uz augšu
                            }
                            if (laukums[x - 3, y - 1] == " ")
                            {
                                KuguApkartneViss(x + 1, y, laukums, laukumsIevade); // apvelk 1. uz leju
                                KuguApkartneViss(x, y, laukums, laukumsIevade); // apvelk arī sašauto
                                KuguApkartneViss(x - 1, y, laukums, laukumsIevade); // un 1. uz augšu
                            }
                        }
                    }
                    try
                    {
                        if (laukums[x - 2, y - 1] == " ") // 1. uz augšu nav
                        {
                            try
                            {
                                if (laukums[x + 1, y - 1] == " ") // 2. uz leju nav
                                {
                                    KuguApkartneViss(x, y, laukums, laukumsIevade); // sašautais
                                    KuguApkartneViss(x + 1, y, laukums, laukumsIevade); // 1. uz leju
                                }
                            }
                            catch // pie apakšējās malas
                            {
                                KuguApkartneViss(x, y, laukums, laukumsIevade); // sašautais
                                KuguApkartneViss(x + 1, y, laukums, laukumsIevade); // 1. uz leju
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }


            /*
            else
            {
                KuguApkartneViss(x, y, laukums, laukumsIevade);
            }
            */
        }

        public static void KuguApkartneViss(int x, int y, String[,] laukums, String[,] laukumsIevade)
        {
            try
            {
                if (laukums[x - 2, y - 2] == " ")
                {
                    laukumsIevade[x - 2, y - 2] = "O";
                }
            }
            catch
            {

            }
            try
            {
                if (laukums[x - 2, y - 1] == " ")
                {
                    laukumsIevade[x - 2, y - 1] = "O";
                }
            }
            catch
            {

            }
            try
            {
                if (laukums[x - 2, y] == " ")
                {
                    laukumsIevade[x - 2, y] = "O";
                }
            }
            catch
            {

            }
            try
            {
                if (laukums[x - 1, y - 2] == " ")
                {
                    laukumsIevade[x - 1, y - 2] = "O";
                }
            }
            catch
            {

            }
            try
            {
                if (laukums[x - 1, y] == " ")
                {
                    laukumsIevade[x - 1, y] = "O";
                }
            }
            catch
            {

            }
            try
            {
                if (laukums[x, y - 2] == " ")
                {
                    laukumsIevade[x, y - 2] = "O";
                }
            }
            catch
            {

            }
            try
            {
                if (laukums[x, y - 1] == " ")
                {
                    laukumsIevade[x, y - 1] = "O";
                }
            }
            catch
            {

            }
            try
            {
                if (laukums[x, y] == " ")
                {
                    laukumsIevade[x, y] = "O";
                }
            }
            catch
            {

            }
        }

    }
}
