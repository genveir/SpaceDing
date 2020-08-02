using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Carrier.Efficiency
{
    public abstract class EfficiencyModifier
    {
        public EfficiencyModifier(long efficiency)
        {
            this.Efficiency = efficiency;
        }

        public long Efficiency { get; protected set; }

        public long Apply(long input)
        {
            return (input * Efficiency) / 1000;
        }
    }

    public class MassEfficiency : EfficiencyModifier { public MassEfficiency(long efficiency) : base(efficiency) { } }
    public class PowerEfficiency : EfficiencyModifier { public PowerEfficiency(long efficiency) : base(efficiency) { } }
    public class FuelEfficiency : EfficiencyModifier { public FuelEfficiency(long efficiency) : base(efficiency) { } }
}
