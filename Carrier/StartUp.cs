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
        private const long TRILLION = 1000000000000;
        private const long BILLION = 1000000000;
        private const long MILLION = 1000000;
        private const long THOUSAND = 1000;

        public static Universe Start() {
            var Sun = new Star(
                name: "Sun",
                location: FixedLocation.Zero,
                mass: 10 * BILLION);
            var Hope = Sun.AddPlanet(
                name: "Hope",
                mass: 12 * MILLION,
                startingDirection: Direction.FromDegrees(220),
                startingDistance: new Distance(147 * BILLION),
                rotationPerTick: radian.FromDegree(360.0d / 31557600));
            var Scorch = Sun.AddPlanet(
                name: "Scorch",
                mass: 7 * MILLION,
                startingDirection: Direction.FromDegrees(270),
                startingDistance: new Distance(80 * BILLION),
                rotationPerTick: radian.FromDegree(360.0d / 15778800));
            var Flame = Scorch.AddMoon(
                name: "Flame",
                mass: 400 * THOUSAND,
                startingDirection: Direction.FromDegrees(20),
                startingDistance: new Distance(6000 * MILLION),
                rotationPerTick: radian.FromDegree(360.0d / 1577880));

            var Belt = Sun.AddAsteroidBelt("Baumfalk Belt",
                innerRange: new Distance (220 * BILLION),
                outerRange: new Distance (260 * BILLION));

            Belt.GenerateAsteroids(
                10000,
                namePrefix: "BB",
                orbitSpeed: radian.FromDegree(360.0d / 50000000));

            var system = new SolarSystem();
            system.AddMember(Sun);

            var universe = new Universe();
            universe.Systems = new SolarSystem[] { system };

            return universe;
        }
    }
}
