using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.BasicModel
{
    public interface IUpdatableGroup<T>
    {
        IUpdatableGroup<T> Parent { get; set; }

        IEnumerable<T> Members { get; }

        void AddMember(T member);

        void RemoveMember(T member);
    }
}
