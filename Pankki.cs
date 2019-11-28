using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ventti4
{
    
    public class Pankki : IPankki
    {
        public double p1alkusaldo = 100, p2alkusaldo = 100, p1saldo, p2saldo;

        public void SaldoP1_1(double p1panos)                                   //Metodi pelaajan1 ensimmäistä pelikierrosta varten. Saadaan pelaajan 1 syöttämä panos.
        {
            p1saldo = p1alkusaldo - p1panos;                                    //Vähennetään alkusaldosta annettu panos.
        }
        public void SaldoP1_2(double p1panos)                                   //Metodi pelaajan 1 2-n pelikierrosta varten. Saadaan pelaajan 1 syöttämä panos.
        {
            p1saldo = p1saldo - p1panos;                                        //Jos pelaaja 1 on hävinnyt, vähennetaan saldosta annettu panos.
        }
        public void SaldoP1_3(double p1panos)                                   //Metodi pelaajan 1 2-n pelikierrosta varten. Saadaan pelaajan 1 syöttämä panos.
        {
            p1saldo = p1saldo + p1panos;                                        //Jos pelaaja 1 on voittanut, lisätään saldoon voitettu panos (+ oma panos mikä saatu jakaja luokalta).
        }

        public void SaldoP2_1(double p2panos)                                   //Metodi pelaajan1 ensimmäistä pelikierrosta varten.  Saadaan pelaajan 2 syöttämä panos.
        {
            p2saldo = p2alkusaldo - p2panos;                                    //Vähennetään alkusaldosta annettu panos.
        }
        public void SaldoP2_2(double p2panos)                                   //Metodi pelaajan 2 2-n pelikierrosta varten. Saadaan pelaajan 2 syöttämä panos.
        {
            p2saldo = p2saldo - p2panos;                                        //Jos pelaaja 2 on hävinnyt, vähennetaan saldosta annettu panos.
        }
        public void SaldoP2_3(double p2panos)                                   //Metodi pelaajan 2 2-n pelikierrosta varten. Saadaan pelaajan 2 syöttämä panos.
        {
            p2saldo = p2saldo + p2panos;                                        //Jos pelaaja 2 on voittanut, lisätään saldoon voitettu panos (+ oma panos mikä saatu jakaja luokalta).
        }
        public double P1Alkusaldo()                                             //Metodi joka palauttaa alkusaldon. Hyödynnetään Jakaja luokassa.
        {
            return p1alkusaldo;
        }
        public virtual double P1Saldo()                                         //Metodi joka palauttaa pelaajan saldon pelin edetessä. Hyödynnetään Jakaja luokassa.
        {
            return p1saldo;
        }
        public double P2Alkusaldo()                                             //Metodi joka palauttaa alkusaldon. Hyödynnetään Jakaja luokassa.
        {
            return p2alkusaldo;
        }
        public virtual double P2Saldo()                                         //Metodi joka palauttaa pelaajan saldon pelin edetessä. Hyödynnetään Jakaja luokassa.            
        {
            return p2saldo;
        }
    }
}