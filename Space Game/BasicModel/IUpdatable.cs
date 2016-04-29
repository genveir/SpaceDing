using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.BasicModel
{
    public interface IUpdatable
    {
        bool Observed { get; set; }
        void Update();
    }
}
