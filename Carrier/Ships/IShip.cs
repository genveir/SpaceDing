using Space_Game.BasicModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Carrier.Ships
{
    public interface IShip : IBody, IHasHeading
    {
        List<IPart> Parts { get; set; }

        long MaximumSpeed { get; set; }
    }
}
