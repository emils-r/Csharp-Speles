using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Karatavas
{
    class Darbibas
    {
        public static char[] ievade;
        public static char[] parbaudamais;
        public static bool vardaParb = true;

        public static void VaditajaIevade()
        {
            String vardsMazais;

            do
            {
                Console.WriteLine("Speles vadītājs ievada minamo vardu: ");

                String vardsIevaditais = Console.ReadLine();            // ievadits minamais vards
                vardsMazais = vardsIevaditais.ToUpper();         // saliek visus burtus kā mazos

                if (!Regex.IsMatch(vardsMazais, @"^[A-Z]+$"))
                {
                    Console.WriteLine();
                    Console.WriteLine("Jaievada tikai! ");
                    vardaParb = false;
                }
                else
                {
                    vardaParb = true;
                }

            } while (vardaParb == false);

            parbaudamais = vardsMazais.ToCharArray();        // pārvērš vārdu simbolu masīvā
            ievade = new char[parbaudamais.Length];

            Console.WriteLine();
            Console.WriteLine("Minamais vards sastav no " + ievade.Length + " simboliem:");

            for (int i = 0; i < ievade.Length; i++)
            {
                ievade[i] = '_';
                Console.Write(ievade[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        public static int kluduSkaits = 0;
        public static int ievadits = 0;
        public static int temp;
        public static char minetais;
        public static bool burtaParb = true;

        public static void Gajiens()
        {

            do
            {

                if (kluduSkaits == 5)
                {
                    Console.WriteLine();
                    Console.WriteLine("Speletajs zaudeja!");
                    Console.WriteLine();
                    break;
                }

                try
                {

                    do
                    {
                        Console.WriteLine("Speletajs ievada meklejamo burtu:");

                        String minetaisSakuma = Console.ReadLine();
                        String minetaisParveidots = minetaisSakuma.ToUpper();
                        minetais = Convert.ToChar(minetaisParveidots);

                        if (!Regex.IsMatch(minetaisParveidots, @"^[A-Z]+$"))
                        {
                            Console.WriteLine();
                            Console.WriteLine("Jaievada burts! ");
                            burtaParb = false;
                        }
                        else
                        {
                            burtaParb = true;
                        }

                    } while (burtaParb == false);


                    temp = ievadits;

                    for (int i = 0; i < parbaudamais.Length; i++)
                    {
                        if (parbaudamais[i] == minetais && ievade[i] == '_')
                        {
                            ievade[i] = minetais;
                            ievadits++;
                        }
                        else if (parbaudamais[i] == minetais)
                        {
                            Console.WriteLine("Šis burts jau ir izmantots");
                        }
                    }

                    Console.WriteLine();
                    Console.WriteLine("Minamais vards:");
                    for (int i = 0; i < ievade.Length; i++)
                    {
                        Console.Write(ievade[i] + " ");
                    }
                    Console.WriteLine();
                    Console.WriteLine();

                    if (temp == ievadits)
                    {
                        Console.WriteLine("Burts netika atrasts. " + (1 + kluduSkaits) + ". kluda no 5");
                        kluduSkaits++;

                    }
                }
                catch
                {
                    Console.WriteLine("Kluda ievade. Jaievada viens burts!");
                    Console.WriteLine();
                }
                //Console.WriteLine("Ievaditi jau " + ievadits);

            } while (ievadits < ievade.Length);

        }

    }
}
