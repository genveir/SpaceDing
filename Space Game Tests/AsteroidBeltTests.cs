using NUnit.Framework;
using Space_Game.BasicModel.DefaultBodies;
using Space_Game.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game
{
    class AsteroidBeltTests
    {
        [Test]
        public void BeltHasTheRightNumberOfAsteroids()
        {
            var Sun = new Star(null, "Star", FixedLocation.Zero, 100);

            var belt = Sun.AddAsteroidBelt("belt", new Distance(1000), new Distance(2000));

            belt.GenerateAsteroids(1, "b", new radian(0.1d));

            Assert.AreEqual(1, belt.Members.Count());
        }

        [Test]
        public void AsteroidsAreInRecursiveMembers()
        {
            var Sun = new Star(null, "Star", FixedLocation.Zero, 100);

            Sun.AddAsteroidBelt("belt", new Distance(1000), new Distance(2000))
                .GenerateAsteroids(10, "b", new radian(0.1d));

            var recursiveMembers = Sun.Members;

            Assert.AreEqual(10, recursiveMembers.Count());
        }
    }
}
