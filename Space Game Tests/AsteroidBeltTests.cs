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
            var Belt = new AsteroidBelt(null, FixedLocation.Zero, "belt", new Distance(1000), new Distance(2000));

            Belt.GenerateAsteroids(1, "b", new radian(0.1d), new radian(0.2d));

            Assert.AreEqual(1, Belt.Members.Count());
        }

        [Test]
        public void AsteroidsAreInRecursiveMembers()
        {
            var Sun = new Star(null, "Star", FixedLocation.Zero, 100);

            Sun.AddAsteroidBelt("belt", new Distance(1000), new Distance(2000))
                .GenerateAsteroids(10, "b", new radian(0.1d), new radian(0.1d));

            var recursiveMembers = Sun.Members;

            Assert.AreEqual(10, recursiveMembers.Count());
        }

        [Test]
        public void SpeedsFallInTheRightRange()
        {
            var Belt = new AsteroidBelt(null, FixedLocation.Zero, "belt", new Distance(1000), new Distance(2000));

            Belt.GenerateAsteroids(10000, "b", new radian(0.1d), new radian(0.2d));

            foreach (var asteroid in Belt.Members)
            {
                var orbitSpeed = ((OrbitLocation)asteroid.Location).RotationSpeed;

                Assert.True(orbitSpeed > new radian(0.09999d));
                Assert.True(orbitSpeed < new radian(0.20001d));
            }
        }
    }
}
