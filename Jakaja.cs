using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ventti4
{
    public class Jakaja : Pankki, IPankki
    {
        internal Valvoja Valvoja;

        List<int> P1Kasi = new List<int>();                                                     //Luodaan pelaajaa1 varten lista jonne tallennetaan saadut kortit.
        List<int> P2Kasi = new List<int>();                                                     //Luodaan pelaajaa2 varten lista jonne tallennetaan saadut kortit.
        IPankki p1pankki = new Pankki();                                                        //Luodaan olio rajapinnan kautta.
        IPankki p2pankki = new Pankki();                                                        //Luodaan olio rajapinnan kautta.
        IPelipoyta pelaaja1 = new Pelaaja1();                                                   //Luodaan olio rajapinnan kautta.
        IPelipoyta pelaaja2 = new Pelaaja2();                                                   //Luodaan olio rajapinnan kautta.
        IKortti korttiP1 = new Korttipakka();                                                   //Luodaan olio rajapinnan kautta.
        IKortti korttiP2 = new Korttipakka();                                                   //Luodaan olio rajapinnan kautta.
        Valvoja voittaja = new Valvoja();                                                       //Luodaan olio.
        int kierrosP1, kierrosP2;
        private double summaP1, summaP2;        

        public void KysyP1panos(int pelikierros)                                                //Metodi jolla kysytään pelaajan 1 panos. Saadaan arvo pelikierros.   
        {            
            kierrosP1 = pelikierros;                                                            //Tallennetaan se paikalliseen muuttujaan.

            if (kierrosP1==0)                                                                   //Annetun alkusaldon takia ensimmäisellä pelikierroksella verrataan annettua panosta alkusaldoon.
            {
                do
                {
                    Console.Write("\nPaljon panostat pelaaja1 (anna arvo numeerisena) ? ");
                    summaP1 = pelaaja1.Panos();                                                 //Pelaaja1 luokan metodi palauttaa vastauksen jakajan esittämään kysymykseen.

                    if (summaP1 <= 0)                                                           //Panostaa pitää vähintään 1 rahan verran.
                    {
                        Console.WriteLine("Joudut panostamaan vähintään 1 rahan.\n");
                        summaP1 = 101;                                                          //Jos syötetään panos alle 0 tai alle niin asetetaan väliaikaisest muuttujan arvoksi 101.
                    }
                    else if (summaP1 > p1pankki.P1Alkusaldo())                                  //Panosta ei voi antaa kuitenkaan enempää kuin on saldoa. Kysytään pankilta pelaajan saldo.
                    {
                        Console.WriteLine("Pelaajan aloitussaldo on 100 rahaa!");
                    }
                } while (summaP1 > p1pankki.P1Alkusaldo());                                     //Kysellään kunnes panos saadaan.
                p1pankki.SaldoP1_1(summaP1);                                                    //Lasketaan pelaajalle uusi saldo pankkiin.
            }
            else                                                                                //Jos kyseessä 2-n pelikierros siirrytään suoraan tänne.
            {
                do
                {
                    Console.Write("\nPaljon panostat pelaaja1 (anna arvo numeerisena) ? ");
                    summaP1 = pelaaja1.Panos();                                                 //Pelaaja1 luokan metodi palauttaa vastauksen jakajan esittämään kysymykseen.

                    if (summaP1 <= 0)                                                           //Panostaa pitää vähintään 1 rahan verran.
                    {
                        Console.WriteLine("Joudut panostamaan vähintään 1 rahan.\n");
                        summaP1 = 101;                                                          //Jos syötetään panos alle 0 tai alle niin asetetaan väliaikaisest muuttujan arvoksi 101.
                    }
                    else if (summaP1 > p1pankki.P1Saldo())                                      //Panosta ei voi antaa kuitenkaan enempää kuin on saldoa. Kysytään pankilta pelaajan saldo.
                    {
                        Console.WriteLine("Pankin saldo on {0} rahaa!\n", P1Saldo());
                    }
                } while (summaP1 > p1pankki.P1Saldo());                                         //Kysellään kunnes panos saadaan.
                p1pankki.SaldoP1_2(summaP1);                                                    //Lasketaan pelaajalle uusi saldo pankkiin.
            }
        }

        public void KysyP2panos(int pelikierros)                                                //Metodi jolla kysytään pelaajan 2 panos. Saadaan arvo pelikierros.   
        {
            kierrosP2=pelikierros;                                                              //Tallennetaan se paikalliseen muuttujaan.

            if (kierrosP2 == 0)                                                                 //Annetun alkusaldon takia ensimmäisellä pelikierroksella verrataan annettua panosta alkusaldoon.
            {
                do
                {
                    Console.Write("Paljon panostat pelaaja2 (anna arvo numeerisena) ? ");
                    summaP2 = pelaaja2.Panos();                                                 //Pelaaja2 luokan metodi palauttaa vastauksen jakajan esittämään kysymykseen.

                    if (summaP2 <= 0)                                                           //Panostaa pitää vähintään 1 rahan verran.
                    {
                        Console.WriteLine("Joudut panostamaan vähintään 1 rahan.\n");
                        summaP2 = 101;                                                          //Jos syötetään panos alle 0 tai alle niin asetetaan väliaikaisest muuttujan arvoksi 101.
                    }
                    else if (summaP2 > p2pankki.P2Alkusaldo())                                  //Panosta ei voi antaa kuitenkaan enempää kuin on saldoa. Kysytään pankilta pelaajan saldo.
                    {
                        Console.WriteLine("Pelaajan aloitussaldo on 100 rahaa!\n");
                    }
                } while (summaP2 > p2pankki.P2Alkusaldo());                                     //Kysellään kunnes panos saadaan.
                p2pankki.SaldoP2_1(summaP2);                                                    //Lasketaan pelaajalle uusi saldo pankkiin.
            }
            else                                                                                //Jos kyseessä 2-n pelikierros siirrytään suoraan tänne
            {
                do
                {
                    Console.Write("Paljon panostat pelaaja2 (anna arvo numeerisena) ? ");
                    summaP2 = pelaaja2.Panos();                                                 //Pelaaja2 luokan metodi palauttaa vastauksen jakajan esittämään kysymykseen.

                    if (summaP2 <= 0)                                                           //Panostaa pitää vähintään 1 rahan verran.
                    {
                        Console.WriteLine("Joudut panostamaan vähintään 1 rahan.\n");       
                        summaP2 = 101;                                                          //Jos syötetään panos alle 0 tai alle niin asetetaan väliaikaisest muuttujan arvoksi 101.
                    }
                    else if (summaP2 > p2pankki.P2Saldo())                                      //Panosta ei voi antaa kuitenkaan enempää kuin on saldoa. Kysytään pankilta pelaajan saldo.
                    {
                        Console.WriteLine("Pankin saldo on {0} rahaa!\n", P2Saldo());
                    }
                } while (summaP2 > p2pankki.P2Saldo());                                         //Kysellään kunnes panos saadaan.
                p2pankki.SaldoP2_2(summaP2);                                                    //Lasketaan pelaajalle uusi saldo pankkiin.
            }
        }    

        public void Clear()                                                                     //Metodi jolla putsataan kunkin pelikierroksen alussa pelaajien kädet. 
        {
            P1Kasi.Clear();                                                                     //Tyhjennetään pelaajan 1 käsi (=taulukko).
            P2Kasi.Clear();                                                                     //Tyhjennetään pelaajan 1 käsi (=taulukko).
        }

        public string KysyP1()                                                                  //Metodi jolla kysytään pelaajalle 1 kortteja.
        {
            Console.Write("\nLisää kortteja pelaaja 1 (k = lisää, e = lopeta) ? ");
            return pelaaja1.Vastaus();                                                          //Pelaaja1 luokan metodin kutsu. Palautetaan saatu vastaus.
        }
                
        public int KorttiP1()                                                                   //Metodi jolla saadaan uusi kortti pelaajalle 1.
        {
            int p1summa;            
            P1Kasi.Add(korttiP1.Vastaus());                                                     //Lisätään pelaajan 1 käteen (listaan) rajapinnan kautta saatu kortti.
            return p1summa = P1Kasi.Sum();                                                      //Lasketaan listassa olevat arvot ja palautetaan pelaajan 1 käden summa.
        }        

        public void P1kasi_tulosta()                                                            //Metodi jolla tulostetaan pelaajan 1 käsi.
        {
            int apu = P1Kasi.Count;                                                             //Lasketaan apu muuttujaan montako korttia on pelaaja1 ottanut.
            for (int i = 0; i < apu; i++)                                                       //Pyöritetään for silmukka niin monta kertaa kuin on kortteja.
            {
                Console.WriteLine("{0} korttisi on {1}", i + 1, P1Kasi[i]);                     //Tulostetaan monesko kortti on mikä kortti on.
            }
            Console.WriteLine("Korttien summa {0}", P1Kasi.Sum());                              //Tulostetaan lopuksi korttien summa.
        }
        
        public string KysyP2()                                                                  //Metodi jolla kysytään pelaajalle 1 kortteja.
        {
            Console.Write("\nLisää kortteja pelaaja 2 (k = lisää, e = lopeta) ? ");
            return pelaaja2.Vastaus();                                                          //Pelaaja1 luokan metodin kutsu. Palautetaan saatu vastaus.
        }

        public int KorttiP2()                                                                   //Metodi jolla saadaan uusi kortti pelaajalle 1.
        {
            int p2summa;

            P2Kasi.Add(korttiP2.Vastaus());                                                     //Lisätään pelaajan 2 käteen (listaan) rajapinnan kautta saatu kortti.
            return p2summa = P2Kasi.Sum();                                                      //Lasketaan listassa olevat arvot ja palautetaan pelaajan 2 käden summa.
        }

        public void P2kasi_tulosta()                                                            //Metodi jolla tulostetaan pelaajan 2 käsi.
        {
            int apu = P2Kasi.Count;                                                             //Lasketaan apu muuttujaan montako korttia on pelaaja2 ottanut.
            for (int i = 0; i < apu; i++)                                                       //Pyöritetään for silmukka niin monta kertaa kuin on kortteja.
            {
                Console.WriteLine("{0} korttisi on {1}", i + 1, P2Kasi[i]);                     //Tulostetaan monesko kortti on mikä kortti on.
            }
            Console.WriteLine("Korttien summa {0}", P2Kasi.Sum());                              //Tulostetaan lopuksi korttien summa.
        }

        public void Vertaa()                                                                    //Metodi jolla verrataan pelaajien käsi.
        {
            int winner;
            
            voittaja.Pelaaja1 = P1Kasi.Sum();                                                   //Viedään Valvoja luokalle pelaajan 1 käden summa.
            voittaja.Pelaaja2 = P2Kasi.Sum();                                                   //Viedään Valvoja luokalle pelaajan 2 käden summa.
            winner = voittaja.Tuomio();                                                         //Tallennetaan palautuva arvo muuttujaan.
            if (winner == 1)                                                                    //Jos palautuva arvo 1 (eli pelaaja 1 voittaa).
            {
                p1pankki.SaldoP1_3(summaP1+summaP2);                                            //Viedään pankille tieto ja tallennetaan pelaajalle 1 uusi saldo (oma annettu panos ja pelaajalta 2 voitettu raha).                
            }
            else if (winner == 2)                                                               //Jos palautuva arvo 2 (eli pelaaja 2 voittaa).
            {
                p2pankki.SaldoP2_3(summaP1+summaP2);                                            //Viedään pankille tieto ja tallennetaan pelaajalle 2 uusi saldo (oma annettu panos ja pelaajalta 1 voitettu raha).
            }
            else if (winner == 3)                                                               //Jos palautuva arvo 3 (eli tasapeli).
            {
                p1pankki.SaldoP1_3(summaP1);                                                    //Viedään pankille tieto ja tallennetaan pelaajalle 1 takaisin annettu oma panos.
                p2pankki.SaldoP2_3(summaP2);                                                    //Viedään pankille tieto ja tallennetaan pelaajalle 2 takaisin annettu oma panos.
            }
        }
        public void TulostaSaldot()                                                             //Metodi jolla tulostetaan pelaajien pankin saldot.
        {
            Console.WriteLine("Pelaajan 1 saldo {0}.\nPelaajan 2 saldo {1}.\n", p1pankki.P1Saldo(), p2pankki.P2Saldo());  //Kysytään pankilta saldot tulostukseen.
        }

        public override double P1Saldo()                                                         //Metodi jolla tulostetaan pelaajien pankin saldot. Hyödynnetään polymorfismia.
        {
            return p1pankki.P1Saldo();
        }
        public override double P2Saldo()                                                         //Metodi jolla tulostetaan pelaajien pankin saldot. Hyödynnetään polymorfismia.
        {
            return p2pankki.P2Saldo();
        }
    }
}