using System;

namespace ILEUXT_FF_MASODIKFELEV
{
    class FeladatEventArgs : EventArgs
    {
        //KONSTRUKTOR
        public FeladatEventArgs(MunkaeroLista<IMunkaero> munkaero, FeladatLista<IFeladat> kiosztando, FeladatLista<IFeladat> kiosztott)
        {
            this.Munkaero = munkaero;
            this.Kiosztando = kiosztando;
            this.Kiosztott = kiosztott;
        }

        //TULAJDONSÁGOK
        public MunkaeroLista<IMunkaero> Munkaero { get; set; }
        public FeladatLista<IFeladat> Kiosztando { get; set; }
        public FeladatLista<IFeladat> Kiosztott { get; set; }
        public int MaxF = 5;
    }
}
