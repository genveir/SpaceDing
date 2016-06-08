using Space_Game.BasicModel;
using Space_Game.BasicModel.DefaultBodies;
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
        private const long BILLION = 1000000000;
        private const long MILLION = 1000000;
        private const long THOUSAND = 1000;

        public static void Start() {
            var Sun = new Star(
                name: "Sun",
                location: FixedLocation.Zero,
                mass: 10 * BILLION);
            var Hope = Sun.AddPlanet(
                name: "Hope",
                mass: 12 * MILLION,
                startingDirection: new DegreeDirection(120),
                startingDistance: new Distance(147 * MILLION),
                rotationPerTick: radian.FromDegree(0.05));
            var Scorch = Sun.AddPlanet(
                name: "Scorch",
                mass: 7 * MILLION,
                startingDirection: new DegreeDirection(270),
                startingDistance: new Distance(80 * MILLION),
                rotationPerTick: radian.FromDegree(0.08));
            var Flame = Scorch.AddMoon(
                name: "Flame",
                mass: 400 * THOUSAND,
                startingDirection: new DegreeDirection(20),
                startingDistance: new Distance(600 * THOUSAND),
                rotationPerTick: radian.FromDegree(1));

            var system = new SolarSystem();
            system.AddMember(Sun);

            var universe = new Universe();
            universe.Systems = new SolarSystem[] { system };
        }
    }
}
