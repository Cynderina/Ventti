using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ventti4
{
    class Tiedostot
    {
        public void Filet()                                                                 //Jos ohjelman edellisestä ajosta on jäänyt tiedostoja tuhotaan ne.
        {
            if (File.Exists(@"p1voitot.txt"))                                               //Tarkistetaan löytyykö tiedosto.
            {
                File.Delete(@"p1voitot.txt");                                               //Jos löytyy tuhotaan se.
            }
            if (File.Exists(@"p2voitot.txt"))                                               //Tarkistetaan löytyykö tiedosto.
            {
                File.Delete(@"p2voitot.txt");                                               //Jos löytyy tuhotaan se.
            }
            if (File.Exists(@"kierrokset.txt"))                                             //Tarkistetaan löytyykö tiedosto.
            {
                File.Delete(@"kierrokset.txt");                                             //Jos löytyy tuhotaan se.
            }
        }
    }
}
