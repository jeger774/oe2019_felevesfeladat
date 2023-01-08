using System;

namespace ILEUXT_FF_MASODIKFELEV
{
    sealed class Auditor : Munkaero
    {
        //KONSTRUKTOR
        public Auditor(int id, string nev, int kepzettseg) : base(id, nev, kepzettseg)
        {
            this.Beosztas = "Auditor";
        }
    }
}
