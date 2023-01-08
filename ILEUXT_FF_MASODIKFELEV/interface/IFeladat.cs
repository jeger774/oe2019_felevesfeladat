using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILEUXT_FF_MASODIKFELEV
{
    interface IFeladat
    {
        //TULAJDONSÁGOK
        int ID { get; set; }
        string Nev { get; set; }
        int Szint { get; set; }
        IMunkaero Munkaero { get; set; }
    }
}
