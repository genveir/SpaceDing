using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Carrier.Ships
{
    public class Part
    {
        public Part(string name, long mass, long powerDrain)
        {
            this.Name = name;
            this.Mass = mass;
            this.PowerDrain = powerDrain;
        }

        #region Primary Properties
        public string Name { get; }

        public long Mass { get; }

        public long PowerDrain { get; }
        #endregion

        #region Secondary Properties
        public long Thrust { get; protected set; }

        public long FuelAvailable { get; protected set; }

        public long FuelPerThrust { get; protected set; }

        public long PowerPerThrust { get; protected set; }

        public long ControlProvided { get; protected set; }

        public long ControlRequired { get; protected set; }
        #endregion
    }
}
