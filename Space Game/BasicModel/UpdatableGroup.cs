using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Space_Game.Simulation;

namespace Space_Game.BasicModel
{
    public abstract class UpdatableGroup<T> : IUpdatable
        where T : IUpdatable
    {
        private long lastUpdate;

        protected ConcurrentBag<T> members = new ConcurrentBag<T>();

        public IEnumerable<T> Members { get { return members; } }
        public IEnumerable<T> RecursiveMembers { get
            {
                ConcurrentBag<T> recursiveMembers = new ConcurrentBag<T>();

                AddRecursiveMembers(recursiveMembers);

                return recursiveMembers;
            }
        }

        protected void AddRecursiveMembers(ConcurrentBag<T> recursiveMembers)
        {
            Parallel.ForEach(Members, member =>
            {
                recursiveMembers.Add(member);

                var group = member as UpdatableGroup<T>;

                if (group != null)
                {
                    group.AddRecursiveMembers(recursiveMembers);
                }
            });
        }

        public void AddMember(T member)
        {
            members.Add(member);
        }

        public void RemoveMember(T member)
        {
            members.TryTake(out member);
        }

        public void AddMembers(IEnumerable<T> members)
        {
            Parallel.ForEach(members, member =>
            {
                AddMember(member);
            });
        }

        public void RemoveMembers(IEnumerable<T> members)
        {
            Parallel.ForEach(members, member =>
            {
                RemoveMember(member);
            });
        }

        private bool _observed;
        public virtual bool Observed
        {
            get { return _observed; }
            set
            {
                _observed = value;
                Parallel.ForEach(members, member =>
                {
                    member.Observed = value;
                });
            }
        }

        public virtual void Update()
        {
            lock (this)
            {
                if (lastUpdate == Time.Tick) return;
                lastUpdate = Time.Tick;
            }

            if (Observed)
            {
                Parallel.ForEach(members, member =>
                {
                    member.Update();
                });

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
