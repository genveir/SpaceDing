using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Space_Game.Geometry;

namespace Space_Game.BasicModel.DefaultBodies
{
    public class Planet : Body, IUpdatable
    {
        public Planet(string name, ILocation location, long mass)
            :base(name, location, mass) { }

        public Planet AddMoon(string name, long mass, Direction startingDirection, Distance startingDistance, radian rotationPerTick)
        {
            var moon = new Planet(name, new OrbitLocation(this, startingDirection, startingDistance, rotationPerTick), mass);

            members.Add(moon);

            return moon;
        }

        public override string ToString()
        {
            return string.Format("Planet: {0}", Name);
        }
    }
}
