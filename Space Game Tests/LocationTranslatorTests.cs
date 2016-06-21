using NUnit.Framework;
using Space_Game.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.View
{
    class LocationTranslatorTests
    {
        [Test]
        public void ZeroLocationIsCentered()
        {
            var translator = new LocationTranslator(FixedLocation.Zero, new Rectangle(0, 0, 100, 100), 20.0d);

            var point = translator.ToPoint(FixedLocation.Zero);

            Assert.AreEqual(50, point.X);
            Assert.AreEqual(50, point.Y);
        }

        [TestCase(400, 0, 70, 50)]
        [TestCase(0, 400, 50, 70)]
        [TestCase(0, -400, 50, 30)]
        [TestCase(-400, 0, 30, 50)]
        [TestCase(-400, 400, 30, 70)]
        public void LocationMapsCorrectly(long X, long Y, int correctX, int correctY)
        {
            var translator = new LocationTranslator(FixedLocation.Zero, new Rectangle(0, 0, 100, 100), 20.0d);

            var point = translator.ToPoint(new FixedLocation(X, Y));

            Assert.AreEqual(correctX, point.X);
            Assert.AreEqual(correctY, point.Y);
        }

        [Test]
        public void CenterIsZeroLocation()
        {
            var translator = new LocationTranslator(FixedLocation.Zero, new Rectangle(0, 0, 100, 100), 20.0d);

            var location = translator.ToFixedLocation(new Point(50, 50));

            Assert.AreEqual(0, location.X);
            Assert.AreEqual(0, location.Y);
        }

        [TestCase(70, 50, 400, 0)]
        [TestCase(50, 70, 0, 400)]
        [TestCase(50, 30, 0, -400)]
        [TestCase(30, 50, -400, 0)]
        [TestCase(30, 70, -400, 400)]
        public void PointMapsCorrectly(int X, int Y, long correctX, long correctY)
        {
            var translator = new LocationTranslator(FixedLocation.Zero, new Rectangle(0, 0, 100, 100), 20.0d);

            var location = translator.ToFixedLocation(new Point(X, Y));

            Assert.AreEqual(correctX, location.X);
            Assert.AreEqual(correctY, location.Y);
        }
    }
}
