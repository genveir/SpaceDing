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
        private Bitmap bmpBackground;

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
        private FormView handler;
        private LocationTranslator translator;

        public DisplayForm(FormView handler)
        {
            InitializeComponent();

            DoubleBuffered = true;

            toDraw = new List<DrawObject>();
            this.handler = handler;
        }

        private void DisplayForm_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0) handler.AlterZoom(true, translator.ToFixedLocation(e.Location));
            else handler.AlterZoom(false, translator.ToFixedLocation(e.Location));
        }

        private void DisplayForm_Load(object sender, EventArgs e)
        {
            bmpBackground = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
        }

        public void Display(IEnumerable<IBody> toShow, ILocation center, double distancePerPixel)
        {
            var newToDraw = new DrawObject[toShow.Count()];
            var toShowArray = toShow.ToArray();

            translator = new LocationTranslator(center, ClientRectangle, distancePerPixel);

            Parallel.For(0, newToDraw.Length, n =>
            {
                var body = toShowArray[n];

                var drawObject = new DrawObject() { name = body.Name, color = Color.Green };
                if (body is Star) drawObject.color = Color.Red;
                if (body is Asteroid) drawObject.color = Color.Blue;

                if (body.Mass < 5000000) drawObject.name = null;

                drawObject.location = translator.ToPoint(body.Location);
                drawObject.size = (int)Math.Log10(Math.Pow(body.Mass, 1.0d / 3.0d));

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

            g.DrawImage(bmpBackground, 0, 0);
        }

        private void CreateFrame()
        {
            using (Graphics g = Graphics.FromImage(bmpBackground))
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

                        if (drawObject.name != null)
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
            if (ClientRectangle.Width == 0 || ClientRectangle.Height == 0) return;

            bmpBackground = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);

            handler.Redraw();
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
