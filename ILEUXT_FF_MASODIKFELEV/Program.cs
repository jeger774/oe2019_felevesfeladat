using System;

namespace ILEUXT_FF_MASODIKFELEV
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                                        szövegfájlban ;-vel elválasztott adatok
            feladatok.txt:    első oszlop:ID  második oszlop:név  harmadik oszlop:minimum képzettségi szint
            munkaero.txt:     első oszlop:ID  második oszlop:név  harmadik oszlop:beosztás    negyedik oszlop:képzettségi szint 
            */
            Console.WriteLine("Az adatok a feladatok.txt és munkaero.txt fájlokban vannak tárolva. (.\\bin\\debug\\)\n");
            Adatok adatbazis = new Adatok();
            adatbazis.Beolvas();
            Kiosztas feladatkiosztas = new Kiosztas(adatbazis);
            feladatkiosztas.Start();
            Console.ReadKey();
        }
    }
}
