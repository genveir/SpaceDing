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

            var v1Dir = v1.Direction.InRadians.toDouble();
            var v2Dir = v2.Direction.InRadians.toDouble();
            var v3Dir = v3.Direction.InRadians.toDouble();

            Assert.LessOrEqual(Math.Abs(v1Dir - v2Dir), 0.001d);
            Assert.LessOrEqual(Math.Abs(v1Dir - v3Dir), 0.001d);
        }

        [Test]
        public void VectorsHaveTheDirectionTheyreCreatedWith()
        {
            vector v1 = new vector(Direction.FromRadian(new radian(Math.PI)), new Distance(10000));

            Assert.AreEqual(new radian(Math.PI), v1.Direction.InRadians);
        }
    }
}
