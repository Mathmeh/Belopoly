using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belopoly
{
    class Hotel : Decorator
    {
        public Hotel(StreetAbstract cell) : base(cell.Name + " гатэль", cell) { Level = 4; }

        public override int GetRent()
        {
            return cell.GetRent() * 2;
        }
    }
}
