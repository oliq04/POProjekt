using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace ProjektRowery
{
    public enum Typ { standardowy, elektryczny }
    public enum StatusRoweru { dostepny, wypozyczony, serwisowany }

    public class Rower
    {
        public int id;
        private Typ typ;
        private StatusRoweru status;
        private string marka;
       
        public Rower(int id, Typ typ, string marka)
        {
            this.id = id;
            this.typ = typ;
            this.status = StatusRoweru.dostepny;
            this.marka = marka;
        }

        public string Marka() => marka;
        public StatusRoweru Status() => status;

        public void UstawStatus(StatusRoweru nowyStatus) => status = nowyStatus;

        public Typ type() => typ;

    }
}
