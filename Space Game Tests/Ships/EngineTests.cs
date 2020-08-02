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


        [TestCase(0)]
        [TestCase(1000)]
        [TestCase(10000)]
        public void EngineOutputsBaseThrustTimesMassAtOptimalMass(long massEfficiency)
        {
            var engine = CreateBasicTestEngine(massEfficiency: massEfficiency);

            Assert.That(engine.Mass, Is.EqualTo(engine.OptimalMass));
            Assert.That(engine.Thrust, Is.EqualTo(engine.BaseThrust * engine.Mass));
        }

        [Test]
        public void EngineWith0MassEfficiencyOutputsBaseThrustTimesMassAtDoubleMass()
        {
            var engine = CreateBasicTestEngine(mass: 2000, massEfficiency: 0);

            Assert.That(engine.Thrust, Is.EqualTo(engine.BaseThrust * engine.Mass));
        }

        [Test]
        public void EngineWith1000MassEfficiencyOutputsTheSameThrustAtDoubleMass()
        {
            var basicEngine = CreateBasicTestEngine(mass: 1000, massEfficiency: 0);
            var engine = CreateBasicTestEngine(mass: 2000, massEfficiency: 1000);

            // expected: mass * base = 2000 * 10000 = 200000000, mass is twice the optimal, so performance is half of that

            Assert.That(engine.Thrust, Is.EqualTo(basicEngine.Thrust));
        }

        [Test]
        public void EngineWith1000MassEfficiencyOutputsTheSameThrustAtQuadrupleMass()
        {
            var basicEngine = CreateBasicTestEngine(mass: 1000, massEfficiency: 0);
            var engine = CreateBasicTestEngine(mass: 4000, massEfficiency: 1000);

            // expected: mass * base = 4000 * 10000 = 400000000, mass is quadruple the optimal, so performance is a quarter of that

            Assert.That(engine.Thrust, Is.EqualTo(basicEngine.Thrust));
        }

        [Test]
        public void EngineWith1000MassEfficiencyOutputsAQuarterAtHalfMass()
        {
            var basicEngine = CreateBasicTestEngine(mass: 1000, massEfficiency: 0);
            var engine = CreateBasicTestEngine(mass: 500, massEfficiency: 1000);

            // expected: mass * base = 500 * 10000 = 5000000, mass is half the optimal, so performance is half of that

            Assert.That(engine.Thrust, Is.EqualTo(basicEngine.Thrust / 4));
        }

        [TestCase(500)]
        [TestCase(990)]
        [TestCase(1010)]
        [TestCase(2000)]
        public void EnginesWithMassEfficiencyBetween0And1000PerformSomwhereInbetween(long engineMass)
        {
            var engine0 = CreateBasicTestEngine(massEfficiency: 0, mass: engineMass);
            var engine1000 = CreateBasicTestEngine(massEfficiency: 1000, mass: engineMass);

            for (int mef = 100; mef < 1000; mef += 100)
            {
                var engine = CreateBasicTestEngine(massEfficiency: mef, mass: engineMass);

                Assert.That(engine0.Thrust, Is.GreaterThan(engine.Thrust));
                Assert.That(engine.Thrust, Is.GreaterThan(engine1000.Thrust));
            }
        }

        private Engine CreateBasicTestEngine(long mass = 1000, long powerDrain = 0, long powerEfficiency = 0, long baseThrust = 10000, long optimalMass = 1000, long massEfficiency = 200, long fuelEfficiency = 1000)
        {
            return new ConfigurableEngine(mass, powerDrain, powerEfficiency, baseThrust, optimalMass, massEfficiency, fuelEfficiency);
        }

        private class ConfigurableEngine : Engine
        {
            public ConfigurableEngine(long mass, long powerDrain, long powerEfficiency, long baseThrust, long optimalMass, long massEfficiency, long fuelEfficiency)
                : base(
                      "configurable", 
                      mass, 
                      powerDrain, 
                      new PowerEfficiency(powerEfficiency), 
                      baseThrust,
                      optimalMass,
                      new MassEfficiency(massEfficiency), 
                      new FuelEfficiency(fuelEfficiency))
            {

            }
        }
    }
}
