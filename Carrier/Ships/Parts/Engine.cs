using Space_Game.Carrier.Efficiency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Carrier.Ships.Parts
{
    public abstract class Engine : Part
    {
        public long BaseThrust { get; protected set; }

        public MassEfficiency MassEfficiency { get; protected set; }

        public FuelEfficiency FuelEfficiency { get; protected set; }

        public PowerEfficiency PowerEfficiency { get; protected set; }

        public Engine(string name, long mass, long powerDrain, PowerEfficiency powerEfficiency, long baseThrust, MassEfficiency massEfficiency, FuelEfficiency fuelEfficiency)
            :base(name, mass, powerDrain)
        {
            this.BaseThrust = baseThrust;
            this.MassEfficiency = massEfficiency;
            this.FuelEfficiency = fuelEfficiency;
            this.PowerEfficiency = powerEfficiency;

            this.Thrust = this.MassEfficiency.Apply(this.BaseThrust);
            this.FuelPerThrust = this.FuelEfficiency.Apply(this.BaseThrust);
            this.PowerPerThrust = this.PowerEfficiency.Apply(this.BaseThrust);
        }
    }
}
