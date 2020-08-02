using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Carrier.Ships.Parts.Implementations
{
    class Bridge : Part
    {
        public Bridge(long mass, long controlEfficiency)
            :base("Bridge", mass, mass / 10)
        {
            this.ControlEfficiency = controlEfficiency;
            this.ControlProvided = Mass * ControlEfficiency / 1000;
        }

        public long ControlEfficiency { get; set; }
    }
}
