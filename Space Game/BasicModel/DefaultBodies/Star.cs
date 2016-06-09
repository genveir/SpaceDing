using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Space_Game.Geometry;

namespace Space_Game.BasicModel.DefaultBodies
{
    public class Star : Body, IUpdatable
    {
        public Star(string name, ILocation location, long mass)
            :base(name, location, mass) { }

        public Planet AddPlanet(string name, long mass, Direction startingDirection, Distance startingDistance, radian rotationPerTick)
        {
            var planet = new Planet(name, new OrbitLocation(this, startingDirection, startingDistance, rotationPerTick), mass);

            members.Add(planet);

            return planet;
        }

        public AsteroidBelt AddAsteroidBelt(string name)
        {
            var belt = new AsteroidBelt(name);

            members.Add(belt);

            return belt;
        }

        public override string ToString()
        {
            return string.Format("Star: {0}", Name);
        }
    }
}
