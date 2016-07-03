using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Carrier.Ships
{
    public interface IPart
    {
        long Mass { get; }

        long PowerDrain { get; }
    }
}
