using NUnit.Framework;
using Space_Game.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game
{
    class VectorTests
    {
        [Test]
        public void AddingTwoVectorsWithTheSameDirectionWorks()
        {
            vector v1 = new vector(10, 5);
            vector v2 = new vector(20, 10);

            var v3 = v1 + v2;

            Assert.AreEqual(30, v3.XOffset);
            Assert.AreEqual(15, v3.YOffset);

            Assert.LessOrEqual(Math.Abs((v1.Direction - v2.Direction).InRadians.toDouble()), 0.001d);
            Assert.LessOrEqual(Math.Abs((v1.Direction - v3.Direction).InRadians.toDouble()), 0.001d);
        }
    }
}
