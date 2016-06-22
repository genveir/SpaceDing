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

        public static Universe Start()
        {

            var system = new SystemGenerator().Generate();

            var carrier = new Ship("Carrier", new PoweredLocation(new FixedLocation(100 * BILLION, 0), Direction.FromDegrees(0), 20000));

            system.AddMember(carrier);

            var universe = new Universe();
            universe.Systems = new SolarSystem[] { system };

            return universe;
        }
    }
}
