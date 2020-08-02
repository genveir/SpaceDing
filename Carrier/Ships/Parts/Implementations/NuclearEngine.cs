using Space_Game.Carrier.Efficiency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Carrier.Ships.Parts.Implementations
{
    class NuclearEngine : Engine
    {
        /// <summary>
        /// A nuclear engine has a base efficiency of 10000, so it can push its own weight at 10000 km/s, this is multiplied by mass efficiency.
        /// </summary>
        public NuclearEngine(long mass, int massEfficiency) 
            : base("NuclearEngine", mass, 0, new PowerEfficiency(0), 10000, new MassEfficiency(1000), new FuelEfficiency(1000))
        {

        }
    }
}
