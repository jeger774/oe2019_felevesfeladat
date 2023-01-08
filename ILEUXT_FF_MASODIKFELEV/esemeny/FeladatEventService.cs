using System;

namespace ILEUXT_FF_MASODIKFELEV
{
    class FeladatEventService
    {
        public void Kiosztott(object src, FeladatEventArgs a)
        {
            Console.WriteLine("\tKiosztott feladatok:\n");
            int db = 0;
            for (int i = 0; i < a.Kiosztott.Szamlalo; i++)
            {
                (a.Kiosztott[i] as Feladat).Adatok();
                db++;
            }
            Console.WriteLine("{0} feladat lett kiosztva.\n", db);
        }
        public void Kiosztando(object src, FeladatEventArgs a)
        {
            Console.WriteLine("\tMég nincs kiosztva:\n");
            int db = 0;
            for (int i = 0; i < a.Kiosztando.Szamlalo; i++)
            {
                if (a.Kiosztando[i].Munkaero == null)
                {
                    (a.Kiosztando[i] as Feladat).Adatok();
                    db++;
                }
            }
            Console.WriteLine("{0} feladat nem lett kiosztva.\n", db);
        }
        public void SzabadMunkaero(object src, FeladatEventArgs a)
        {
            for (int i = 0; i < a.Munkaero.Szamlalo; i++)
            {
                if (a.Munkaero[i].ElvegzendoFeladatok.Szamlalo < a.MaxF)
                {
                    int db = a.MaxF - a.Munkaero[i].ElvegzendoFeladatok.Szamlalo;
                    Console.WriteLine("\t{0} ({1}) kaphat még {2} feladatot.", (a.Munkaero[i] as Munkaero).Nev, (a.Munkaero[i] as Munkaero).Beosztas, db);
                }
            }
        }
    }
}
