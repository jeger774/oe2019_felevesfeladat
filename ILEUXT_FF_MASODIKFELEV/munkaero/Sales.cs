using System;

namespace ILEUXT_FF_MASODIKFELEV
{
    sealed class Sales : Munkaero
    {
        //KONSTRUKTOR
        public Sales(int id, string nev, int kepzettseg) : base(id, nev, kepzettseg)
        {
            this.Beosztas = "Sales";
        }
    }
}
