using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektRowery
{
    class Platnosc
    {
        double stawka = 1.2;
        int czas_w_min;
        double saldo = 0;
        public Platnosc (int stawka, int czas_w_min)
        {
            this.stawka = stawka;
            this.czas_w_min = czas_w_min;
        }

        public void obliczKwote()
        {
            this.saldo -= stawka * czas_w_min;
        }
    }
}
