using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belopoly
{
    class SecondUpgrade : Decorator
    {
        public SecondUpgrade(StreetAbstract cell) : base(cell.Name + " lvl 2", cell) { Level = 2; }

        public override int GetRent()
        {
            return cell.GetRent() * 2;
        }
    }
}
