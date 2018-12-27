using Space_Game.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.View
{
    public class LocationTranslator
    {
        private vector _centerAsVector;
        private int _centerX;
        private int _centerY;
        private double _distancePerPixel;

        public LocationTranslator(ILocation center, Rectangle ClientRectangle, double distancePerPixel)
        {
            _centerAsVector = new vector(center);
            _centerX = ClientRectangle.Width / 2;
            _centerY = ClientRectangle.Height / 2;
            _distancePerPixel = Math.Max(1.0d, distancePerPixel);
        }

        public FixedLocation ToFixedLocation(Point point)
        {
            var pixelVector = new vector(point.X - _centerX, point.Y - _centerY);
            var relativePosition = pixelVector * _distancePerPixel;
            var locationAsVector = relativePosition + _centerAsVector;

            return new FixedLocation(locationAsVector.XOffset, locationAsVector.YOffset);
        }

        public Point ToPoint(ILocation location)
        {
            var locationAsVector = new vector(location);
            var relativeposition = locationAsVector - _centerAsVector;
            var pixelVector = relativeposition / _distancePerPixel;

            return new Point((int)pixelVector.XOffset + _centerX, (int)pixelVector.YOffset + _centerY);
        }
    }
}
