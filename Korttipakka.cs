using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ventti4
{
    public class Korttipakka : IKortti                  //Korttipakka luokka jota käytetään rajapinnan kautta.
    {
        private int kortti=0;
        public int Vastaus()                            //Metodi jolla arvotaan pelaajille kortteja.
        {
            Random gen = new Random();                  //Satunnaisluku generaattori pelaajien korttien arpomiseen.
            return kortti = gen.Next(1, 14);            //Palautetaan satunnailukugeneraattorin arpoma luku.
        }
    }
}