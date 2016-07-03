using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Carrier.Ships
{
    class DummyPart : IPart
    {
        private long _mass;
        private long _powerDrain;

        public DummyPart(long mass, long powerDrain)
        {
            _mass = mass;
            _powerDrain = powerDrain;
        }

        public long Mass { get { return _mass; } }

        public long PowerDrain { get { return _powerDrain; } }
    }
}
