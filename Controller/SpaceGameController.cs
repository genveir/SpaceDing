using Space_Game.Carrier;
using Space_Game.Simulation;
using Space_Game.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Space_Game.Controller
{
    class SpaceGameController
    {
        static void Main(string[] args)
        {
            var universe = StartUp.Start();

            IView view = new FormView();

            view.Start();

            view.Initialize(universe.Systems.First());

            while (true)
            {
                view.RequestUpdate.WaitOne();
                view.RequestUpdate.Reset();

                Update(universe, view);
            }
        }

        private static void Update(Universe universe, IView view)
        {
            Time.Increment(36000 * 24);

            view.Display(universe.Systems.First());

            universe.Update();
        }
    }
}
