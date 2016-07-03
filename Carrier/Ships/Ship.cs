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
        public Ship(String name, FixedLocation location, IEnumerable<IPart> parts)
        {
            Name = name;
            Location = location;
            Parts = parts.ToList();
        }

        private List<IPart> _parts;
        public List<IPart> Parts {
            get { return _parts; }
            set
            {
                _parts = value;
                CalculatePropertiesFromParts();
            }
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

        private void CalculatePropertiesFromParts()
        {
            Mass = _parts.Select(part => part.Mass).Sum();

            var totalThrust =
                _parts.Where(part => part is IEngine)
                    .Select(engine => ((IEngine)engine).Thrust)
                    .Sum();

            MaximumSpeed = totalThrust / Mass;
        }
    }
}
