using NUnit.Framework;
using Space_Game.Carrier.Efficiency;
using Space_Game.Carrier.Ships.Parts;
using Space_Game.Carrier.Ships.Parts.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game
{
    public class EngineTests
    {
        [Test]
        public void BasicTestEngineOutputsThrust()
        {
            var engine = CreateBasicTestEngine();

            Assert.That(engine.Thrust, Is.GreaterThan(0));
        }

        [Test]
        public void EngineWith0BaseThrustOutputsZeroThrust()
        {
            var engine = CreateBasicTestEngine(baseThrust: 0);

            Assert.That(engine.Thrust, Is.Zero);
        }

        [Test]
        public void EngineWith0MassEfficiencyOutputsBaseThrustInThrust()
        {
            var engine = CreateBasicTestEngine(massEfficiency: 0);

            Assert.That(engine.Thrust, Is.EqualTo(engine.BaseThrust));
        }

        private Engine CreateBasicTestEngine(long mass = 1000, long powerDrain = 0, long powerEfficiency = 0, long baseThrust = 10000, long massEfficiency = 1000, long fuelEfficiency = 1000)
        {
            return new ConfigurableEngine(mass, powerDrain, powerEfficiency, baseThrust, massEfficiency, fuelEfficiency);
        }

        private class ConfigurableEngine : Engine
        {
            public ConfigurableEngine(long mass, long powerDrain, long powerEfficiency, long baseThrust, long massEfficiency, long fuelEfficiency)
                : base(
                      "configurable", 
                      mass, 
                      powerDrain, 
                      new PowerEfficiency(powerEfficiency), 
                      baseThrust, 
                      new MassEfficiency(massEfficiency), 
                      new FuelEfficiency(fuelEfficiency))
            {

            }
        }
    }
}
