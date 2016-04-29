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
        private static long index;

        private AsteroidBelt parent;

        public Asteroid(ILocation location, long mass, AsteroidBelt parent) :
            base(string.Format("[{0}_ast_{1}]", parent.Name, index++), location, mass)
        {
            this.parent = parent;
            parent.AddMember(this);
        }

        public override void Update()
        {
            // asteroids don't do anything when updating
        }
    }
}
