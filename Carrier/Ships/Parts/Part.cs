using Space_Game.Carrier.Ships.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Carrier.Ships
{
    public abstract class Part
    {
        public virtual long Mass { get; protected set; }

        public virtual long PowerDrain { get; protected set; }

        public virtual long Thrust { get; protected set; }
    }
}
