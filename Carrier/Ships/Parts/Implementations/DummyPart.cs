using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Carrier.Ships
{
    class DummyPart : Part
    {
        public DummyPart() { }
        public DummyPart(long mass, long powerDrain) : this()
        {
            Name = "DummyPart";
            Mass = mass;
            PowerDrain = powerDrain;
        }

        public override string Name { get; protected set; }

        public override void SetSecondaryProperties()
        {
            
        }
    }
}
