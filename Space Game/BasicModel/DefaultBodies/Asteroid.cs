using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Space_Game.Geometry;

namespace Space_Game.BasicModel.DefaultBodies
{
    public class Asteroid : Body
    {
        private AsteroidBelt parent;

        public Asteroid(string name, ILocation location, long mass, AsteroidBelt parent) :
            base(name, location, mass)
        {
            this.parent = parent;
        }

        public override void Update()
        {
            // asteroids don't do anything when updating
        }
    }
}
