using Space_Game.BasicModel;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Simulation
{
    public class SolarSystem : IUpdatable, IUpdatableGroup<IBody>
    {
        public IUpdatableGroup<IBody> Parent { get; set; }

        private ConcurrentBag<IBody> _members;
        public IEnumerable<IBody> Members { get { return _members; } }

        public SolarSystem()
        {
            _members = new ConcurrentBag<IBody>();
        }

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

        private long _lastUpdate;
        public virtual void Update()
        {
            lock (this)
            {
                if (_lastUpdate == Time.Tick) return;
                _lastUpdate = Time.Tick;
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