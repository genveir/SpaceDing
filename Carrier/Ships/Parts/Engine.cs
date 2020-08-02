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

        public long OptimalMass { get; protected set; }

        public MassEfficiency MassEfficiency { get; protected set; }

        public FuelEfficiency FuelEfficiency { get; protected set; }

        public PowerEfficiency PowerEfficiency { get; protected set; }

        public Engine(string name, long mass, long powerDrain, PowerEfficiency powerEfficiency, long baseThrust, long optimalMass, MassEfficiency massEfficiency, FuelEfficiency fuelEfficiency)
            :base(name, mass, powerDrain)
        {
            this.BaseThrust = baseThrust;
            this.OptimalMass = optimalMass;

            this.MassEfficiency = massEfficiency;
            this.FuelEfficiency = fuelEfficiency;
            this.PowerEfficiency = powerEfficiency;

            this.Thrust = (BaseThrust * Mass) * this.MassEfficiency.Apply(this.Mass, this.OptimalMass) / 1000;
            this.FuelPerThrust = this.FuelEfficiency.Apply(this.BaseThrust);
            this.PowerPerThrust = this.PowerEfficiency.Apply(this.BaseThrust);
        }
    }
}
