using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILEUXT_FF_MASODIKFELEV
{
    interface IMunkaero
    {
        //TULAJDONSÁGOK
        int ID { get; set; }
        string Nev { get; set; }
        int Kepzettseg { get; set; }
        string Beosztas { get; set; }
        FeladatLista<IFeladat> ElvegzendoFeladatok { get; set; }
    }
}
