using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Carrier.Ships.Parts.Implementations
{
    class Bridge : Part
    {
        public Bridge() { }

        public long ControlEfficiency { get; set; }

        public override string Name { get; protected set; }

        public override void SetSecondaryProperties()
        {
            ControlProvided = Mass * ControlEfficiency / 1000;
        }
    }
}
