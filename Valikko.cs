using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventti4
{
    class Valikko
    {
        public Valikko()                                                                    //Luokan konstruktori.
        {                        
        }

        public Valikko(ref Valikko valikko)                                                 //Viittaus pääohjelman olioon.
        {
            DateTime now = DateTime.Now;                                                    //Tallennetaan muuttujaan tämänhetkinen aika.
            Console.WriteLine("Kello on nyt: {0}", now);                                    //Tulostetaan tämänhetkinen aika.        
        }

        public virtual void TulostaValikko()                                                //Peliä varten on valikko, se tulostetaan omassa luokassa metodilla.
        {
            Console.WriteLine("\nValikko:\n");
            Console.WriteLine("[p] Pelaa");                                                 //Peliä ohjataan kirjainkomennoilla.
            Console.WriteLine("[s] Tarkista pelaajien saldo");
            Console.WriteLine("[t] Pelitilastot");
            Console.WriteLine("[v] Tulosta valikko");
            Console.WriteLine("[q] Lopeta");
        }


    }
}
