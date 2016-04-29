using Space_Game.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.BasicModel
{
    public interface IBody
    {
        string Name { get; set; }
        long Mass { get; set; }
        ILocation Location { get; set; }
    }
}
