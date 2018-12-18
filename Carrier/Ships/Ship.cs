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
        public Ship(String name, ILocation location, IEnumerable<Part> parts)
        {
            Name = name;
            Location = location;
            Parts = parts.ToList();
        }

        private List<Part> _parts;
        public List<Part> Parts {
            get { return _parts; }
            set
            {
                _parts = value;
                CalculatePropertiesFromParts();
            }
        }

        public string Name { get; set; }

        public ILocation Location { get; set; }

        public bool HasControl { get; set; }

        public long Acceleration { get; set; }

        public long Mass { get; set; }

        public Direction Heading { get; set; }

        public bool Observed { get; set; }

        public void Update()
        {

        }

        private void CalculatePropertiesFromParts()
        {
            if (_parts.Count() == 0) throw new ShipWithoutPartsException();

            Mass = _parts.Sum(part => part.Mass);

            var totalThrust = _parts.Sum(part => part.Thrust);

            Acceleration = totalThrust / Mass;
        }
    }
}
