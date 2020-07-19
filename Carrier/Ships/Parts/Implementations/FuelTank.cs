using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Carrier.Ships.Parts.Implementations
{
    class FuelTank : Part
    {
        public FuelTank(long mass)
            :base("FuelTank", mass, 0)
        {
            this.FuelAvailable = Mass * 10000;
        }
    }
}
