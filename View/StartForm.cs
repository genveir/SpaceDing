using ApplicationDomain.Controller;
using Space_Game.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Game.View
{
    public partial class StartForm : Form
    {
        private IController<ILocation> controller;

        public StartForm(IController<ILocation> controller)
        {
            InitializeComponent();

            this.controller = controller;
        }

        private void btn_SolarSytem_Click(object sender, EventArgs e)
        {
            controller.Start("SolarSystem");

            this.Visible = false;
        }

        private void btn_JustCarrier_Click(object sender, EventArgs e)
        {
            controller.Start("Carrier");

            this.Visible = false;
        }
    }
}
