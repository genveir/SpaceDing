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
        private struct UniverseViewPair
        {
            public Universe universe;
            public IView view;
        }

        private static UniverseViewPair toUpdate;

        static void Main(string[] args)
        {
            var universe = StartUp.Start();

            IView view = new FormView();
            view.Initialize();

            view.Start();

            toUpdate = new UniverseViewPair();
            toUpdate.universe = universe;
            toUpdate.view = view;

            while (true)
            {
                //view.RequestUpdate.WaitOne();
                //view.RequestUpdate.Reset();

                Update();
            }
        }

        private static void Update()
        {
            var universe = toUpdate.universe;
            var view = toUpdate.view;

            Time.Increment(36000 * 24);

            view.Display(universe.Systems.First());

            universe.Update();
        }
    }
}
