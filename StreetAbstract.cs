namespace Belopoly
{
    abstract class StreetAbstract : Cell
    {
        public Player Owner { get; set; }
        public int Cost { get; set; }
        public int Level { get; set; }
        public int Rent { get; set; }
        public string Street { get; set; } 

        public string StreetGroup { get; set; }


        public StreetAbstract(int cost, string name, string street) : base(name) 
        { 
            Cost = cost; 
            Rent = cost / 10; 
            Owner = null;
            Street = street;
            Level = 0;
        }

        public abstract int GetRent();
    }
}
