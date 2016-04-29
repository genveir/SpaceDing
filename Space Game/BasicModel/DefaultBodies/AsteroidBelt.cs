using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Space_Game.Geometry;

namespace Space_Game.BasicModel.DefaultBodies
{
    public class AsteroidBelt : UpdatableGroup<Asteroid>
    {
        public AsteroidBelt(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
