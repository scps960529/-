using System.Drawing;
using EmguCVFramework.CameraObject;
using System;

namespace MainProject.Models
{
    internal class VideoDisplayModel
    {
        public IPlayer Controller { get; set; }

        public Bitmap DisplayImage { get { return Controller.BGRImage; } }

        public Rectangle ROI { get; private set; }

        public Rectangle FNameROI { get; private set; }

        public Rectangle SNameROI { get; private set; }

        public Bitmap DrawImage { get; private set; }

        public int TotalCount { get { return Controller.FrameCount; } }

        public int NowFrame { get { return Controller.NowFrame; } set { Controller.NowFrame = value; } }

        public event EventHandler ImageDrawed;

        public VideoDisplayModel()
        {}

        public void Start()
        {
            if (Controller != null)
            {
                Controller.Start();
            }
        }

        public void Stop()
        {
            if (Controller != null)
            {
                Controller.Stop();
            }
        }

        public void Pause()
        {
            if (Controller != null)
            {
                Controller.Pause();
            }
        }

        public void DrawRectangle(Rectangle rect)
        {
            ROI = rect;
            DrawImage = (Bitmap)DisplayImage.Clone();
            var graph = Graphics.FromImage(DrawImage);
            graph.DrawRectangle(new Pen(Brushes.Red, 5), ROI);

            if (ImageDrawed != null)
                ImageDrawed(this, EventArgs.Empty);
        }

        public void FirstNameOCR(Rectangle firstName)
        {
            FNameROI = firstName;
            DrawImage = (Bitmap)DisplayImage.Clone();
            var graph = Graphics.FromImage(DrawImage);
        }

        public void SecondNameOCR(Rectangle secondName)
        {
            SNameROI = secondName;
            DrawImage = (Bitmap)DisplayImage.Clone();
            var graph = Graphics.FromImage(DrawImage);
        }
    }
}
