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
        public NuclearEngine(long mass, int massEfficiency) 
            : base("NuclearEngine", mass, 0, new PowerEfficiency(0), 10000, 1000, new MassEfficiency(800), new FuelEfficiency(1000))
        {

        }
    }
}
