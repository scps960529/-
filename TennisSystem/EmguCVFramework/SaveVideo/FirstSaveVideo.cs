using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Drawing;
using EmguCVFramework.CameraObject;
using EmguCVFramework.ScoreboardDetection;
using System;

namespace EmguCVFramework.SaveVideo
{
    public class FirstSaveVideo
    {
        public FirstSaveVideo()
        { }

        private VideoController _VideoController;

        private ScoreboardDetectorTest _ScoreboardDetectorTest;

        private string SaveName = null;

        private int Fps { get { return _VideoController.FPS; } }

        private int Height { get { return _VideoController.Height; } }

        private int Width { get { return _VideoController.Width; } }

        private Size size;

        private Capture _capture;

        private VideoWriter videoWrite;

        private Mat saveImage;

        public event EventHandler OnSave;

        public void SaveVideo(Image<Bgr,byte> frame,bool scoreboard)
        {
            var path = Environment.CurrentDirectory + @"\ProcessVideo.mp4";
            size = new Size(1280, 720);
            //SaveName = "";
            saveImage = frame.Mat;
            videoWrite = new VideoWriter(path,VideoWriter.Fourcc('M', 'P', '4', '2'), 30, size, true);
            if (scoreboard == true)
            {
                try
                {

                    //int c = CvInvoke.WaitKey(20);
                    videoWrite.Write(saveImage);

                }
                catch (Exception e)
                {
                    throw;
                }
            }
            /*if (scoreboard == true)
            {
                //OnSave += new EventHandler(Process);
                saveImage.Save(path);
            }*/
                     
        }

        private void Process(object sender, EventArgs e)
        {
            var path = Environment.CurrentDirectory + @"\ProcessVideo.mp4";
            size = new Size(1280, 720);
            SaveName = "";
            var sav = saveImage;
            videoWrite = new VideoWriter(path, VideoWriter.Fourcc('M', 'P', '4', '2'), 30, size, true);
           

                //int c = CvInvoke.WaitKey(20);
                videoWrite.Write(sav);

            
        }
    }
}
