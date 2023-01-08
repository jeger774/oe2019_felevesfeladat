using System;
using System.Collections;

namespace ILEUXT_FF_MASODIKFELEV
{
    class MunkaeroLista<T> : IEnumerable, IEnumerator where T : IMunkaero
    {
        //KONSTRUKTOR
        public MunkaeroLista()
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
        public object Current { get { return mutato.tartalom; } }

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
            uj.kulcs = elem.Kepzettseg;
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
            get { return Keres(i); }
            set { Modosit(i, value); }
        }
        private T Keres(int i)
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
        private void Modosit(int index, T uj)
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
            ListaElem p = new ListaElem();
            ListaElem e = new ListaElem();
            p = fej;
            e = null;
            while (p != null && !p.tartalom.Equals(elem))
            {
                e = p;
                p = p.kovetkezo;
            }
            if (p != null)
            {
                if (e == null)
                    fej = p.kovetkezo;
                else
                    e.kovetkezo = p.kovetkezo;
                p = null;
                Szamlalo--;
            }
            else throw new NemTalalhatoElemException();
        }
        public int IndexKeres(T elem)
        {
            for (int i = 0; i < this.Szamlalo; i++)
            {
                if (this[i].Equals(elem))
                {
                    return i;
                }
            }
            throw new NemTalalhatoElemException();
        }
    }
}
