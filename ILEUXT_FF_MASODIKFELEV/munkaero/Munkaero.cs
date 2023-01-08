using System;

namespace ILEUXT_FF_MASODIKFELEV
{
    abstract class Munkaero : IMunkaero, IComparable
    {
        //KONSTRUKTOR
        public Munkaero(int id, string nev, int kepzettseg)
        {
            this.ID = id;
            this.Nev = nev;
            this.Kepzettseg = kepzettseg;
            this.ElvegzendoFeladatok = new FeladatLista<IFeladat>();
        }

        //TULAJDONSÁGOK
        public int ID { get; set; }
        public string Nev { get; set; }
        public int Kepzettseg { get; set; }
        public string Beosztas { get; set; }
        public FeladatLista<IFeladat> ElvegzendoFeladatok { get; set; }

        //METÓDUSOK
        public override bool Equals(object obj)
        {
            if ((obj as Munkaero).ID == ID) return true;
            else return false;
        }
        public override int GetHashCode() { return base.GetHashCode(); }
        public int CompareTo(object obj)
        {
            if ((obj as Munkaero).Kepzettseg > Kepzettseg) return -1;
            else if ((obj as Munkaero).Kepzettseg < Kepzettseg) return 1;
            else return 0;
        }
        public override string ToString()
        {
            return string.Format("[{0}] {1}, {2}, {3}", this.ID, this.Nev, this.Beosztas, this.Kepzettseg);
        }
    }
}
