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
    public class FormView : IView
    {
        private DisplayForm form;

        public ManualResetEvent RequestUpdate { get; set; }

        public FormView()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        }

        public void Start()
        {
            form = new DisplayForm(this);

            ThreadPool.QueueUserWorkItem(callback => Application.Run(form));

            RequestUpdate = new ManualResetEvent(true);
        }

        private vector viewShift;
        private double zoomFactor;
        private IEnumerable<IBody> members;

        public void Initialize(SolarSystem system)
        {
            members = system.Members;

            var currentOutermost = (long)members
                .Max(body => Distance.Calculate(FixedLocation.Zero, body.Location))
                .Value;

            var smallestDimension = 
                Math.Min(form.ClientRectangle.Height, form.ClientRectangle.Width);

            zoomFactor = currentOutermost / (0.9d * smallestDimension / 2);

            viewShift = vector.Zero;
        }

        public void Display(SolarSystem system)
        {
            members = system.Members;

            Draw();
        }

        private void Draw()
        {
            var viewCenter = new RelativeLocation(FixedLocation.Zero, viewShift);

            form.Display(members, viewCenter, zoomFactor);
        }

        public void AlterZoom(bool increase, FixedLocation location)
        {
            zoomFactor = zoomFactor * (increase ? 1.1d : 0.9d);

            vector locationAsVector = new vector(location);
            vector relativeLocation = locationAsVector - viewShift;
            viewShift += (increase ? -0.1d : 0.1d) * relativeLocation;

            Draw();
        }

        public void Update()
        {
            RequestUpdate.Set();
        }

        public void Redraw()
        {
            Draw();
        }
    }
}
