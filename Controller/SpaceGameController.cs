using ApplicationDomain;
using ApplicationDomain.Controller;
using Space_Game.BasicModel;
using Space_Game.Carrier;
using Space_Game.Geometry;
using Space_Game.Simulation;
using Space_Game.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Game.Controller
{
    class SpaceGameController : IController<ILocation>
    {
        IView<IBody> view;
        IModel model;
        IDrawModel<IBody> currentDrawModel;

        public ISelector<ILocation> Selector { get; private set; }

        public void Start()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var menu = new StartForm(this);

            Application.Run(menu);
        }

        public void Start(string scenario)
        {
            switch(scenario)
            {
                case "Carrier": model = StartUp.SetupJustCarrier(); break;
                default: model = StartUp.SetupUniverse(); break;
            }

            Selector = new LocationSelector(model);

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
