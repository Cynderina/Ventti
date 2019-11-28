using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Ventti4
{
    public class Valvoja
    {
        private int p1kasi, p2kasi;
        public int winner;

        public int Tuomio()                                                        //Metodi jolla kerrotaan kuka voittaa pelin.
        {
            if (p1kasi > 21 && p2kasi > 21)                                        //Verrataan saatuja käsien summia.
            {
                Console.WriteLine("\nMOLEMMAT PELAAJAT HÄVIÄÄ, TALO VOITTAA!");
                return winner = 4;                                                 //Jos talo voittaa, palautetaan arvo 4.
            }
            else if (p1kasi > 21)                                                  //Verrataan saatuja käsien summia.
            {
                Console.WriteLine("\nPELAAJA 2 VOITTAA!");
                File.AppendAllText("p2voitot.txt", "1\n");                         //Tallenetaan pelaajan 2 voitot tiedostoon.
                return winner = 2;                                                 //Jos pelaaja 2 voittaa palautetaan arvo 2. Hyödynnetään saldojen päivittäämisessä Jakaja luokassa.
            }
            else if (p2kasi > 21)                                                  //Verrataan saatuja käsien summia.
            {
                Console.WriteLine("\nPELAAJA 1 VOITTAA!");
                File.AppendAllText("p1voitot.txt", "1\n");                         //Tallenetaan pelaajan 1 voitot tiedostoon.
                return winner = 1;                                                 //Jos pelaaja 1 voittaa palautetaan arvo 1. Hyödynnetään saldojen päivittäämisessä Jakaja luokassa.
            }
            else if (p1kasi > p2kasi)                                              //Verrataan saatuja käsien summia.
            {
                Console.WriteLine("\nPELAAJA 1 VOITTAA!");
                File.AppendAllText("p1voitot.txt", "1\n");                         //Tallenetaan pelaajan 1 voitot tiedostoon.
                return winner = 1;                                                 //Jos pelaaja 1 voittaa palautetaan arvo 1. Hyödynnetään saldojen päivittäämisessä Jakaja luokassa.
            }
            else if (p2kasi > p1kasi)                                              //Verrataan saatuja käsien summia.
            {
                Console.WriteLine("\nPELAAJA 2 VOITTAA!");  
                File.AppendAllText("p2voitot.txt", "1\n");                         //Tallenetaan pelaajan 2 voitot tiedostoon.
                return winner = 2;                                                 //Jos pelaaja 2 voittaa palautetaan arvo 2. Hyödynnetään saldojen päivittäämisessä Jakaja luokassa.
            }
            else
            {
                Console.WriteLine("\nTASAPELI!");
                return winner = 3;                                                 //Jos tasapeli palautetaan arvo 3. Hyödynnetään saldojen päivittäämisessä Jakaja luokassa.
            }
        }
        public int Pelaaja1
        {
            set
            {
                p1kasi = value;                                                     //Saadaa Jakaja luokalta pelaajan 1 käsi.
            }
            get
            {
                return p1kasi;
            }
        }
        public int Pelaaja2
        {
            set
            {
                p2kasi = value;                                                     //Saadaa Jakaja luokalta pelaajan 2 käsi.
            }
            get
            {
                return p2kasi;
            }
        }
    }
}