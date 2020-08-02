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
            _Construct(name, location, parts);
        }

        public Ship(string name, ILocation location, params Part[] parts) 
        {
            _Construct(name, location, parts);
        }

        private void _Construct(string name, ILocation location, IEnumerable<Part> parts)
        {
            Name = name;
            Location = location;
            Parts = parts?.ToList() ?? new List<Part>();
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

        public long Fuel { get; set; }
        public long Acceleration { get; set; }

        public long Mass { get; set; }

        public Direction Heading { get; set; }

        public bool Observed { get; set; }

        public void Update()
        {

        }

        private void CalculatePropertiesFromParts()
        {
            if (_parts == null || _parts.Count() == 0) throw new ShipWithoutPartsException();

            Mass = _parts.Sum(p => p.Mass);

            Fuel = _parts.Sum(p => p.FuelAvailable);
            HasControl = _parts.Sum(p => p.ControlProvided) > _parts.Sum(p => p.ControlRequired);

            if (Fuel == 0) Acceleration = 0;
            else if (!HasControl) Acceleration = 0;
            else Acceleration = _parts.Sum(p => p.Thrust) / Mass;
        }
    }
}
