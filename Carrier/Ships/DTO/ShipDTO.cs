using Space_Game.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Carrier.Ships.DTO
{
    class ShipDTO
    {
        private ShipDTO() { Parts = new List<PartDTO>(); }

        public ShipDTO(string name, ILocation location) : this()
        {
            this.Name = name;
            this.Location = location;
        }
        public ShipDTO(string name, (long x, long y) location) : this()
        {
            this.Name = name;
            this.Location = new FixedLocation(location.x, location.y);
        }

        public string Name { get; set; }

        public ILocation Location { get; set; }

        public List<PartDTO> Parts { get; set; }

        public void AddPart(string name, int mass, params (string key, string value)[] parameters)
        {
            var paramDict = new Dictionary<string, string>();
            foreach (var p in parameters) paramDict.Add(p.key, p.value);

            Parts.Add(new PartDTO()
            {
                Name = name,
                Mass = mass,
                Properties = paramDict
            });
        }

        public Ship ToShip()
        {
            var parts = new PartFactory()
                .CreateParts(Parts);

            return new Ship(Name, Location, parts);
        }
    }
}
