using Space_Game.BasicModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Geometry
{
    public class Direction
    {
        private radian _inRadians;

        public radian InRadians
        {
            get { return _inRadians; }
            set { _inRadians = value; }
        }

        public double InDegrees
        {
            get { return _inRadians.toDouble() / Math.PI * 180.0d; }
            set { _inRadians = value / 180.0d * Math.PI; }
        }

        public static implicit operator radian(Direction dir)
        {
            return dir.InRadians;
        }

        public static implicit operator Direction(radian value)
        {
            return new RadianDirection(value);
        }

        public static Direction Calculate(ILocation from, ILocation to)
        {
            double deltaX = to.X - from.X;
            double deltaY = to.Y - from.Y;

            return new RadianDirection(Math.Atan2(deltaX, deltaY));
        }

        public static Direction CalculateBearing(IHasHeading fromHeading, ILocation to)
        {
            var heading = Calculate(fromHeading.Location, to);

            return heading - fromHeading.Heading;
        }

        public static Direction operator +(Direction directionOne, Direction directionTwo)
        {
            return new RadianDirection(directionOne.InRadians + directionTwo.InRadians);
        }

        public static Direction operator -(Direction directionOne, Direction directionTwo)
        {
            return new RadianDirection(directionOne.InRadians - directionTwo.InRadians);
        }

        public override string ToString()
        {
            return string.Format("Direction: {0}", InRadians);
        }
    }
}
