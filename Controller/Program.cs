using Space_Game.Carrier;
using Space_Game.Shared;
using Space_Game.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            view.Display(universe.Systems.First());
        }
    }
}
