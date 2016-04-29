using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Geometry
{
    public struct vector
    {
        public long XOffset { get; set; }
        public long YOffset { get; set; }

        public Direction Direction { get; }
        public Distance Distance { get; }

        public vector(long XOffset, long YOffset)
        {
            this.XOffset = XOffset;
            this.YOffset = YOffset;

            var vectorLoc = new FixedLocation(XOffset, YOffset);

            this.Direction = Direction.Calculate(FixedLocation.Zero, vectorLoc);
            this.Distance = Distance.Calculate(FixedLocation.Zero, vectorLoc);
        }

        public vector(Direction direction, Distance distance)
        {
            this.Direction = direction;
            this.Distance = distance;

            var vectorLoc = new FixedLocation(FixedLocation.Zero, Direction, Distance);

            this.XOffset = vectorLoc.X;
            this.YOffset = vectorLoc.Y;
        }

        public static vector operator +(vector first, vector second)
        {
            return new vector(first.XOffset + second.XOffset, first.YOffset + second.YOffset);
        }

        public static vector operator -(vector first, vector second)
        {
            return new vector(first.XOffset - second.XOffset, first.YOffset - second.YOffset);
        }
    }
}