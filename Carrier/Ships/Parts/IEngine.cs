using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Carrier.Ships
{
    public interface IEngine : IPart
    {
        /// <summary>
        /// One unit of Thrust pushes one unit of mass at 1m/s
        /// </summary>
        long Thrust { get; }
    }
}
