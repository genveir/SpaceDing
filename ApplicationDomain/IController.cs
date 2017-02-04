using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain
{
    public interface IController
    {
        void Start();

        void Update(long ticksToSimulate);

        void Stop();
    }
}
