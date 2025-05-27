namespace ProjektRowery
{
    internal class Program
    {
        enum Typ { standardowy, eleketryczny }
        enum StatusRoweru { dostepny, wypozyczony, serwis}

        class Rower
        {
            private int id;
            private Typ typ;
            private StatusRoweru status;
            public Rower (int id, Typ typ)
            {
                this.id = id;
                this.typ = typ;
                this.status=StatusRoweru.dostepny;

            }

            public void wypozycz()
            {
                if (this.status==StatusRoweru.dostepny)
                {
                    Console.WriteLine("Pomyślnie wypożyczono rower!");
                    this.status = StatusRoweru.wypozyczony;
                }
            }

            public string sprawdzStan()
            {
                return $"{this.status}";

            }
        }

        static void Main(string[] args)
        {
            Rower rower = new Rower(1, Typ.standardowy);
            rower.wypozycz();
            Console.WriteLine(rower.sprawdzStan());

        }
    }
}
