using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belopoly
{
    class Street : StreetAbstract
    {
        //private string Name, Room; //room на будущее
        //private int Cost, Rent; //cost - покупка, rent - рента
        //private Cat Owner;
        //private int Rent;
        //public int Level;

        public Street(int cost, string name, string group) : base(cost, name, group) 
        {
            Cost = cost; 
            Rent = cost / 10;
            Owner = null;
            Name = name; 
            StreetGroup = group; 
            Level = 0;
        }

        public override int GetRent()
        {
            return Rent;
        }
        public override string ToString()
        {
            return StreetGroup+ " " + Name;
        }


    }
}
