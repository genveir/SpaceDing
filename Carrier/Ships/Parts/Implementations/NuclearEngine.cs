using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Carrier.Ships
{
    class NuclearEngine : Part
    {
        private const int BaseEfficency = 10000;

        public int MassEfficiency { get; set; }

        /// <summary>
        /// A nuclear engine has a base efficiency of 10000, so it can push its own weight at 10000 km/s, this is multiplied by mass efficiency.
        /// </summary>
        public NuclearEngine(long mass, int massEfficiency) 
            : base("NuclearEngine", mass, 0)
        {
            MassEfficiency = massEfficiency;
            // TODO: deze shit speccen en duidelijk krijgen
            Thrust = Mass * (long)(BaseEfficency * MassEfficiency) / 1000;
        }
    }
}
