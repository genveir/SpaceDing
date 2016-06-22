using Space_Game.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Carrier.Ships
{
    public class Ship : IShip
    {
        public Ship(String name, PoweredLocation location)
        {
            Name = name;
            Location = location;
            Mass = 100;
        }

        public string Name { get; set; }

        public ILocation Location { get; set; }

        public long MaximumSpeed { get; set; }

        public long Mass { get; set; }

        public Direction Heading { get; set; }

        public bool Observed { get; set; }

        public void Update()
        {

        }
    }
}
