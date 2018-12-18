using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Carrier.Ships
{
    class NuclearEngine : Part
    {
        /// <summary>
        /// A nuclear engine has a base efficiency of 10000, so it can push its own weight at 10000 km/s, this is multiplied by mass efficiency.
        /// </summary>
        public NuclearEngine(long mass, double massEfficiency)
        {
            Mass = mass;
            Thrust = mass * (long)(10000 * massEfficiency);
        }
    }
}
