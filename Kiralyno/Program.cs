using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiralyno
{
    class Tabla
    {
        char[,] T;
        char UresCella;
        int UresOszlopokSzama;
        int UresSorokSzama;

        public Tabla(char ch)
        {
            T = new char[8, 8];
            UresCella = ch;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    T[i, j] = UresCella;
                }
            }
        }

        public void Elhelyez(int N)
        {
            //1.  véletlen helyiertek letrehozasa
            //    - Random osztaly értékek halmaza:[0,7]
            //    - Véletlen sor, oszlop kell
            //    - Elhelyezzük a "K"-t, csak akkor ha üres a cella -> '#'

            Random vel = new Random();


            for (int i = 0; i < N; i++)
            {
                int sor = vel.Next(0, 8);
                int oszlop = vel.Next(0, 8);
                while (T[sor, oszlop] == 'K')
                {
                    sor = vel.Next(0, 8);
                    oszlop = vel.Next(0, 8);
                }
                T[sor, oszlop] = 'K';

            }



        }
        public void FajlbaIr()
        {

        }
        public void Megjelenit()
        {
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < 8; j++)
                {
                    Console.Write("{0,-3}", T[i, j]);
                }
            }
        }

        public bool UresOszlop(int oszlop)
        {
            

            int i = 0;

            while (i <8 && T[i,oszlop] != 'K')
            {
                    i++;
            }
            if (i < 8)
            {
                return false;
            }
            else
            {
                return true;
            }

            /*for (int i = 0; i < 8; i++)
            {
                if (T[i, oszlop] == 'K')
                {
                    valasz = false;
                }
            }
            if (valasz == false)
            {
                Console.WriteLine("Van K az oszlopban");
            }
            else
            {
                Console.WriteLine("Nincs");
            }
            */
            

        }
        public bool UresSor(int sor)
        {
            //1 ciklus mindkettőhöz, Ha T[sor,i], T[i,oszlop]
            //bool valasz = true;


            /*for (int i = 0; i < 8; i++)
            {
                if (T[sor, i] == 'K')
                {
                    valasz = false;
                }
            }
            if (valasz == false)
            {
                Console.WriteLine("Van K a sorban");
            }
            else
            {
                Console.WriteLine("Nincs");
            }

            */

            int i = 0;

            while (i < 8 && T[sor, i] != 'K')
            {
                i++;
            }
            if (i < 8)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Királynők feladat");
                Tabla t = new Tabla('#');
                Console.WriteLine("Üres tábla:");
                t.Megjelenit();
                t.Elhelyez(8);
                Console.WriteLine();
                t.Megjelenit();

                Console.WriteLine("\nMelyik oszlop?");
                int o = int.Parse(Console.ReadLine());
                
                if (t.UresOszlop(o))
                {
                    Console.WriteLine("Üres az oszlop");
                }
                else
                {
                    Console.WriteLine("Nem üres az oszlop");
                }


                Console.WriteLine("\nMelyik sor?");
                int s = int.Parse(Console.ReadLine());
                if (t.UresSor(s))
                {
                    Console.WriteLine("Üres a sor");
                }
                else
                {
                    Console.WriteLine("Nem üres a sor");
                }

                Console.WriteLine("\n8. Feladat: Az üres oszlopok és sorok száma:");
                int uresSor = 0;
                int uresOszlop = 0;

                for (int i = 0; i < 8; i++)
                {
                    if (t.UresSor(i) == true)
                    {
                        uresSor++;
                    }
                    if (t.UresOszlop(i) == true)
                    {
                        uresOszlop++;
                    }
                }
                Console.WriteLine("Sorok: {0}", uresSor);
                Console.WriteLine("Oszlopok: {0}",uresOszlop);


                Console.ReadKey();
            }
        }
    }
}
