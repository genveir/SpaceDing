﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Space_Game.Geometry;
using Space_Game.Simulation;

namespace Space_Game
{
    public class OrbitTests
    {
        private static radian halfPI = new radian(Math.PI / 2);

        [Test]
        public void TestOrbitPositionsOnCreation()
        {
            Time.Reset();

            var center = new FixedLocation(100, 100);

            var orbit = new OrbitLocation(center, new FixedLocation(200, 100), halfPI);

            Assert.AreEqual(200, orbit.X);
            Assert.AreEqual(100, orbit.Y);

            orbit = new OrbitLocation(center, new FixedLocation(100, 200), halfPI);

            Assert.AreEqual(100, orbit.X);
            Assert.AreEqual(200, orbit.Y);

            orbit = new OrbitLocation(center, new FixedLocation(100, 0), halfPI);

            Assert.AreEqual(100, orbit.X);
            Assert.AreEqual(0, orbit.Y);

            orbit = new OrbitLocation(center, new FixedLocation(0, 100), halfPI);

            Assert.AreEqual(0, orbit.X);
            Assert.AreEqual(100, orbit.Y);
        }

        [Test]
        public void TestOrbitPositionsOnRotation()
        {
            Time.Reset();

            var center = new FixedLocation(100, 100);

            var orbit = new OrbitLocation(center, new FixedLocation(200, 100), halfPI);

            Assert.AreEqual(200, orbit.X);
            Assert.AreEqual(100, orbit.Y);

            Time.Increment();

            Assert.AreEqual(100, orbit.X);
            Assert.AreEqual(0, orbit.Y);

            Time.Increment();

            Assert.AreEqual(0, orbit.X);
            Assert.AreEqual(100, orbit.Y);

            Time.Increment();

            Assert.AreEqual(100, orbit.X);
            Assert.AreEqual(200, orbit.Y);
        }

        [Test]
        public void TestEqualDistanceOnSameRotation()
        {
            Time.Reset();

            var center = FixedLocation.Zero;
            var rotation = halfPI / 100.0d;

            var orbit1 = new OrbitLocation(center, new FixedLocation(200000, 200000), rotation);
            var orbit2 = new OrbitLocation(center, new FixedLocation(-500000, 1000000), rotation);

            var distance = Distance.Calculate(orbit1, orbit2);

            for (int n = 0; n < 400; n++)
            {
                Time.Increment();

                var difference = Math.Abs(distance - Distance.Calculate(orbit1, orbit2));

                Assert.LessOrEqual(difference, 10.0d);
            }
        }

        [TestCase(3L, 4L, 5.0d)]
        [TestCase(0L, 100L, 100.0d)]
        [TestCase(3000000L, 4000000L, 5000000d)]
        public void HypothenuseIsCorrect(long X, long Y, double correctDifference)
        {
            var distance = Distance.Calculate(new FixedLocation(0, X), new FixedLocation(Y, 0)).Value;

            var difference = Math.Abs(distance - correctDifference);

            Assert.LessOrEqual(difference, 0.01d);
        }
    }
}
