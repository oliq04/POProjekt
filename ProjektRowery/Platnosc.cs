using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektRowery
{
    class Platnosc
    {
        private int czas_w_min;
        private Typ typRoweru;

        public Platnosc(Typ typRoweru, int czas_w_min)
        {
            this.typRoweru = typRoweru;
            this.czas_w_min = czas_w_min;
        }


        public double ObliczKwote()
        {
            if (typRoweru == Typ.standardowy)
            {
                return 0.5 * czas_w_min;
            }
            else if (typRoweru == Typ.elektryczny)
            {
                return 0.8 * czas_w_min;
            }
            else
            {
                throw new Exception("Nieznany typ roweru.");
            }
        }
    }
}
