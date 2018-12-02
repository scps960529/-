using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace EmguCVFramework.CameraObject
{
    //Refernce web-site:
    // http://www.emgu.com/wiki/index.php/Camera_Capture
    // http://stackoverflow.com/questions/3046472/loading-a-video-file-using-emgucv-2-1-0-0
    // http://stackoverflow.com/questions/8472946/emgu-cv-get-all-frames-from-video-file
    /// <summary>
    /// 
    /// </summary>
    public class VideoController : IPlayer
    {
        private enum EStatus
        {
            Idle,
            Running,
            Pause,
        }
        private ManualResetEvent _stopEvent = new ManualResetEvent(false);
        private static VideoController _Singleton = new VideoController();
        public static VideoController Instance { get { return _Singleton; } }

        public string VideoPath { get; set; }

        private EStatus Status { get; set; }

        public int Width
        {
            get
            {
                if (_capture != null)
                    return (int)_capture.GetCaptureProperty(CapProp.FrameWidth);
                else
                    return 0;
            }
            set
            {
                if (_capture != null)
                    _capture.SetCaptureProperty(CapProp.FrameWidth, value);
            }
        }

        public int Height
        {
            get
            {
                if (_capture != null)
                    return (int)_capture.GetCaptureProperty(CapProp.FrameHeight);
                else
                    return 0;
            }
            set
            {
                if (_capture != null)
                    _capture.SetCaptureProperty(CapProp.FrameHeight, value);
            }
        }

        //Setup CurrentFrame
        public int NowFrame
        {
            get
            {
                if (_capture != null)
                    return (int)_capture.GetCaptureProperty(CapProp.PosFrames);
                else
                    return 0;
            }
            set
            {
                if (_capture != null)
                    _capture.SetCaptureProperty(CapProp.PosFrames, value);
            }
        }

        private Mat _mat;
        public Mat Mat
        {
            get
            {
                return _mat;
            }
        }
      
        private Graphics _graph;
        public Bitmap BGRImage
        {
            get;
            private set;
        }

        public IntPtr RawData
        {
            get
            {
                return _mat.DataPointer;
            }
        }

        public Size ImageSize
        {
            get
            {
                return _mat.Size;
            }
        }

        private Image<Bgr, Byte> OnReSizeColorImage(Mat mat)
        {
            var image_tmp = mat.ToImage<Bgr, Byte>();
            var image = image_tmp.Resize(1280, 720, Inter.Linear);
            image_tmp.Dispose();
            return image;
        }

        public Mat MatImage
        {
            get { return _capture.QueryFrame(); }
        }

        private bool _isRotateToVertical;
        public bool IsRotateToVertical
        {
            get { return _isRotateToVertical; }

            set { _isRotateToVertical = value; }
        }

        //The Video Total Frame
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
            get { return _fps; }

            set
            {
                _fps = value;
                _interval = 1200 / _fps;
            }
        }

        public event EventHandler Grabbed;
        public event EventHandler Finished;

        private bool _reentry = false;
        private object _rendoringLock = new object();

        #region Camera Capture Variables
        private Capture _capture = null; //Camera
        private int _interval = 0;
        #endregion

        private VideoController()
        { }
        
        private void SetupCapture()
        {
            //Dispose of Capture if it was created before
            if (_capture != null) _capture.Dispose();
            try
            {
                if (File.Exists(VideoPath) == false)
                    throw new FileNotFoundException();

                //Set up capture device
                _capture = new Capture(VideoPath);
                _capture.ImageGrabbed += ProcessFrame;

                FPS = (int)_capture.GetCaptureProperty(CapProp.Fps);
                _interval = 1500 / FPS;

                FrameCount = (int)_capture.GetCaptureProperty(CapProp.FrameCount); // get the video framecount //6                       
            }
            catch (NullReferenceException excpt)
            {
                System.Windows.Forms.MessageBox.Show(excpt.Message);
            }
            catch (FileNotFoundException excpt)
            {
                System.Windows.Forms.MessageBox.Show(excpt.Message);
            }
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            // too fast issue, need confirm
            //http://stackoverflow.com/questions/12437080/c-sharp-emgu-cv-recorded-videos-playsback-to-fast-slow
            if (_reentry == true)
                return;
            _reentry = true;

            _capture.ImageGrabbed -= ProcessFrame;
            try
            {
                if (_stopEvent.WaitOne(_interval) == false
                    && Status == EStatus.Running)
                {
                    lock (_rendoringLock)
                    {
                        if (_capture == null)
                        {
                            Status = EStatus.Idle;
                            return;
                        }

                        var oldMat = _mat;

                        var tmpMat = _capture.QueryFrame();
                        if (tmpMat == null)
                        {
                            Status = EStatus.Idle;
                            return;
                        }

                        if (IsRotateToVertical)
                        {
                            var tmpImage = tmpMat.ToImage<Bgr, Byte>();
                            _mat = tmpImage.Rotate(90, new Bgr(0, 0, 0), false).Mat;
                            tmpMat.Dispose();
                            tmpImage.Dispose();
                        }
                        else
                            _mat = tmpMat;

                        if (oldMat != null)
                            oldMat.Dispose();
                        if (BGRImage == null)
                        {
                            BGRImage = (Bitmap)_mat.Bitmap.Clone();
                            _graph = Graphics.FromImage(BGRImage);
                            _graph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        }
                        else
                        {
                            _graph.DrawImage(_mat.Bitmap, _graph.VisibleClipBounds);
                        }
                        if (Grabbed != null) Grabbed(this, arg);
                    }
                }
            }
            catch(Exception e)
            {
                throw;
            }
            finally
            {
                _reentry = false;

                if (Status == EStatus.Idle)
                {
                    if (_capture != null)
                    {
                        _capture.ImageGrabbed -= ProcessFrame;
                        _capture.Stop();
                        _capture = null;
                    }
                    BGRImage = null;
                    if (_graph != null)
                        _graph.Dispose();

                    if (Finished != null)
                        Finished(this, EventArgs.Empty);

                    else if (Finished == null) // Onfinish
                    {
                        MessageBox.Show("Video Prcoess is Finish", "影片處理結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (_capture != null && Status == EStatus.Running)
                        _capture.ImageGrabbed += ProcessFrame;
                }
            }
        }

        public void Start()
        {
            if (Status == EStatus.Running) return;

            try
            {
                if (Status == EStatus.Pause
                    && _capture != null)
                {
                    //Pause
                    _capture.ImageGrabbed -= ProcessFrame;
                    _capture.ImageGrabbed += ProcessFrame;
                    return;
                }
                SetupCapture(); //Setup capture with the new device
            }
            finally
            {
                Status = EStatus.Running;
                _capture.Start(); //Start the capture
                _stopEvent.Reset();
            }
        }

        public void Stop()
        {
            if (Status == EStatus.Running)
            {
                _stopEvent.Set();
            }
            else if (Status == EStatus.Pause)
            {
                if (_capture != null)
                {
                    _capture.Stop();
                    _capture = null;
                }
                BGRImage = null;
                _graph.Dispose();

                if (Finished != null)
                    Finished(this, EventArgs.Empty);
            }

            Status = EStatus.Idle;
        }

        public void Pause()
        {
            if (Status == EStatus.Running)
            {
                _stopEvent.Set();
                _capture.Pause(); //Pause the capture
                Status = EStatus.Pause;
            }
        }
    }
}
