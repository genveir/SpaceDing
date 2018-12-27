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

            var carrier = SetupCarrier();

            system.AddMember(carrier);

            var universe = new Universe();
            universe.Systems = new SolarSystem[] { system };

            return universe;
        }

        public static Universe SetupJustCarrier()
        {
            var universe = new Universe();
            var system = new SolarSystem();
            var star = new Star(system, "Star", new FixedLocation(0, 0), 2000 * MILLION);
            var ast = new Asteroid("Asteroid", new OrbitLocation(star, new FixedLocation(500 * BILLION, 0), new radian(0.0000001)), 10000, star);

            universe.Systems = new SolarSystem[] { system };
            system.AddMember(ast);

            var carrier = SetupCarrier();
            carrier.Location = new OrbitLocation(ast, Direction.FromDegrees(0d), new Distance(10 * BILLION), new radian(0.00001));
            system.AddMember(carrier);

            return universe;
        }

        private static Ship SetupCarrier()
        {
            var carrierBase = new DummyPart(80000, 0);
            var carrierEngine1 = new NuclearEngine(10000, 1000);
            var carrierEngine2 = new NuclearEngine(10000, 1000);
            var carrierParts = new List<Part>() { carrierBase, carrierEngine1, carrierEngine2 };

            var carrier = new Ship("Carrier", new FixedLocation(100 * BILLION, 0), carrierParts);

            return carrier;
        }
    }
}
