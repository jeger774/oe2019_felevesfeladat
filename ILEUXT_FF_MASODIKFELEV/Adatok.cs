using System;
using System.Text;
using System.IO;

namespace ILEUXT_FF_MASODIKFELEV
{
    sealed class Adatok
    {
        //KONSTRUKTOR
        public Adatok()
        {
            this.FeladatLista = new FeladatLista<IFeladat>();
            this.MunkaeroLista = new MunkaeroLista<IMunkaero>();
        }

        //TULAJDONSÁGOK
        public FeladatLista<IFeladat> FeladatLista { get; set; }
        private readonly string feladatok = "feladatok.ileuxt";
        public MunkaeroLista<IMunkaero> MunkaeroLista { get; set; }
        private readonly string munkaero = "munkaero.ileuxt";
        private int LegkonnyebbFeladat = 5000;

        //METÓDUSOK
        public void Beolvas()
        {
            FBeolvas();
            MBeolvas();
        }
        private void FBeolvas()
        {
            StreamReader olvaso = new StreamReader(feladatok, Encoding.UTF7);
            while (!olvaso.EndOfStream) FeladatBevitel(olvaso.ReadLine());
            olvaso.Close();
        }
        private void FeladatBevitel(string mit)
        {
            string[] darabok = mit.Split(';');
            int id = Convert.ToInt32(darabok[0]);
            string nev = darabok[1];
            int szint = Convert.ToInt32(darabok[2]);
            if (szint < LegkonnyebbFeladat) LegkonnyebbFeladat = szint; //ez lesz a minimális képzettségi szint
            switch (nev)
            {
                case "Audit":
                    Audit audit = new Audit(){ID = id, Nev = nev, Szint = szint};
                    FeladatLista.Beszur(audit);
                    break;
                case "Értékesítés":
                    Ertekesites ertekesites = new Ertekesites(){ID = id, Nev = nev, Szint = szint};
                    FeladatLista.Beszur(ertekesites);
                    break;
                case "Gyártás":
                    Gyartas gyartas = new Gyartas(){ID = id, Nev = nev, Szint = szint};
                    FeladatLista.Beszur(gyartas);
                    break;
                case "Kiszállítás":
                    Kiszallitas kiszallitas = new Kiszallitas(){ID = id, Nev = nev, Szint = szint};
                    FeladatLista.Beszur(kiszallitas);
                    break;
                case "Ügyfélszolgálat":
                    Ugyfelszolgalat ugyfelszolgalat = new Ugyfelszolgalat(){ID = id, Nev = nev, Szint = szint};
                    FeladatLista.Beszur(ugyfelszolgalat);
                    break;
                default:
                    break;
            }
        }
        private void MBeolvas()
        {
            StreamReader olvaso = new StreamReader(munkaero, Encoding.UTF7);
            while (!olvaso.EndOfStream)
            {
                try { MunkaeroBevitel(olvaso.ReadLine()); }
                catch (AlacsonyKepzettsegException e)
                {
                    Console.WriteLine(e.HibaUzenet);
                    Tovabbkepzes(e.Munkaero);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        private void MunkaeroBevitel(string kit)
        {
            string[] darabok = kit.Split(';');
            int id = Convert.ToInt32(darabok[0]);
            string nev = darabok[1];
            string beosztas = darabok[2];
            int kepzettseg = Convert.ToInt32(darabok[3]);
            switch (beosztas)
            {
                case ("Auditor"):
                    Auditor auditor = new Auditor(id, nev, kepzettseg);
                    MunkaeroLista.Beszur(auditor);
                    if (auditor.Kepzettseg < LegkonnyebbFeladat)
                        throw new AlacsonyKepzettsegException(auditor);
                    break;
                case ("Esztergályos"):
                    Esztergalyos esztergalyos = new Esztergalyos(id, nev, kepzettseg);
                    MunkaeroLista.Beszur(esztergalyos);
                    if (esztergalyos.Kepzettseg < LegkonnyebbFeladat)
                        throw new AlacsonyKepzettsegException(esztergalyos);
                    break;
                case ("Futár"):
                    Futar futar = new Futar(id, nev, kepzettseg);
                    MunkaeroLista.Beszur(futar);
                    if (futar.Kepzettseg < LegkonnyebbFeladat)
                        throw new AlacsonyKepzettsegException(futar);
                    break;
                case ("Sales"):
                    Sales sales = new Sales(id, nev, kepzettseg);
                    MunkaeroLista.Beszur(sales);
                    if (sales.Kepzettseg < LegkonnyebbFeladat)
                        throw new AlacsonyKepzettsegException(sales);
                    break;
                case ("Szabadbölcsész"):
                    Szabadbolcsesz szabadbolcsesz = new Szabadbolcsesz(id, nev, kepzettseg);
                    MunkaeroLista.Beszur(szabadbolcsesz);
                    if (szabadbolcsesz.Kepzettseg < LegkonnyebbFeladat)
                        throw new AlacsonyKepzettsegException(szabadbolcsesz);
                    break;
                default:
                    break;
            }
        }
        private void Tovabbkepzes(IMunkaero munkaero)
        {
            IMunkaero tovabbkepzendo = munkaero;
            tovabbkepzendo.Kepzettseg = LegkonnyebbFeladat;
            try { MunkaeroLista[MunkaeroLista.IndexKeres(tovabbkepzendo)] = tovabbkepzendo; }
            catch (NemTalalhatoElemException e)
            {
                Console.WriteLine(e.HibaUzenet);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
