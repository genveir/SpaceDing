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
        public NuclearEngine() { }
        public NuclearEngine(long mass, int massEfficiency) : this()
        {
            Name = "NuclearEngine";
            Mass = mass;
            MassEfficiency = massEfficiency;
        }

        public override void SetSecondaryProperties()
        {
            // TODO: deze shit speccen en duidelijk krijgen
            Thrust = Mass * (long)(BaseEfficency * MassEfficiency) / 1000;
        }

        public override string Name { get; protected set; }

        private int BaseEfficency = 10000;
        
        public int MassEfficiency { get; set; }

        public int FuelEfficiency { get; set; }
    }
}
