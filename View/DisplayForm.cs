using Space_Game.BasicModel;
using Space_Game.BasicModel.DefaultBodies;
using Space_Game.Geometry;
using Space_Game.Simulation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Game.View
{
    public partial class DisplayForm : Form
    {
        private class DrawObject
        {
            public Point location;
            public Color color;
            public string name;
            public int size;
            private int _halfsize;
            public int halfsize
            {
                get
                {
                    if (_halfsize == 0)
                    {
                        _halfsize = size / 2;
                        if (_halfsize < 1) _halfsize = 1;
                    }
                    return _halfsize;
                }
            }
        }

        private object lockObject = new object();
        private IEnumerable<DrawObject> toDraw;
        private DrawBuffer drawBuffer;
        private FormView handler;

        public DisplayForm(FormView handler)
        {
            InitializeComponent();

            DoubleBuffered = true;

            toDraw = new List<DrawObject>();
            this.handler = handler;
        }

        private void DisplayForm_Load(object sender, EventArgs e)
        {
            drawBuffer = new DrawBuffer(ClientRectangle, 2);
        }

        public void Display(IEnumerable<IBody> toShow, ILocation center, double distancePerPixel)
        {
            var newToDraw = new DrawObject[toShow.Count()];
            var toShowArray = toShow.ToArray();

            var centerAsVector = new vector(center);

            var centerX = ClientRectangle.Width / 2;
            var centerY = ClientRectangle.Height / 2;

            Parallel.For(0, newToDraw.Length, n =>
            {
                var body = toShowArray[n];

                var drawObject = new DrawObject() { name = body.Name, color = Color.Green };
                if (body is Star) drawObject.color = Color.Red;
                if (body.Mass < 5000) drawObject.name = "";

                var locationAsVector = new vector(body.Location);
                var relativeposition = locationAsVector - centerAsVector;
                var pixelVector = relativeposition / distancePerPixel;

                drawObject.location = new Point((int)pixelVector.XOffset + centerX, (int)pixelVector.YOffset + centerY);
                drawObject.size = (int)Math.Sqrt(body.Mass) / 1000;

                if (drawObject.size < 1) drawObject.size = 1;

                newToDraw[n] = drawObject;
            });

            lock (lockObject)
            {
                toDraw = newToDraw;
            }

            this.Invalidate();
        }

        private void DisplayForm_Paint(object sender, PaintEventArgs e)
        {
            CreateFrame();

            Graphics g = e.Graphics;

            g.DrawImage(drawBuffer.Current, 0, 0);
            drawBuffer.Flip();
        }

        private void CreateFrame()
        { 
            using (Graphics g = Graphics.FromImage(drawBuffer.Current))
            {
                g.Clear(Color.Black);

                lock (lockObject)
                {
                    foreach (var drawObject in toDraw)
                    {
                        g.DrawEllipse(
                            new Pen(drawObject.color),
                            drawObject.location.X - drawObject.halfsize,
                            drawObject.location.Y - drawObject.halfsize,
                            drawObject.size,
                            drawObject.size);

                        g.DrawString(
                            drawObject.name,
                            new Font(FontFamily.GenericMonospace, 12),
                            new SolidBrush(drawObject.color),
                            drawObject.location.X + drawObject.halfsize + 3,
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

        private void DisplayForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                handler.Update();
            } 
        }
    }
}
