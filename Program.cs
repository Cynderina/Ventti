using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventti4
{
    class Program
    {
        internal Valikko Valikko;
        internal Valikkotoiminne Valikkotoiminne;
        internal Tiedostot Tiedostot;

        static void Main(string[] args)
        {   
            string valinta="";                                                                  //Muuttujalle oletusarvo.
            int pelikierros=0;                                                                  //Muuttuja millä pidetään kirjaa pelatuista kierroksista.
            Valikko valikko = new Valikko();                                                    //Luodaan olio.
            Tiedostot tuhoa = new Tiedostot();                                                  //Luodaan olio.
            Valikkotoiminne suorita = new Valikkotoiminne(pelikierros);                         //Luodaan olio ja viedään luokan konstruktorille luontivaiheessa muuttuja.

            Console.WriteLine("Ventti 1.0.\n");                                                 //Tulostetaan otsikko.
            Valikko aika = new Valikko(ref valikko);                                            //Viitataan valikko luokan metodiin.
            tuhoa.Filet();                                                                      //Tuhotaan tiedostot mikäli sellaisia on jäänyt edelliseltä pelikerralta.
            valikko.TulostaValikko();                                                           //Tulostetaan valikko

            do                                                                                  //Pyöritetaan do-while silmukkaa kunnes pelaaja lopettaa pelin.
            {                
                Console.Write("\nMitäs tehdään? ");                                             //Kysytään pelaajalta mitä hän haluaa tehdä.
                valinta = Console.ReadLine();                                                   //Pelaajan antama valinta tallennetaan muuttujaan.                
                suorita.Suorita(valinta);                                                       //Viedään pelaajan valinta luokan valikkotoiminteen metodille.
               
            } while (valinta != "q");                                                           //Peliä pelataan niin pitkään kunnes pelaaja lopettaa pelin.
        }
    }
}
