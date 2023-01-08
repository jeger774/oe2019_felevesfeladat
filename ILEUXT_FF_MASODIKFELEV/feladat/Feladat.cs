using System;

namespace ILEUXT_FF_MASODIKFELEV
{
    abstract class Feladat : IFeladat , IComparable
    {
        //TULAJDONSAGOK
        public int ID { get; set; }
        public string Nev { get; set; }
        public int Szint { get; set; }
        public string Beosztas { get; set; }
        public IMunkaero Munkaero { get; set; }

        //METODUSOK
        public override bool Equals(object obj)
        {
            if ((obj as Feladat).ID == ID) return true;
            else return false;
        }
        public override int GetHashCode() { return base.GetHashCode(); }
        public int CompareTo(object obj)
        {
            if ((obj as Feladat).Szint > Szint) return -1;
            else if ((obj as Feladat).Szint < Szint) return 1;
            else return 0;
        }
        public void Adatok()
        {
            if (Munkaero != null)
                Console.WriteLine("{0}\nNehézség:{1}\tDolgozó:{2}\n", this.Nev, this.Szint, this.Munkaero.Nev);
            else
                Console.WriteLine("{0}\nNehézség:{1}\n", this.Nev, this.Szint);
        }
        public override string ToString()
        {
            return string.Format("[ID:{0}] {1}, {2}", this.ID, this.Nev, this.Szint);
        }
    }
}
