using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Space_Game.Geometry;

namespace Space_Game.BasicModel.DefaultBodies
{
    public abstract class Body : UpdatableGroup<IUpdatable>, IBody
    {
        public Body(string name, ILocation location, long mass)
        {
            Name = name;
            Location = location;
            Mass = mass;
        }

        public string Name { get; set; }

        public ILocation Location { get; set; }

        public long Mass { get; set; }

        protected override void ObservedUpdate()
        {
            Location.Fix();
        }
    }
}
