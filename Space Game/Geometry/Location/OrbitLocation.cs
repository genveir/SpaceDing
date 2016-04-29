using Space_Game.BasicModel;
using Space_Game.Simulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Geometry
{
    public class OrbitLocation : ILocation
    {
        // values to determine location
        private ILocation center;
        private radian rotationPerTick;
        private radian startingAngle;
        private Distance distance;

        // cache
        private long currentTick;
        private FixedLocation locAtCurrentTick;

        public OrbitLocation(ILocation center, ILocation startingPoint, radian rotationPerTick)
        {
            this.center = center;
            this.rotationPerTick = rotationPerTick;

            startingAngle = Direction.Calculate(center, startingPoint);
            distance = Distance.Calculate(center, startingPoint);
        }
        public OrbitLocation(IBody anchor, ILocation startingPoint, radian rotationPerTick) :
            this(anchor.Location, startingPoint, rotationPerTick) { }

        public OrbitLocation(ILocation center, Direction startingDirection, Distance distance, radian rotationPerTick)
        {
            this.center = center;
            this.rotationPerTick = rotationPerTick;

            this.startingAngle = startingDirection;
            this.distance = distance;
        }

        public OrbitLocation(IBody anchor, Direction startingDirection, Distance distance, radian rotationPerTick) :
            this(anchor.Location, startingDirection, distance, rotationPerTick) { }

        public long X
        {
            get
            {
                var tick = Time.Tick;
                if (tick != currentTick || locAtCurrentTick == null)
                {
                    CalculateCurrentPosition(tick);
                }
                return locAtCurrentTick.X;
            }
        }

        public long Y
        {
            get
            {
                var tick = Time.Tick;
                if (tick != currentTick || locAtCurrentTick == null)
                {
                    CalculateCurrentPosition(tick);
                }
                return locAtCurrentTick.Y;
            }
        }

        private void CalculateCurrentPosition(long tick)
        {
            currentTick = tick;

            var currentAngle = (tick * rotationPerTick) + startingAngle;

            locAtCurrentTick = new FixedLocation(center, currentAngle, distance);
        }
    }
}
