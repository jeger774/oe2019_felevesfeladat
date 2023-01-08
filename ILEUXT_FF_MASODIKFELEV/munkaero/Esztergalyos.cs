using System;

namespace ILEUXT_FF_MASODIKFELEV
{
    sealed class Esztergalyos : Munkaero
    {
        //KONSTRUKTOR
        public Esztergalyos(int id, string nev, int kepzettseg) : base(id, nev, kepzettseg)
        {
            this.Beosztas = "Esztergályos";
        }
    }
}
