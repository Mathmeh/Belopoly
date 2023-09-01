using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belopoly
{
    class FirstUpgrade : Decorator
    {
        public FirstUpgrade(StreetAbstract cell) : base(cell.Name + " lvl 1", cell) {Level = 1; }
        
        public override int GetRent()
        {
            return cell.GetRent() * 2;
        }
    }
}
