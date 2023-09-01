using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belopoly
{
    class Cell
    {
        public string Name { get; protected set; }
        public Cell(string name)
        {
            Name = name;
        }
    }
}
