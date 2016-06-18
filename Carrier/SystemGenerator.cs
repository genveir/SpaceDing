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
    class SystemGenerator
    {
        Random rnd = new Random();

        private const long TRILLION = 1000000000000;
        private const long BILLION = 1000000000;
        private const int MILLION = 1000000;
        private const int THOUSAND = 1000;

        public SolarSystem Generate()
        {
            var system = new SolarSystem();

            var star = GenerateStar(system);

            Distance currentOutermost = new Distance(200 * BILLION);
            var numDirectMembers = 0;
            do
            {
                if (rnd.NextDouble() < 0.8d)
                    currentOutermost = GeneratePlanet(star, numDirectMembers, currentOutermost);
                else
                    currentOutermost = GenerateAsteroidBelt(star, currentOutermost);

                numDirectMembers++;
            } while (star.Members.Count() < 50000 && numDirectMembers < 15);

            return system;
        }

        private Star GenerateStar(SolarSystem parent)
        {
            var name = "Star";

            long mass = rnd.Next(5000, 15000) * MILLION;

            return new Star(parent, name, FixedLocation.Zero, mass);
        }

        private Distance GeneratePlanet(Star star, int relativePosition, Distance currentOutermost)
        {
            long mass = 0;
            Direction startingDirection = Direction.Zero;
            Distance startingDistance = Distance.Zero;
            int numMoons = 0;

            if (relativePosition < 5)
            {
                mass = rnd.Next(5 * MILLION, 20 * MILLION);
                
                numMoons = rnd.Next(1, 2) + rnd.Next(-2, 1);
                if (numMoons < 0) numMoons = 0;
            }
            else
            {
                mass = rnd.Next(100 * MILLION, 200 * MILLION);

                numMoons = rnd.Next(1, 6) + rnd.Next(1, 6) + rnd.Next(1, 6);
            }

            startingDistance = currentOutermost + new Distance(rnd.Next(100, 200) * BILLION);

            startingDirection = Direction.FromCirclePortion(rnd.NextDouble());
            radian rotationPerTick = RotationAtDistance(startingDistance);
            var planet = star.AddPlanet("planet" + relativePosition, mass, startingDirection, startingDistance, rotationPerTick);

            var currentOutermostMoon = Distance.Zero;
            for (int n = 0; n < numMoons; n++)
            {
                currentOutermostMoon = GenerateMoon(planet, n, mass, currentOutermostMoon);
            }

            return startingDistance;
        }

        private Distance GenerateMoon(Planet planet, int relativePosition, long planetMass, Distance currentOutermost)
        {
            double promilleOfMass = (double)planetMass / 1000.0d;

            long mass = (long)promilleOfMass * rnd.Next(1, 15);

            var startingDistance = currentOutermost + new Distance(rnd.Next(10000, 50000) * MILLION);
            var startingDirection = Direction.FromCirclePortion(rnd.NextDouble());
            var rotationPerTick = RotationAtDistance(startingDistance);

            planet.AddMoon(planet.Name + ", moon" + relativePosition, mass, startingDirection, startingDistance, rotationPerTick);

            return startingDistance;
        }

        private Distance GenerateAsteroidBelt(Star star, Distance currentOutermost)
        {
            int numberOfAsteroids = rnd.Next(1000, 10000);

            var innerRange = currentOutermost + new Distance(rnd.Next(100, 200) * BILLION);
            var outerRange = innerRange + new Distance(rnd.Next(80, 150) * BILLION);

            var belt = star.AddAsteroidBelt("belt", innerRange, outerRange);

            var rotationPerTick = RotationAtDistance(innerRange);

            belt.GenerateAsteroids(numberOfAsteroids, "ast_", rotationPerTick);

            return outerRange;
        }

        private radian RotationAtDistance(Distance distance)
        {
            return radian.FromDegree(1.0d / 100000.0d);
        }
    }
}
