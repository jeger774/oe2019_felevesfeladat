using System;

namespace ILEUXT_FF_MASODIKFELEV
{
    class AlacsonyKepzettsegException : Exception
    {
        //KONSTRUKTOR
        public AlacsonyKepzettsegException(IMunkaero munkaero)
        {
            this.HibaUzenet = string.Format("{0} ({1}) képzettsége túl alacsony.\nTovábbképzésre küldtük.\n", munkaero.Nev, munkaero.Beosztas);
            this.Munkaero = munkaero;
        }
        
        //TULAJDONSÁGOK
        public string HibaUzenet { get; set; }
        public IMunkaero Munkaero { get; set; }
    }
}
