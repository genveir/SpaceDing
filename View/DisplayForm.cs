using Space_Game.BasicModel;
using Space_Game.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Game.View
{
    public partial class DisplayForm : Form
    {
        private delegate void DisplayDelegate(IEnumerable<IBody> toShow, ILocation center, double distancePerPixel);

        public DisplayForm()
        {
            InitializeComponent();
        }

        private void DisplayForm_Load(object sender, EventArgs e)
        {

        }

        public void Display(IEnumerable<IBody> toShow, ILocation center, double distancePerPixel)
        {
            this.Invoke(new DisplayDelegate(DoDisplay), new object[] { toShow, center, distancePerPixel });
        }

        private void DoDisplay(IEnumerable<IBody> toShow, ILocation center, double distancePerPixel)
        {
            var xCenter = center.X;
            var yCenter = center.Y;
        }
    }
}
