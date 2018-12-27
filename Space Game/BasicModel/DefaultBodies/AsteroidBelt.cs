using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Space_Game.Geometry;
using System.Collections.Concurrent;

namespace Space_Game.BasicModel.DefaultBodies
{
    public class AsteroidBelt : IUpdatableGroup<IBody>
    {
        public IUpdatableGroup<IBody> Parent { get; set; }
        public string Name { get; set; }
        public Distance InnerRange { get; set; }
        public Distance OuterRange { get; set; }
        public ILocation Center { get; set; }

        public AsteroidBelt(IUpdatableGroup<IBody> parent, ILocation center, string name, Distance innerRange, Distance outerRange)
        {
            Parent = parent;
            Center = center;
            Name = name;
            InnerRange = innerRange;
            OuterRange = outerRange;

            _members = new ConcurrentBag<IBody>();
        }

        public void GenerateAsteroids(int number, string namePrefix, radian orbitSpeed)
        {
            Distance rangeDepth = OuterRange - InnerRange;

            Random rnd = new Random();

            Parallel.For(0, number, n =>
            {
                var ratio = rnd.NextDouble();
                var angle = Direction.FromCirclePortion(rnd.NextDouble());

                var orbitDistance = new Distance(ratio * rangeDepth + InnerRange);

                var asteroid = new Asteroid(
                    name: string.Format("{0}_{1}", namePrefix, n),
                    location: new OrbitLocation(Center, angle, orbitDistance, orbitSpeed),
                    mass: 100000,
                    parent: this);

                AddMember(asteroid);
            });
        }

        private ConcurrentBag<IBody> _members;

        public IEnumerable<IBody> Members { get { return _members; } }

        public void AddMember(IBody body)
        {
            _members.Add(body);

            if (Parent != null) Parent.AddMember(body);
        }

        public void RemoveMember(IBody body)
        {
            _members.TryTake(out body);

            if (Parent != null) Parent.RemoveMember(body);
        }
    }
}
