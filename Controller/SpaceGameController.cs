using ApplicationDomain;
using Space_Game.BasicModel;
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
    class SpaceGameController : IController
    {
        IView<IBody> view;
        IModel model;
        IDrawModel<IBody> currentDrawModel;

        public void Start()
        {
            model = StartUp.SetupUniverse();

            view = new FormView(this);

            view.Start();

            currentDrawModel = ((Universe)model).Systems.First();

            view.Initialize(currentDrawModel);

            Update(0);
        }

        public void Update(long ticks)
        {
            Time.Increment(ticks);

            view.Updating.WaitOne();
            view.Display(currentDrawModel);

            model.Update();
        }

        public void Stop()
        {

        }
    }
}
