using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Space_Game.Geometry;
using System.Collections.Concurrent;

namespace Space_Game.BasicModel.DefaultBodies
{
    public class Planet : Body
    {
        public Planet(IUpdatableGroup<IBody> parent, string name, ILocation location, long mass)
            :base(parent, name, location, mass)
        {
            _members = new ConcurrentBag<IBody>();
        }

        public Planet AddMoon(string name, long mass, Direction startingDirection, Distance startingDistance, radian rotationPerTick)
        {
            var moon = new Planet(this, name, new OrbitLocation(this, startingDirection, startingDistance, rotationPerTick), mass);

            AddMember(moon);

            return moon;
        }

        public override string ToString()
        {
            return string.Format("Planet: {0}", Name);
        }
    }
}
