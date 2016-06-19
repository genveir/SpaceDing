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
        /// <summary>
        /// request an update of the viewstate from the controller
        /// </summary>
        ManualResetEvent RequestUpdate { get; set; }

        void Start();

        void Initialize(SolarSystem system);

        void Display(SolarSystem system);

        void Redraw();
    }
}
