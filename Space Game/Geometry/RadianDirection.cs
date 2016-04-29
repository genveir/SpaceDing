using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Geometry
{
    public class RadianDirection : Direction
    {
        public RadianDirection(radian directionInRadians)
        {
            InRadians = directionInRadians;
        }
    }
}
