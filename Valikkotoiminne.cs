using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Ventti4
{
    
    class Valikkotoiminne : Valikko
    {
        internal Pelikierrokset Pelikierrokset;
        public Jakaja Jakaja;

        private string vastaus, valinta;                                                            //Luodaan muuttujia.
        private int p1kasi, p2kasi, pelikierros;                                                    //Luodaan muuttujia.
        Valikko valikko = new Valikko();                                                            //Luodaan olio valikko.
        Jakaja jakaja = new Jakaja();                                                               //Luodaan olio jakaja.
        Pelikierrokset pelikierrokset = new Pelikierrokset();                                       //Luodaan olio pelikierrokset.
        IFormatter oliotalllennus = new BinaryFormatter();                                          //Luodaan oliodatan tallennusta varten.

        public Valikkotoiminne(int pelikierros)                                                     //Luokan oletuskonstruktori joka saa arvon.
        {            
            this.pelikierros = pelikierros;                                                         //Tallennetaan saatu arvo luokan muuttujaan.
        }

        public void Suorita(string valinta)                                                         //Luokan metodi saa pelaajan antaman arvon.
        {
            this.valinta = valinta;                                                                 //Tallennetaan saatu arvo luokan muuttujaan.
            switch (valinta)                                                                        //Pelaajan valinnan perusteella tehdään toimenpide switch-casea hyödyntäen.
                {
                    case "p":                                                                       //Jos valinta p niin aloitetaan pelaamaan.                                                                                           //Kasvatetaan pelattujen kierrosten määrää.
                        jakaja.KysyP1panos(pelikierros);                                            //Jakaja luokan metodin kutsu. Kysytään pelaajalta panos.
                        jakaja.KysyP2panos(pelikierros);                                            //Jakaja luokan metodin kutsu. Kysytään pelaajalta panos.

                        jakaja.Clear();                                                             //Jakaja luokan metodin kutsu. Tyhjätään edellisen pelin kädet molemmilta pelaajilta.
                        do
                        {
                            vastaus = (jakaja.KysyP1());                                            //Jakaja luokan metodin kutsu. Kysytään halutaanko lisää kortteja. Tallennetaan saatu vastaus muuttujaan.        
                            if (vastaus == "k")                                                     //Jos pelaaja vastaa k eli haluaa lisää kortteja, mennään ehdon mukaisesti.
                            {
                                p1kasi = jakaja.KorttiP1();                                         //Jakaja luokan metodin kutsu. Tallennetaan saatu vastaus muuttujaan.  

                                if (p1kasi > 21)                                                    //Jos pelaajan käden summa isompi kui 21.
                                {
                                    jakaja.P1kasi_tulosta();                                        //Jakaja luokan metodin kutsu. Tulostetaan pelaajan käsi.
                                    break;                                                          //Lopetaan if lauseen suoritus.
                                }
                                jakaja.P1kasi_tulosta();                                            //Jakaja luokan metodin kutsu. Tulostetaan pelaajan käsi.
                            pelikierrokset.p1kasi = p1kasi;                                         //Tallennetaan Pelikierrokset luokan muuttujaan pelaajan 1 käsi.
                            }
                        } while (vastaus != "e");                                                   //Kysytään kortteja niin pitkää kunnes pelaaja 1 valitsee e (tai korttíe summa ylittää 21).

                        do
                        {
                            vastaus = (jakaja.KysyP2());                                            //Jakaja luokan metodin kutsu. Kysytään halutaanko lisää kortteja. Tallennetaan saatu vastaus muuttujaan.
                        if (vastaus == "k")                                                         //Jos pelaaja vastaa k eli haluaa lisää kortteja, mennään ehdon mukaisesti.
                            {
                                p2kasi = jakaja.KorttiP2();                                         //Jakaja luokan metodin kutsu. Tallennetaan saatu vastaus muuttujaan.  
                                if (p2kasi > 21)                                                    //Jos pelaajan käden summa isompi kui 21.
                                {
                                    jakaja.P2kasi_tulosta();                                        //Jakaja luokan metodin kutsu. Tulostetaan pelaajan käsi.
                                    break;                                                          //Lopetaan if lauseen suoritus.
                                }
                                jakaja.P2kasi_tulosta();                                            //Jakaja luokan metodin kutsu. Tulostetaan pelaajan käsi.
                            }
                            pelikierrokset.p2kasi = p2kasi;                                         //Tallennetaan Pelikierrokset luokan muuttujaan pelaajan 1 käsi.
                        } while (vastaus != "e");                                                   //Kysytään kortteja niin pitkää kunnes pelaaja 2 valitsee e (tai korttíe summa ylittää 21).

                        jakaja.Vertaa();                                                            //Jakaja luokan metodin kutsu. Verrataan pelaajien kädet, kumpi voittaa.
                        pelikierros++;                                                              //Lasketaan pelikierrosten määrä.
                        pelikierrokset.pelikierros_lkm = pelikierros;                               //Tallennetaan Pelikierrokset luokan muuttujaan pelaajan 1 käsi.

                        //Tallennetaan olion data tiedostoon.
                        Stream stream = new FileStream("kierrokset.txt", FileMode.Create, FileAccess.Write);
                        oliotalllennus.Serialize(stream, pelikierrokset);
                        stream.Close();

                        break;                                                                      //Switch-case lopetus.

                    case "v":                                                                       //Pelaajan valinnan perusteella tehdään toimenpide switch-casea hyödyntäen.
                        valikko.TulostaValikko();                                                   //Tulostetaan valikko omasta luokasta.
                        break;                                                                      //Switch-case lopetus.

                    case "s":                                                                       //Pelaajan valinnan perusteella tehdään toimenpide switch-casea hyödyntäen.
                        if (pelikierros == 0)                                                       //Jos kyseessä ensimmäinen pelikierros tulostetaan pelaajien alkusaldot.
                        {
                            Console.WriteLine("Pelaajan 1 saldo 100 rahaa.\nPelaajan 2 saldo 100 rahaa.");
                        }
                        else jakaja.TulostaSaldot();                                                //Jos pelikierroksia useampi, Jakaja luokan metodin kutsu.
                        break;                                                                      //Switch-case lopetus.

                    case "t":                                                                       //Pelaajan valinnan perusteella tehdään toimenpide switch-casea hyödyntäen.
                        string line;                                                                //Apumuttuujan luonti.
                        int p1 = 0, p2 = 0;                                                         //Apumuttujien luonti.

                        if (!File.Exists(@"p1voitot.txt"))                                          //Tarkistetaan löytyykö tiedostoa.
                        {
                            p1 = 0;                                                                 //Ellei löydy muuttujalle arvo 0 (eli pelaaja 1 ei ole voittanut yhtään peliä).
                        }
                        else
                        {
                            StreamReader file1 = new StreamReader("p1voitot.txt");                  //Luetaan tiedostosta pelaajan 1 voitot.
                            while ((line = file1.ReadLine()) != null)                               //Jokainen voitto kirjoitetaan arvolla 1 omalle rivilleen. Luetaan tiedostoa kunnes rivi on tyhjä.            
                            {
                                int luku = int.Parse(line);                                         //Muunnetaan luettu arvo numeeriikseksi ja tallennetaan se luku muuttujaan.
                                p1 = luku + p1;                                                     //Lasketaan muuttujaan pelaajan 1 voitot.
                            }
                            file1.Close();                                                          //Suljetaan lopuksi tiedosto.
                        }

                        if (!File.Exists(@"p2voitot.txt"))                                          //Tarkistetaan löytyykö tiedostoa.
                        {
                            p2 = 0;                                                                 //Ellei löydy muuttujalle arvo 0 (eli pelaaja 1 ei ole voittanut yhtään peliä).
                        }
                        else
                        {
                            StreamReader file2 = new StreamReader("p2voitot.txt");                  //Luetaan tiedostosta pelaajan 2 voitot.
                            while ((line = file2.ReadLine()) != null)                               //Jokainen voitto kirjoitetaan arvolla 1 omalle rivilleen. Luetaan tiedostoa kunnes rivi on tyhjä.
                            {
                                int luku = int.Parse(line);                                         //Muunnetaan luettu arvo numeeriikseksi ja tallennetaan se luku muuttujaan.
                                p2 = luku + p2;                                                     //Lasketaan muuttujaan pelaajan 1 voitot.
                            }
                            file2.Close();                                                          //Suljetaan lopuksi tiedosto.
                        }

                        if (File.Exists(@"kierrokset.txt"))                                         //Tarkistetaan löytyykö tiedosto.
                        {
                        //Tallennetaan data tiedostosta ja tallennetaan olioon.
                        stream = new FileStream("kierrokset.txt", FileMode.Open, FileAccess.Read);
                        Pelikierrokset pelikierrokset_luku = (Pelikierrokset)oliotalllennus.Deserialize(stream);
                        stream.Close();
                        Console.WriteLine("Pelikierroksia {2}.\nViimeisimmässä pelissä pelaajan 1 käsi {3} ja pelaajan 2 käsi {4}.\nPelaajalla 1 on {0} voittoa ja pelaajalla 2 on {1} voittoa.", p1, p2, pelikierrokset_luku.pelikierros_lkm, pelikierrokset_luku.p1kasi, pelikierrokset_luku.p2kasi);   //Tulostetaan pelaajien saldot.
                        break;
                        }
                   
                        Console.WriteLine("Pelikierroksia 0. Pelaajalla 1 on {0} voittoa ja pelaajalla 2 on {1} voittoa.", p1, p2);   //Tulostetaan pelaajien saldot.
                        break;                                                                      //Switch-case lopetus.

                    case "q":                                                                       //Pelaajan valinnan perusteella tehdään toimenpide switch-casea hyödyntäen.
                        TulostaValikko();                                                           //Kun peli lopetaan hyödynnetään metodin ylikirjoittamista.
                        break;                                                                      //Switch-case lopetus.
                }
        }

        public override void TulostaValikko()                                                       //Metodin ylikirjoitus.
        {
            Console.WriteLine("Kiitos että pelasit!");
            Console.ReadKey();
        }

    }
}
