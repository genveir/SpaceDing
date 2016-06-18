using Space_Game.BasicModel;
using Space_Game.BasicModel.DefaultBodies;
using Space_Game.Geometry;
using Space_Game.Simulation;
using System;
using System.Collections.Generic;
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

        public void Initialize()
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

        private IEnumerable<IBody> members;
        private ILocation center;
        private long outermostBodyDistance;

        public void Display(SolarSystem system)
        {
            members = system.Members;

            var starLocations = members
                .Where(body => body is Star)
                .Select(star => (star as Star).Location);

            center = new FixedLocation(
                (long)starLocations.Average(loc => loc.X),
                (long)starLocations.Average(loc => loc.Y));

            var currentOutermost = (long)members
                .Max(body => Distance.Calculate(center, body.Location))
                .Value;

            outermostBodyDistance = (currentOutermost > outermostBodyDistance) ? currentOutermost : outermostBodyDistance;

            Draw();
        }

        private void Draw()
        {
            var smallestDimension = Math.Min(form.ClientRectangle.Height, form.ClientRectangle.Width);

            var distancePerPixel = outermostBodyDistance / (0.9d * smallestDimension / 2);

            form.Display(members, center, distancePerPixel);
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
