using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Carrier.Ships
{
    class NuclearEngine : IEngine
    {
        long _thrust;
        long _mass;

        /// <summary>
        /// A nuclear engine has a base efficiency of 10000, so it can push its own weight at 10000 km/s, this is multiplied by mass efficiency.
        /// </summary>
        public NuclearEngine(long mass, double massEfficiency)
        {
            _mass = mass;
            _thrust = mass * (long)(10000 * massEfficiency);
        }

        public long Mass { get { return _mass; } }

        public long Thrust { get { return _thrust; } }

        public long PowerDrain { get { return 0; } }
    }
}
