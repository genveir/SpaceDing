using Space_Game.Simulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Shared
{
    public interface IView
    {
        void Initialize();

        void Start();

        void Display(SolarSystem system);
    }
}
