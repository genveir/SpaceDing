using Space_Game.BasicModel;
using Space_Game.BasicModel.DefaultBodies;
using Space_Game.Carrier.Ships;
using Space_Game.Geometry;
using Space_Game.Simulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Carrier
{
    public class StartUp
    {
        private const long TRILLION = 1000000000000;
        private const long BILLION = 1000000000;
        private const long MILLION = 1000000;
        private const long THOUSAND = 1000;
        private const long test = 5;
        public static Universe SetupUniverse()
        {
            var system = new SystemGenerator().Generate();

            var carrierBase = new DummyPart(80000, 0);
            var carrierEngine1 = new NuclearEngine(10000, 1.0d);
            var carrierEngine2 = new NuclearEngine(10000, 1.0d);
            var carrierParts = new List<Part>() { carrierBase, carrierEngine1, carrierEngine2 };

            var carrier = new Ship("Carrier", new FixedLocation(100 * BILLION, 0), carrierParts);

            system.AddMember(carrier);

            var universe = new Universe();
            universe.Systems = new SolarSystem[] { system };

            return universe;
        }
    }
}
