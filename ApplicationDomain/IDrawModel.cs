using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ApplicationDomain
{
    public interface IDrawModel<T>
    {
        IEnumerable<T> Members { get; }
    }
}