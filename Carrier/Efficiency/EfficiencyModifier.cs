using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Carrier.Efficiency
{
    /// <summary>
    /// How well does a part scale? 
    /// Mass Efficiency 0 means a part performs equally well at all sizes 
    /// Mass Efficiency 1000 means part performance halves whenever part size is double or half of the optimal size
    /// </summary>
    public class MassEfficiency
    {
        private long efficiency;

        public MassEfficiency(long efficiency)
        {
            this.efficiency = efficiency;
        }

        public long Apply(long mass, long optimalMass)
        {
            long fractionalPromillage;
            if (mass > optimalMass)
            {
                fractionalPromillage = (optimalMass * 1000) / mass;
            }
            else
            {
                fractionalPromillage = (mass * 1000) / optimalMass;
            }

            // 0 -> return 1000
            // 1000 -> return fractionalPromillage

            // ergo

            // 0 -> return fractionalPromillage * 0 + 1000 * 1
            // 1000 -> return fractionalPromillage * 1 + 1000 * 0

            var fractionPart = fractionalPromillage * efficiency;
            var basePart = 1000 * (1000 - efficiency);

            var summed = fractionPart + basePart;
            var divided = summed / 1000;

            return divided;
        }
    }

    public class PowerEfficiency
    {
        private long efficiency;

        public PowerEfficiency(long efficiency)
        {
            this.efficiency = efficiency;
        }

        public long Apply(long thrust)
        {
            return 1000;
        }
    }

    public class FuelEfficiency
    {
        private long efficiency;

        public FuelEfficiency(long efficiency)
        {
            this.efficiency = efficiency;
        }

        public long Apply(long thrust)
        {
            return 1000;
        }
    }
}
