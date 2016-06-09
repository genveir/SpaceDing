using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.BasicModel
{
    public abstract class UpdatableGroup<T> : IUpdatable
        where T : IUpdatable
    {
        protected HashSet<T> members = new HashSet<T>();

        public IEnumerable<T> Members { get { return members; } }
        public IEnumerable<T> RecursiveMembers { get
            {
                return members
                    .Where(member => member is UpdatableGroup<T>)
                    .SelectMany(member => (member as UpdatableGroup<T>).RecursiveMembers)
                    .Union(members);
            }
        }

        public void AddMember(T member)
        {
            members.Add(member);
        }

        public void RemoveMember(T member)
        {
            members.Remove(member);
        }

        public void AddMembers(IEnumerable<T> members)
        {
            foreach(var member in members)
            {
                AddMember(member);
            }
        }

        public void RemoveMembers(IEnumerable<T> members)
        {
            foreach(var member in members)
            {
                RemoveMember(member);
            }
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
            if (Observed)
            {
                Parallel.ForEach(members, member =>
                {
                    member.Update();
                });
            }
            else
            {
                UnObservedUpdate();
            }
        }

        protected virtual void UnObservedUpdate()
        {
            // by default, an unobserved update does nothing
        }
    }
}
