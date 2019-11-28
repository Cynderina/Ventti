using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ventti4
{
    public class Pelaaja1 : IPelipoyta
    {
        public string vastaus;
        public double panos;

        public double Panos()                                       //Metodi pelaajan 1 panokselle.
        {
            PelaajaSanoo();
            return panos = double.Parse(Console.ReadLine());        //Luetaan pelaajan 1 vastaus muuttujaan.
        }

        public string Vastaus()                                     //Metodi pelaajan 1 korteille.
        {
            PelaajaSanoo();
            return vastaus = Console.ReadLine();                    //Luetaan pelaajan 1 vastaus muuttujaan.
        }

        private void PelaajaSanoo()                                 //Metodi pelaajan vastaukselle.
        {
            Console.Write("Vastaukseni on ");
        }
    }
}