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
        public Asteroid(string name, ILocation location, long mass, IUpdatableGroup<IBody> parent) :
            base(parent, name, location, mass)
        {
            
        }
    }
}
