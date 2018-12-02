using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using EmguCVFramework.CameraObject;
using FileIOFramework.Video;
using FileIOFramework.Pattern;
using MainProject.Events;
using MainProject.Models;
using MainProject.Views.SubViews;

namespace MainProject.Presenters
{
    public class MainPresenter
    {
        private VideoController _orgVideoController;
        private ScoreboardDetectorController_Test _sdController;
        internal VideoDisplayModel VideoDisplayModel { get; private set; }
        private VideoFileHelper _fileHelper;
        private string _videoPath = "";
        
        public event EventHandler<PageIDEventArgs> SwitchViewEventHandler;
        public event EventHandler ImageUpdateEventHandler;
        public event EventHandler ImageChanged;

        public EVideoType CurrentVideoType { get; private set; }

        public bool IsScoreboard { get; private set; }

        public bool IsScoreboard_2 { get; private set; }

        public int Iscount { get; private set; }

        public MainPresenter(EVideoType type = EVideoType.Original)
        {
            VideoDisplayModel = new VideoDisplayModel();
            _orgVideoController = VideoController.Instance;
            _sdController = ScoreboardDetectorController_Test.Instance;
            _sdController.Source = _orgVideoController;
            _sdController.Finished += OnSDC_FinishedEventHandler;

            _fileHelper = new VideoFileHelper();

            SwitchVideo(type);
        }

        public void SetupFirstSegmentation(Rectangle roi, Rectangle roi_2, int threshold, Bitmap patternImage, Bitmap courtcolorImage) 
        {
            _sdController.PImage = patternImage;
            _sdController.PatternLocation = roi.Location;
            _sdController.PatternSize = roi.Size;
            _sdController.Threshold = threshold;

            _sdController.CourtColorImage = courtcolorImage;
            _sdController.CourtLocation = roi_2.Location;
            _sdController.CourtSize = roi_2.Size;
            _sdController.Threshold_2 = threshold;
        }

        private void OnSDC_FinishedEventHandler(object sender, EventArgs e)
        {
            MessageBox.Show("Scoreboard Detect is finished!");
        }

        private void OnGrabbed(object sender, EventArgs e)
        {
            IsScoreboard = _sdController.IsScoreboard;
            IsScoreboard_2 = _sdController.IsScoreboard_2;
            Iscount = _sdController.Iscount;
            if (ImageUpdateEventHandler != null)
                ImageUpdateEventHandler(this, e);
        }

        public void SwitchPage(EPageID id)
        {
            if (SwitchViewEventHandler != null)
                SwitchViewEventHandler(this, new PageIDEventArgs(id));
        }

        public void LoadVideo(string path = "")
        {
            string name = "";
            if (path == "" && _videoPath == "")
                _videoPath = _fileHelper.GetVideoFilePath(out name);

            if (File.Exists(_videoPath) == false)
            {
                MessageBox.Show("No Found Video Path", "提醒", MessageBoxButtons.OK);
                return;
            }

            if (_orgVideoController != null)
            {
                _orgVideoController.VideoPath = _videoPath;

            }
        }

        public void ReloadVideo()
        {
            LoadVideo();
        }

        private SaveFileDialog sfd;
        private string path = "";
        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        public void SaveVideo()
        {
            sfd = new SaveFileDialog
            {
                InitialDirectory = "c:\\",
                Filter = "Video files(*.mp4) | *.mp4",
                RestoreDirectory = true,
            };
            
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                path = sfd.FileName;
                _sdController.videowriter_test(path);                
            }            
        }

        public void SwitchVideo(EVideoType type)
        {
            switch (type)
            {
                case EVideoType.BoardDetect:
                    _sdController.Stop();
                    _sdController.Grabbed -= OnGrabbed;
                    break;
                default:
                    //case EVideoType.Original:
                    _orgVideoController.Grabbed -= OnGrabbed;
                    break;
            }

            switch (type)
            {
                case EVideoType.BoardDetect:
                    _sdController.Grabbed -= OnGrabbed;
                    _sdController.Grabbed += OnGrabbed;
                    VideoDisplayModel.Controller = _sdController;
                    break;
                default:
                    //case EVideoType.Original:
                    _orgVideoController.Grabbed -= OnGrabbed;
                    _orgVideoController.Grabbed += OnGrabbed;
                    VideoDisplayModel.Controller = _orgVideoController;
                    break;
            }

            if (ImageChanged != null)
                ImageChanged(this, EventArgs.Empty);
        }

        public void StartVideo()
        {
            VideoDisplayModel.Start();
        }

        public void StopVideo()
        {
            VideoDisplayModel.Stop();
        }

        public void PauseVideo()
        {
            VideoDisplayModel.Pause();
        }

        public void FirstSegmentation()
        {
            CurrentVideoType = EVideoType.BoardDetect; 
            SwitchVideo(EVideoType.BoardDetect);
            VideoDisplayModel.Start();      
        }
    }
}
