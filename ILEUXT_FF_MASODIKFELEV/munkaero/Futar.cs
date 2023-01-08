using System;

namespace ILEUXT_FF_MASODIKFELEV
{
    sealed class Futar : Munkaero
    {
        //KONSTRUKTOR
        public Futar(int id, string nev, int kepzettseg) : base(id, nev, kepzettseg)
        {
            this.Beosztas = "Futár";
        }
    }
}
