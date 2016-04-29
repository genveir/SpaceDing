using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Simulation
{
    public class Time
    {
        public static long Tick { get; set; }

        public static long Increment()
        {
            Tick++;

            return Tick;
        }

        public static void Reset()
        {
            Tick = 0;
        }
    }
}
