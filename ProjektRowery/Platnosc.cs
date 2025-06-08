using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektRowery
{
    class Platnosc
    {

        public Platnosc()
        {
        }


        public double ObliczKwote(Rower rower, int czas_w_min)
        {
            Typ typRoweru = rower.GetTyp();

            if (typRoweru == Typ.standardowy)
            {
                return 0.5 * czas_w_min + 10;
            }
            else if (typRoweru == Typ.elektryczny)
            {
                return 1 * czas_w_min + 20;
            }
            else
            {
                throw new Exception("Nieznany typ roweru.");
            }
        }
    }
}
