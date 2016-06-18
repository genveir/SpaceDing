using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Space_Game.Geometry;
using Space_Game.Simulation;
using System.Collections.Concurrent;

namespace Space_Game.BasicModel.DefaultBodies
{
    public class Star : Body
    {
        public Star(SolarSystem parent, string name, ILocation location, long mass)
            :base(parent, name, location, mass)
        {
            _members = new ConcurrentBag<IBody>();

            parent.AddMember(this);
        }

        public Planet AddPlanet(string name, long mass, Direction startingDirection, Distance startingDistance, radian rotationPerTick)
        {
            var planet = new Planet(this, name, new OrbitLocation(this, startingDirection, startingDistance, rotationPerTick), mass);

            return AddPlanet(planet);
        }

        public Planet AddPlanet(Planet planet)
        {
            AddMember(planet);

            return planet;
        }

        public AsteroidBelt AddAsteroidBelt(string name, Distance innerRange, Distance outerRange)
        {
            var belt = new AsteroidBelt(this, Location, name, innerRange, outerRange);

            return AddAsteroidBelt(belt);
        }

        public AsteroidBelt AddAsteroidBelt(AsteroidBelt belt)
        {
            return belt;
        }

        public override string ToString()
        {
            return string.Format("Star: {0}", Name);
        }
    }
}
