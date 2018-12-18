using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Carrier.Ships.Parts.Implementations
{
    class FuelTank : Part
    {
        public override string Name { get; protected set; }

        public override void SetSecondaryProperties()
        {
            FuelAvailable = Mass * 10000;
        }
    }
}
