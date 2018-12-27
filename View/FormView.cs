using ApplicationDomain;
using ApplicationDomain.Controller;
using Space_Game.BasicModel;
using Space_Game.BasicModel.DefaultBodies;
using Space_Game.Geometry;
using Space_Game.Simulation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Game.View
{
    public class FormView : IView<IBody>
    {
        private DisplayForm form;

        public IController<ILocation> Controller { get; set; }

        public FormView(IController<ILocation> controller)
        {
            Controller = controller;

            Updating = new ManualResetEvent(true);
        }

        public ManualResetEvent Updating { get; }

        public void Start()
        {
            form = new DisplayForm(this);

            ThreadPool.QueueUserWorkItem(callback =>
                {
                    Thread.CurrentThread.IsBackground = false;
                    Application.Run(form);
                });
        }

        public void Close()
        {
            Controller.Stop();
        }

        public void Select(ILocation location)
        {
            Controller.Selector.SelectAt(location);
        }

        private vector viewShift;
        private double zoomFactor;
        private IEnumerable<IBody> members;

        public void Initialize(IDrawModel<IBody> model)
        {
            members = model.Members;

            var currentOutermost = (long)members
                .Max(body => Distance.Calculate(FixedLocation.Zero, body.Location))
                .Value;

            var smallestDimension = 
                Math.Min(form.ClientRectangle.Height, form.ClientRectangle.Width);

            zoomFactor = currentOutermost / (0.9d * smallestDimension / 2);

            viewShift = vector.Zero;
        }

        public void Display(IDrawModel<IBody> model)
        {
            members = model.Members;

            Draw();
        }

        private void Draw()
        {
            Updating.Reset();

            var viewCenter = new RelativeLocation(FixedLocation.Zero, viewShift);

            form.Display(members, viewCenter, zoomFactor);

            Updating.Set();
        }

        public void AlterZoom(bool increase, FixedLocation location)
        {
            zoomFactor = zoomFactor * (increase ? 1.1d : 0.9d);

            vector locationAsVector = new vector(location);
            vector relativeLocation = locationAsVector - viewShift;
            viewShift += (increase ? -0.1d : 0.1d) * relativeLocation;

            Draw();
        }

        public void Redraw()
        {
            Draw();
        }

        internal void Update()
        {
             Controller.Update(60 * 60 * 24); // 1 day
        }
    }
}
