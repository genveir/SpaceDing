using Space_Game.Carrier.Ships.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Carrier.Ships
{
    public abstract class Part
    {
        public abstract void SetSecondaryProperties();

        #region Primary Properties
        public abstract string Name { get; protected set; }

        public virtual long Mass { get; protected set; }

        public virtual long PowerDrain { get; protected set; }
        #endregion

        #region Secondary Properties
        public virtual long Thrust { get; protected set; }

        public virtual long FuelAvailable { get; protected set; }

        public virtual long FuelPerThrust { get; protected set; }

        public virtual long ControlProvided { get; protected set; }

        public virtual long ControlRequired { get; protected set; }
        #endregion
    }
}
