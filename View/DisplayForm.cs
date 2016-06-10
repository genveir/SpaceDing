using Space_Game.BasicModel;
using Space_Game.BasicModel.DefaultBodies;
using Space_Game.Geometry;
using Space_Game.Simulation;
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
        private struct DrawObject
        {
            public Point location;
            public Color color;
            public string name;
        }

        private List<DrawObject> toDraw = new List<DrawObject>();
        private DrawBuffer drawBuffer;

        public DisplayForm()
        {
            InitializeComponent();

            DoubleBuffered = true;
        }

        private void DisplayForm_Load(object sender, EventArgs e)
        {
            drawBuffer = new DrawBuffer(ClientRectangle, 2);
        }

        public void Display(IEnumerable<IBody> toShow, ILocation center, double distancePerPixel)
        {
            var newToDraw = new List<DrawObject>();

            var centerAsVector = new vector(center);

            var centerX = ClientRectangle.Width / 2;
            var centerY = ClientRectangle.Height / 2;

            foreach (var body in toShow)
            {
                var drawObject = new DrawObject() { name = body.Name, color = Color.Green };
                if (toShow is Star) drawObject.color = Color.Red;

                var locationAsVector = new vector(body.Location);
                var relativeposition = locationAsVector - centerAsVector;
                var pixelVector = relativeposition / distancePerPixel;

                drawObject.location = new Point((int)pixelVector.XOffset + centerX, (int)pixelVector.YOffset + centerY);

                newToDraw.Add(drawObject);
            }

            lock (toDraw)
            {
                toDraw = newToDraw;
            }

            this.Invalidate();
        }

        private void DisplayForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.DrawImage(drawBuffer.Current, 0, 0);
            drawBuffer.Flip();

            CreateNextFrame();
        }

        private void CreateNextFrame()
        { 
            using (Graphics g = Graphics.FromImage(drawBuffer.Current))
            {
                g.Clear(Color.Black);

                lock (toDraw)
                {
                    foreach (var drawObject in toDraw)
                    {
                        g.DrawEllipse(
                            new Pen(drawObject.color),
                            drawObject.location.X - 3,
                            drawObject.location.Y - 3,
                            7,
                            7);

                        g.DrawString(
                            drawObject.name,
                            new Font(FontFamily.GenericMonospace, 12),
                            new SolidBrush(drawObject.color),
                            drawObject.location.X + 6,
                            drawObject.location.Y);
                    }

                    Text = Time.Tick.ToString();
                }
            }
        }

        private void DisplayForm_Resize(object sender, EventArgs e)
        {
            drawBuffer = new DrawBuffer(ClientRectangle, 2);
        }
    }
}
