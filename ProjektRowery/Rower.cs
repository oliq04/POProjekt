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
        private int id;
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
        public int GetId() => id;
        public Typ GetTyp() => typ;
        public string GetMarka() => marka;
        public StatusRoweru GetStatus() => status;
        internal void ZmienStatus(StatusRoweru nowyStatus)
        {
            status = nowyStatus;
        }


    }
}
