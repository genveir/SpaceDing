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
        static void Main(string[] args)
        {
            var universe = StartUp.Start();

            IView view = new FormView();
            view.Initialize();

            view.Start();

            for (int n = 0; n < 100000; n++)
            {
                Time.Incement(3600 * 7);

                universe.Update();

                view.Display(universe.Systems.First());

                Thread.Sleep(10);
            }

            Console.ReadLine();
        }
    }
}
