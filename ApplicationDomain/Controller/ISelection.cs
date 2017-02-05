using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.Controller
{
    public interface ISelector<Loc>
    {
        void SelectAt(Loc Location);
    }
}
