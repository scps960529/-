using System;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;
using EmguCVFramework.ScoreboardDetection;
using System.Collections.Generic;

namespace EmguCVFramework.CameraObject
{
    public class ScoreboardDetectorController_Test : IPlayer
    {
        private ScoreboardDetectorTest _scoreboardDetector = new ScoreboardDetectorTest();

        private ScoreboardDetectorTest_2 _scoreboardDetector_2 = new ScoreboardDetectorTest_2();

        private static ScoreboardDetectorController_Test _singleton = new ScoreboardDetectorController_Test();

        public static ScoreboardDetectorController_Test Instance { get { return _singleton; } }

        private IPlayer _source;

        public IPlayer Source
        {
            get { return _source; }
            set
            {
                if (_source != null)
                    _source.Grabbed -= ProcessFrame;
                else
                {
                    _source = value;
                    _source.Grabbed -= ProcessFrame;
                    _source.Grabbed += ProcessFrame;
                }
            }
        }

        public string SaveVideoPath { get; set; }

        public ScoreboardDetectorController_Test()  
        { }

        public void videowriter_test(string name)
        {
            var path = name;
            Size size = new Size(1280, 720);
            int fps = 14;
            videoWriter = new VideoWriter(path, VideoWriter.Fourcc('M', 'P', '4', 'V'), fps, size, true);
        }

        public Mat Mat { get { return _scoreboardDetector.Mat; } }

        public Mat Mat_2 { get { return _scoreboardDetector_2.Mat; } }

        public Bitmap BGRImage { get; private set; }

        public VideoWriter videoWriter;

        public int NowFrame { get; set; }

        private int _frameCount = 0;
        public int FrameCount
        {
            get
            {
                return _frameCount;
            }

            set
            {
                _frameCount = value;
            }
        }

        private int _fps = 0;
        public int FPS
        {
            get
            {
                return _fps;
            }

            set
            {
                _fps = value;
            }
        }

        private bool _isScoreboard = false;
        public bool IsScoreboard
        {
            get
            {
                return _isScoreboard;
            }

            set
            {
                _isScoreboard = value;
            }
        }

        private bool _isScoreboard_2 = false;
        public bool IsScoreboard_2
        {
            get
            {
                return _isScoreboard_2;
            }

            set
            {
                _isScoreboard_2 = value;
            }
        }

        private int _iscount;
        public int Iscount
        {
            get
            {
                return _iscount;
            }

            set
            {
                _iscount = value;
            }
        }

        public Bitmap PImage
        {
            get { return _scoreboardDetector.PImage; }
            set { _scoreboardDetector.PImage = value; }
        } 

        public Point PatternLocation
        {
            get { return _scoreboardDetector.PatternLocation; }
            set { _scoreboardDetector.PatternLocation = value; }
        }

        public Size PatternSize
        {
            get { return _scoreboardDetector.PatternSize; }
            set { _scoreboardDetector.PatternSize = value; }
        }

        public int Threshold
        {
            get { return _scoreboardDetector.Threshold; }
            set { _scoreboardDetector.Threshold = value; }
        }

        public Bitmap CourtColorImage
        {
            get { return _scoreboardDetector_2.CourtColorImage; }
            set { _scoreboardDetector_2.CourtColorImage = value; }
        }

        public Point CourtLocation
        {
            get { return _scoreboardDetector_2.CourtLocation; }
            set { _scoreboardDetector_2.CourtLocation = value; }
        }

        public Size CourtSize
        {
            get { return _scoreboardDetector_2.CourtSize; }
            set { _scoreboardDetector_2.CourtSize = value; }
        }

        public int Threshold_2
        {
            get { return _scoreboardDetector_2.Threshold; }
            set { _scoreboardDetector_2.Threshold = value; }
        }

        public event EventHandler Grabbed;
        public event EventHandler Finished;

        private void ProcessFrame(object sender, EventArgs e)
        {
            var processImage = _source.Mat.Clone();

            try
            {            
                _scoreboardDetector.Program(processImage.ToImage<Bgr, byte>());
                _scoreboardDetector_2.Program(processImage.ToImage<Bgr, byte>());

                if (IsScoreboard == true && IsScoreboard_2 == true && videoWriter.Ptr != IntPtr.Zero)
                {
                    videoWriter.Write(processImage);
                }

                if (_scoreboardDetector.PImage == null)
                {
                    Stop();
                    if (Finished != null)
                        Finished(this, EventArgs.Empty);
                }
            }

            catch
            {
                throw;
            }

            IsScoreboard = _scoreboardDetector.Result;
            IsScoreboard_2 = _scoreboardDetector_2.Result;
            Iscount = _scoreboardDetector_2.Iscount;

            if (Grabbed != null)
                Grabbed(this, e);
        }

        public void Start()
        {
            if (Source != null)
            {
                _source.Grabbed -= ProcessFrame;
                _source.Grabbed += ProcessFrame;
                Source.Start();
            }
        }

        public void Stop()
        {
            if (Source != null)
            {
                _source.Grabbed -= ProcessFrame;
            }
        }

        public void Pause()
        {
            if (Source != null)
                Source.Pause();
        }
    }
}
