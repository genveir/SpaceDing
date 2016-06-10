using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.View
{
    class DrawBuffer
    {
        private Bitmap[] drawBuffer;
        private int currentBuffer = 0;

        public DrawBuffer(Rectangle drawingSize, int numBuffers)
        {
            drawBuffer = new Bitmap[numBuffers];

            for (int n = 0; n < drawBuffer.Length; n++)
            {
                drawBuffer[n] = new Bitmap(drawingSize.Width, drawingSize.Height);
            }
        }

        public Bitmap Current
        {
            get
            {
                return drawBuffer[currentBuffer];
            }
        }

        public void Flip()
        {
            currentBuffer++;
            currentBuffer = currentBuffer % drawBuffer.Length;
        }
    }
}
