using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Space_Game.Geometry;

namespace Space_Game.BasicModel.DefaultBodies
{
    public class AsteroidBelt : UpdatableGroup<IUpdatable>
    {
        public string Name { get; set; }
        public Distance InnerRange { get; set; }
        public Distance OuterRange { get; set; }
        public ILocation Center { get; set; }

        public AsteroidBelt(ILocation center, string name, Distance innerRange, Distance outerRange)
        {
            Center = center;
            Name = name;
            InnerRange = innerRange;
            OuterRange = outerRange;
        }

        public void GenerateAsteroids(int number, string namePrefix, radian orbitSpeed)
        {
            Distance rangeDepth = OuterRange - InnerRange;

            Random rnd = new Random();

            Parallel.For(0, number, n =>
            {
                var range = new Distance(rnd.NextDouble() * rangeDepth.Value + InnerRange);
                var angle = Direction.FromCirclePortion(rnd.NextDouble());

                var asteroid = new Asteroid(
                    name: string.Format("{0}_{1}", namePrefix, n),
                    location: new OrbitLocation(Center, angle, range, orbitSpeed),
                    mass: 1000,
                    parent: this);

                AddMember(asteroid);
            });
        }
    }
}
