using Space_Game.Geometry;
using Space_Game.Simulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Carrier.Ships
{
    public class PoweredLocation : ILocation
    {
        private vector _perTick;
        private FixedLocation _startingPoint;
        private long _startingTick;

        public PoweredLocation(FixedLocation startingPoint, Direction direction, long speed)
        {
            _startingPoint = startingPoint;
            _perTick = new vector(direction, new Distance(speed));
            _startingTick = Time.Tick;
        }

        // cache
        private long currentTick;
        private FixedLocation locAtCurrentTick;

        public long X {
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

        public void Fix()
        {
            CalculateCurrentPosition(Time.Tick);
        }

        private void CalculateCurrentPosition(long tick)
        {
            currentTick = tick;

            var timeSinceStart = tick - _startingTick;
            vector vectorFromStart = _perTick * timeSinceStart;

            locAtCurrentTick = new FixedLocation(_startingPoint, vectorFromStart);
        }
    }
}
