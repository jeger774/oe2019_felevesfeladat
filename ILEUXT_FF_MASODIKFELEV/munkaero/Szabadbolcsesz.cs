using System;

namespace ILEUXT_FF_MASODIKFELEV
{
    sealed class Szabadbolcsesz : Munkaero
    {
        //KONSTRUKTOR
        public Szabadbolcsesz(int id, string nev, int kepzettseg) : base(id, nev, kepzettseg)
        {
            this.Beosztas = "Szabadbölcsész";
        }
    }
}
