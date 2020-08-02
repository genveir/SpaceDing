using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Carrier.Ships.Parts.Implementations
{
    class DummyPart : Part
    {
        public DummyPart(long mass, long powerDrain) : base("DummyPart", mass, powerDrain)
        {
        }
    }
}
