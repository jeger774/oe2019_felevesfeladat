using System;

namespace ILEUXT_FF_MASODIKFELEV
{
    sealed class Kiosztas
    {
        //KONSTRUKTOR
        public Kiosztas(Adatok adatok)
        {
            this.Munkaero = adatok.MunkaeroLista;
            this.Kiosztando = adatok.FeladatLista;
        }

        //TULAJDONSÁGOK
        public FeladatLista<IFeladat> Kiosztando { get; private set; }
        public MunkaeroLista<IMunkaero> Munkaero { get; private set; }
        private FeladatLista<IFeladat> kiosztott = new FeladatLista<IFeladat>(); //Ide kerülnek a már kiosztott feladatok
        private const int MaxF = 5; //Egy ember maximum ennyi feladatot kaphat meg

        //ESEMÉNY
        public delegate void FeladatEventHandler(object src, FeladatEventArgs a);
        public event FeladatEventHandler KiosztvaHandler;
        public void OnFeladatokKiosztva() { KiosztvaHandler?.Invoke(this, new FeladatEventArgs(Munkaero, Kiosztando, kiosztott)); }

        //METÓDUSOK
        private bool Ft(int szint, IMunkaero munkaero) //képzettség ellenőrzése
        {
            if (munkaero.ElvegzendoFeladatok.Szamlalo < MaxF && Kiosztando[szint].Szint <= munkaero.Kepzettseg)
                return true;
            else return false;
        }
        private bool Fk(int szint, IMunkaero m, IMunkaero[] munkaero) //kapacitás ellenőrzése
        {
            for (int i = 0; i < munkaero.Length; i++)
            {
                if (munkaero[i] != m)
                {
                    if (munkaero[i].Kepzettseg < m.Kepzettseg)
                    {
                        if (munkaero[i].Kepzettseg >= Kiosztando[szint].Szint)
                        {
                            if (munkaero[i].ElvegzendoFeladatok.Szamlalo < MaxF)
                            {
                                return false;
                            }
                            else return true;
                        }
                        else return true;
                    }
                    else return true;
                }
            }
            return true;
        }
        public void Optimalizalas(int szint, ref FeladatLista<IFeladat> kiosztott)
        {
            for (int i = 0; i < szint; i++)
            {
                bool reszmegoldas = false;
                IMunkaero[] M = Reszmegoldasok(i);
                int j = 0;
                while (j < M.Length && !reszmegoldas)
                {
                    if (Ft(i, M[j]))
                    {
                        if (Fk(i, M[j], M))
                        {
                            Kiosztando[i].Munkaero = M[j];
                            M[j].ElvegzendoFeladatok.Beszur(Kiosztando[i]);
                            Munkaero[Munkaero.IndexKeres(M[j])] = M[j];
                            reszmegoldas = true;
                            kiosztott.Beszur(Kiosztando[i]);
                        }
                    }
                    j++;
                }
            }
        }
        private IMunkaero[] Reszmegoldasok(int szint) //Részmegoldások keresése a megadott szinten
        {
            int k = 0;
            for (int i = 0; i < Munkaero.Szamlalo; i++)
            {
                if ((Munkaero[i] as Munkaero).Beosztas == (Kiosztando[szint] as Feladat).Beosztas)
                {
                    k++;
                }
            }
            IMunkaero[] M = new IMunkaero[k];
            k = 0;
            for (int i = 0; i < Munkaero.Szamlalo; i++)
            {
                if ((Munkaero[i] as Munkaero).Beosztas == (Kiosztando[szint] as Feladat).Beosztas)
                {
                    M[k++] = Munkaero[i];
                }
            }
            return M;
        }
        private void EsemenyFeliratkoztatas()
        {
            FeladatEventService feladatSvc = new FeladatEventService();
            KiosztvaHandler += feladatSvc.Kiosztott;
            KiosztvaHandler += feladatSvc.Kiosztando;
            KiosztvaHandler += feladatSvc.SzabadMunkaero;
        }
        public void Start()
        {
            Optimalizalas(Kiosztando.Szamlalo, ref kiosztott);
            EsemenyFeliratkoztatas();
            OnFeladatokKiosztva();
        }
    }
}
