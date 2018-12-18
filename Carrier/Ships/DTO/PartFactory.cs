using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Carrier.Ships.DTO
{
    class PartFactory
    {
        public List<Part> CreateParts(List<PartDTO> parts)
        {
            var availableParts = this.GetType().Assembly.GetTypes()
                .Where(t => typeof(Part).IsAssignableFrom(t));

            return new List<Part>();
        }
    }
}
