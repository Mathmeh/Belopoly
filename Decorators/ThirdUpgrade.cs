using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belopoly
{
    class ThirdUpgrade : Decorator
    {
        public ThirdUpgrade(StreetAbstract cell) : base(cell.Name + " lvl 3", cell) { Level = 3; }

        public override int GetRent()
        {
            return cell.GetRent() * 2;
        }
    }
}
