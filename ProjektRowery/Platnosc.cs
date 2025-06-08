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


        public double ObliczKwote(string bike, int czas_w_min)
        {
            if (bike=="standardowy")
            {
                return 0.5 * czas_w_min;
            }
            else if (bike == "elektryczny")
            {
                return 1 * czas_w_min;
            }
            else
            {
                throw new Exception("Nieznany typ roweru.");
            }
        }
    }
}
