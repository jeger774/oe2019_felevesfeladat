using System;
using System.Collections;

namespace ILEUXT_FF_MASODIKFELEV
{
    class FeladatLista<T> : IEnumerable, IEnumerator where T : IFeladat
    {
        //KONSTRUKTOR
        public FeladatLista()
        {
            fej = null;
            mutato = fej;
            Szamlalo = 0;
        }
        //TULAJDONSÁGOK
        class ListaElem
        {
            public T tartalom;
            public ListaElem kovetkezo;
            public int kulcs;
        }
        private ListaElem fej;
        private ListaElem mutato;
        public int Szamlalo { get; set; }
        public object Current{ get { return mutato.tartalom; } }

        //METÓDUSOK
        public IEnumerator GetEnumerator()
        {
            return this;
        }
        public bool MoveNext()
        {
            if (mutato == null)
            {
                mutato = fej;
                return true;
            }
            else if (mutato.kovetkezo == null)
            {
                mutato = mutato.kovetkezo;
                return true;
            }
            else
            {
                this.Reset();
                return false;
            }
        }
        public void Reset()
        {
            mutato = null;
        }
        public void Beszur(T elem)
        {
            ListaElem uj = new ListaElem();
            ListaElem p = new ListaElem();
            ListaElem e = new ListaElem();
            uj.tartalom = elem;
            uj.kulcs = elem.Szint;
            p = fej;
            e = null;
            bool utkozes = false;
            while (p != null && p.tartalom.ID != elem.ID)
                p = p.kovetkezo;
            if (p != null)
                utkozes = true;
            p = fej;
            if (!utkozes)
            {
                while (p != null && p.kulcs > uj.kulcs)
                {
                    e = p;
                    p = p.kovetkezo;
                }
                if (e == null)
                {
                    uj.kovetkezo = fej;
                    fej = uj;
                }
                else
                {
                    uj.kovetkezo = p;
                    e.kovetkezo = uj;
                }
                Szamlalo++;
            }
        }
        public void Bejaras()
        {
            ListaElem p = fej;
            while (p != null)
            {
                Feldolgoz(p);
                p = p.kovetkezo;
            }
        }
        private void Feldolgoz(ListaElem elem)
        {
            Console.WriteLine(elem.tartalom);
        }
        public T this[int i]
        {
            get { return Kereses(i); }
            set { Modositas(i, value); }
        }
        private T Kereses(int i)
        {
            ListaElem p = fej;
            int szamlalo = 0;
            while (p != null && szamlalo < i)
            {
                p = p.kovetkezo;
                szamlalo++;
            }
            if (p != null && szamlalo == i)
            {
                return p.tartalom;
            }
            else
            {
                throw new Exception();
            }
        }
        private void Modositas(int index, T uj)
        {
            ListaElem p = fej;
            int szamlalo = 0;
            while (p != null && szamlalo < index)
            {
                p = p.kovetkezo;
                szamlalo++;
            }
            if (p != null && szamlalo == index)
            {
                Torles(p.tartalom);
                Beszur(uj);
            }
        }
        private void Torles(T elem)
        {
            ListaElem p = fej;
            ListaElem e = null;
            while (p != null && !p.tartalom.Equals(elem))
            {
                e = p;
                p = p.kovetkezo;
            }
            if (p != null)
            {
                if (e == null)
                {
                    fej = p.kovetkezo;
                }
                else
                {
                    e.kovetkezo = p.kovetkezo;
                }
                p = null;
                Szamlalo--;
            }
        }
    }
}
