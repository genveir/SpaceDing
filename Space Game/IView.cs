using Space_Game.Simulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Space_Game
{ 
    public interface IView
    {
        ManualResetEvent RequestUpdate { get; set; }

        void Initialize();

        void Start();

        void Display(SolarSystem system);
    }
}
