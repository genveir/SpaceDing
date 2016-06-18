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
        internal Asteroid(string name, ILocation location, long mass, AsteroidBelt parent) :
            base(parent, name, location, mass)
        {
            
        }
    }
}
