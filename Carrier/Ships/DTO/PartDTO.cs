using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Carrier.Ships.DTO
{
    class PartDTO
    {
        public PartDTO()
        {
            Parameters = new Dictionary<string, string>();
        }

        public string Name { get; set; }

        public int Mass { get; set; }

        public Dictionary<string, string> Parameters { get; set; }
    }
}
