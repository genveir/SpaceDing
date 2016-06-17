using Space_Game.Carrier;
using Space_Game.Shared;
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
    class Program
    {
        private struct UniverseViewPair
        {
            public Universe universe;
            public IView view;
        }

        static void Main(string[] args)
        {
            var universe = StartUp.Start();

            IView view = new FormView();
            view.Initialize();

            view.Start();

            var universeAndView = new UniverseViewPair();
            universeAndView.universe = universe;
            universeAndView.view = view;

            var timer = new Timer(Update, universeAndView, 0, 1000 / 60);

            Console.ReadLine();
        }

        private static void Update(Object updateinfo)
        {
            var universeAndView = (UniverseViewPair)updateinfo;
            var universe = universeAndView.universe;
            var view = universeAndView.view;

            Time.Increment(3600 * 7);

            universe.Update();

            view.Display(universe.Systems.First());
        }
    }
}
