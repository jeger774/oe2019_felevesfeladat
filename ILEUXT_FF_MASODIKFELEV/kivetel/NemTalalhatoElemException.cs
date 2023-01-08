using System;

namespace ILEUXT_FF_MASODIKFELEV
{
    class NemTalalhatoElemException : Exception
    {
        //KONSTRUKTOR
        public NemTalalhatoElemException()
        {
            this.HibaUzenet = string.Format("A megadott elem nincs a listában.");
        }

        //TULAJDONSÁGOK
        public string HibaUzenet { get; set; }
    }
}
