using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.Controller
{
    public interface IController<Loc>
    {
        ISelector<Loc> Selector { get; }

        void Start();

        void Update(long ticksToSimulate);

        void Stop();
    }
}
