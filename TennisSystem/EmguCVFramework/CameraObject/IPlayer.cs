using System;
using System.Drawing;
using Emgu.CV;

namespace EmguCVFramework.CameraObject
{
    public interface IPlayer
    {
        event EventHandler Grabbed;
        event EventHandler Finished;

        Bitmap BGRImage { get; }

        Mat Mat { get; }

        int FPS { get; set; }

        int FrameCount { get; set; }

        int NowFrame { get; set; }

        void Start();

        void Stop();

        void Pause();
    }
}
