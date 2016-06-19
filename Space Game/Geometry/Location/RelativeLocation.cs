using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Geometry
{
    public class RelativeLocation : ILocation
    {
        ILocation _originLocation;
        vector _offset;

        public RelativeLocation(ILocation originLocation, vector offset)
        {
            _originLocation = originLocation;
            _offset = offset;
        }

        public long X {
            get { return _originLocation.X + _offset.XOffset; }
        }

        public long Y
        {
            get { return _originLocation.Y + _offset.YOffset; }
        }

        public void Fix()
        {
            // probably more lightweight in pretty much all instances to 
            // just do the math everytime this is called in a tick, so
            // no caching.
        }
    }
}
