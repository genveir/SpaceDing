using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Space_Game.Geometry;
using Space_Game.Simulation;
using System.Collections.Concurrent;

namespace Space_Game.BasicModel.DefaultBodies
{
    public abstract class Body : IBody, IUpdatableGroup<IBody>
    {
        public IUpdatableGroup<IBody> Parent { get; set; }

        public string Name { get; set; }

        public ILocation Location { get; set; }

        public long Mass { get; set; }

        public Body(IUpdatableGroup<IBody> parent, string name, ILocation location, long mass)
        {
            Parent = parent;
            Name = name;
            Location = location;
            Mass = mass;
        }

        public IEnumerable<IBody> Members { get { return _members; } }
        protected ConcurrentBag<IBody> _members;

        public void AddMember(IBody body)
        {
            if (_members != null) _members.Add(body);

            if (Parent != null) Parent.AddMember(body);
        } 

        public void RemoveMember(IBody body)
        {
            if (_members != null) _members.TryTake(out body);

            if (Parent != null) Parent.RemoveMember(body);
        }

        private bool _observed;
        public virtual bool Observed
        {
            get
            {
                lock (this)
                {
                    return _observed;
                }
            }
            set
            {
                lock (this)
                {
                    _observed = value;
                }
            }
        }

        private long lastUpdate;
        public virtual void Update()
        {
            lock (this)
            {
                if (lastUpdate == Time.Tick) return;
                lastUpdate = Time.Tick;
            }

            if (Observed)
            {
                ObservedUpdate();
            }
            else
            {
                UnObservedUpdate();
            }
        }

        protected virtual void ObservedUpdate()
        {

        }

        protected virtual void UnObservedUpdate()
        {

        }
    }
}
