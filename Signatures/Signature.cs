using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.IO;
namespace zsi.Controls
{
    public class Signature : Control
    {
        public event EventHandler SignatureUpdate;

        public Signature() { }
        public string Background { get; set; }
        public Bitmap bmp { get; set; }
        Graphics graphics;
        Pen pen = new Pen(Color.Black);
        // list of line segments
        ArrayList pVector = new ArrayList();
        Point lastPoint = new Point(0, 0);
        // if drawing signature or not
        bool drawSign = false;
        protected override void OnPaint(PaintEventArgs e)
        {
            // we draw on the memory bitmap on mousemove so there
            // is nothing else to draw at this time 
            CreateGdiObjects();
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // don't pass to base since we paint everything, avoid flashing
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            // process if currently drawing signature
            if (!drawSign)
            {
                // start collecting points
                drawSign = true;

                // use current mouse click as the first point
                lastPoint.X = e.X;
                lastPoint.Y = e.Y;


            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {

            base.OnMouseUp(e);
            // process if drawing signature
            if (drawSign)
            {
                // stop collecting points
                drawSign = false;
            }

        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            // process if drawing signature
            if (drawSign)
            {

                if (graphics == null) InitMemoryBitmap();
                // draw the new segment on the memory bitmap
                graphics.DrawLine(pen, lastPoint.X, lastPoint.Y, e.X, e.Y);
                pVector.Add(lastPoint.X + " " + lastPoint.Y + " " + e.X + " " + e.Y);
                // update the current position 
                lastPoint.X = e.X;
                lastPoint.Y = e.Y;
                // display the updated bitmap
                Invalidate();
            }
        }

        /// <summary>
        /// Clear the signature.
        /// </summary>
        public void Clear()
        {
            pVector.Clear();
            InitMemoryBitmap();
            Invalidate();
        }

        /// <summary>
        /// Create any GDI objects required to draw signature.
        /// </summary>
        private void CreateGdiObjects()
        {
            // only create if don't have one or the size changed
            if (bmp == null || bmp.Width != this.Width || bmp.Height != this.Height)
            {
                // memory bitmap to draw on
                InitMemoryBitmap();
            }
        }

        /// <summary>
        /// Create a memory bitmap that is used to draw the signature.
        /// </summary>
        private void InitMemoryBitmap()
        {
            // load the background image
            if (this.Background == null)
            {
                bmp = new Bitmap(this.Width, this.Height);
                graphics = Graphics.FromImage(bmp);
                graphics.Clear(Color.White);
            }
            else
            {
                bmp = new Bitmap(this.Background);
                // get graphics object now to make drawing during mousemove faster
                graphics = Graphics.FromImage(bmp);
            }
        }

        /// <summary>
        /// Notify container that a line segment has been added.
        /// </summary>
        private void RaiseSignatureUpdateEvent()
        {
            if (this.SignatureUpdate != null)
                SignatureUpdate(this, EventArgs.Empty);
        }



        public void Save(String fileName)
        {
            if (File.Exists(fileName))
            {
                Console.WriteLine("{0} already exists.", fileName);
                //return;
            }
            bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
        }


    }
}
