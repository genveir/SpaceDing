using Space_Game.BasicModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Simulation
{
    class Universe
    {
        public IEnumerable<SolarSystem> Systems { get; set; }
    }
}
