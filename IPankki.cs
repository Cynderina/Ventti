using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventti4
{
    public interface IPankki                    //Rajapinta Pankkiin.
    {
        void SaldoP1_1(double p1panos);         //Rajapinta Pankkiin.
        void SaldoP1_2(double p1panos);         //Rajapinta Pankkiin.
        void SaldoP1_3(double p1panos);         //Rajapinta Pankkiin.
        void SaldoP2_1(double p2panos);         //Rajapinta Pankkiin.
        void SaldoP2_2(double p2panos);         //Rajapinta Pankkiin.
        void SaldoP2_3(double p2panos);         //Rajapinta Pankkiin.
        double P1Alkusaldo();                   //Rajapinta Pankkiin.
        double P1Saldo();                       //Rajapinta Pankkiin.
        double P2Alkusaldo();                   //Rajapinta Pankkiin.
        double P2Saldo();                       //Rajapinta Pankkiin.
    }
}
