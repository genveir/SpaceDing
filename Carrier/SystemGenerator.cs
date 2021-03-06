﻿using Space_Game.BasicModel;
using Space_Game.BasicModel.DefaultBodies;
using Space_Game.Geometry;
using Space_Game.Simulation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private const long MILLION = 1000000;
        private const long THOUSAND = 1000;

        bool turnsClockwise;

        public SolarSystem Generate()
        {
            var system = new SolarSystem();

            var star = GenerateStar(system);

            turnsClockwise = rnd.NextDouble() < 0.5d;

            var totalMembers = rnd.Next(1, 10) + rnd.Next(1, 10) + rnd.Next(1, 10);

            Distance currentOutermost = new Distance(200 * BILLION);
            var numDirectMembers = 0;
            do
            {
                if (rnd.NextDouble() < 0.80d)
                    currentOutermost = GeneratePlanet(star, numDirectMembers, currentOutermost);
                else
                    currentOutermost = GenerateAsteroidBelt(star, currentOutermost);

                numDirectMembers++;
            } while (numDirectMembers < totalMembers);

            return system;
        }

        private Star GenerateStar(SolarSystem parent)
        {
            var name = "Star";

            long mass = rnd.Next(2000, 8000) * MILLION;

            Debug.Print(mass.ToString());

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
                mass = rnd.Next(5000, 20000) * THOUSAND;
                
                numMoons = rnd.Next(1, 2) + rnd.Next(-2, 1);
                if (numMoons < 0) numMoons = 0;
            }
            else
            {
                mass = rnd.Next(100, 200) * MILLION;

                numMoons = rnd.Next(1, 6) + rnd.Next(1, 6) + rnd.Next(1, 6);
            }

            startingDistance = currentOutermost + new Distance(rnd.Next(300, 600) * BILLION);

            startingDirection = Direction.FromCirclePortion(rnd.NextDouble());
            radian rotationPerTick = RotationAtDistance(startingDistance, star.Mass);
            var planet = star.AddPlanet("planet" + relativePosition, mass, startingDirection, startingDistance, rotationPerTick);

            var currentOutermostMoon = new Distance(10000 * MILLION);
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

            var startingDistance = currentOutermost + new Distance(rnd.Next(10, 20) * BILLION);
            var startingDirection = Direction.FromCirclePortion(rnd.NextDouble());
            var rotationPerTick = RotationAtDistance(startingDistance, planet.Mass);

            planet.AddMoon(planet.Name + ", moon" + relativePosition, mass, startingDirection, startingDistance, rotationPerTick);

            return startingDistance;
        }

        private Distance GenerateAsteroidBelt(Star star, Distance currentOutermost)
        {
            int numberOfAsteroids = rnd.Next(500, 3000);

            var innerRange = currentOutermost + new Distance(rnd.Next(400, 500) * BILLION);
            var outerRange = innerRange + new Distance(rnd.Next(500, 1000) * BILLION);

            var belt = star.AddAsteroidBelt("belt", innerRange, outerRange);

            var rotationPerTick = RotationAtDistance(innerRange, star.Mass);

            belt.GenerateAsteroids(numberOfAsteroids, "ast_", rotationPerTick);

            return outerRange;
        }

        private radian RotationAtDistance(Distance distance, long massAtCenter)
        {
            // at 147 billion, take 365 days
            var year = 31557600; // one year in ticks
            var earthOrbitDist = new Distance(147 * BILLION);

            radian earthOrbitSpeed = radian.FromDegree(360.0d / year);

            var distInEarthOrbits = distance / earthOrbitDist;

            var baseStarMass = (5000.0d * MILLION);
            var ratio = (double)(massAtCenter / baseStarMass);
            var massModifier = Math.Sqrt(ratio);

            double dir = (turnsClockwise) ? 1.0d : -1.0d;

            return new radian(massModifier * dir * (earthOrbitSpeed.toDouble() / (distInEarthOrbits * distInEarthOrbits)));
        }
    }
}
