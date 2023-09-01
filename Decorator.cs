using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belopoly
{
    abstract class Decorator : StreetAbstract
    {
        protected StreetAbstract cell;
        public Decorator(string upgrade, StreetAbstract cell) : base(cell.Cost, upgrade, cell.Street)
        {
            Owner = cell.Owner;
            this.cell = cell;
        }
    }
}
