using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Geometry
{
    public class Distance
    {
        public double Value { get; set; }

        public Distance(double value)
        {
            Value = value;
        }

        public static implicit operator double(Distance dist)
        {
            return dist.Value;
        }

        public static Distance Calculate(ILocation locationOne, ILocation locationTwo)
        {
            long XLeg = locationOne.X - locationTwo.X;
            long XLegSquare = XLeg * XLeg;

            long YLeg = locationOne.Y - locationTwo.Y;
            long YLegSquare = YLeg * YLeg;

            return new Distance(Math.Sqrt(XLegSquare + YLegSquare));
        }

        public override string ToString()
        {
            return string.Format("Distance: {0}", Value);
        }
    }
}
