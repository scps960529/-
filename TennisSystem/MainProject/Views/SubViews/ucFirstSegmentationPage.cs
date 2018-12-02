using System;
using System.IO;
using System.Windows.Forms;
using MainProject.FirstSegmentation;
using MainProject.Presenters;
using EmguCVFramework.CameraObject;

namespace MainProject.Views.SubViews
{
    public partial class ucFirstSegmentationPage : UserControl
    {
        public frmSetWindow _frmSet;

        public MainPresenter Pressenter { get; set; }
        public MainPresenter Pressenter_1 { get; set; }

        private int _count;

        public string FirstPlayer { get { return _frmSet.playerFirst; } set { _frmSet.playerFirst = value; } }
        public string SecondPlayer { get { return _frmSet.playerSecond; } set { _frmSet.playerSecond = value; } }

        public ucFirstSegmentationPage()
        {
            InitializeComponent();

            Pressenter = new MainPresenter(EVideoType.Original);

            _frmSet = new frmSetWindow(Pressenter)
            {
                StartPosition = FormStartPosition.CenterScreen,
            };

            //lbCurrentValue.Text = "0";

            Pressenter.VideoDisplayModel.ImageDrawed += OnImageDrawed;

            btnLoadVideo.Enabled = true;
            btnSetup.Enabled = true;
            btnProcess.Enabled = true;
            btnDisplay.Enabled = true;

            btnStart.Enabled = true;
            btnStop.Enabled = true;
            btnPause.Enabled = true;
        }

        private void OnImageDrawed(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                try
                {
                    picBoxDisplayImage.Image = Pressenter.VideoDisplayModel.DrawImage;
                    //hasDraw = true;
                }
                catch (Exception)
                {
                    throw;
                }
            }));
        }

        public void OnActive()
        {
            this.Visible = true;

            Pressenter.ImageUpdateEventHandler += OnImageUpdate;
            Pressenter.ImageChanged += OnImageChanged;
        }

        private void OnImageChanged(object sender, EventArgs e)
        {
            picBoxDisplayImage.Image = null;
        }

        private void OnImageUpdate(object sender, EventArgs e)
        {
            var img = Pressenter.VideoDisplayModel.DisplayImage;
            this.BeginInvoke(new Action(() =>
            {
                StreamWriter sw = null;
                try
                {
                    if (picBoxDisplayImage.Image == null)
                        picBoxDisplayImage.Image = img;
                    else
                        picBoxDisplayImage.Invalidate();

                    if (Pressenter.CurrentVideoType == EVideoType.BoardDetect)
                    {
                        /*var path = Environment.CurrentDirectory + @"\FirstSegmentationRawData.txt";
                        if (File.Exists(path) == false)
                        {
                            var f = File.Create(path);
                            f.Close();
                        }
                   
                        sw = new StreamWriter(path, true, System.Text.Encoding.ASCII);
                        sw.WriteLine(string.Format("Frame No.: {0},\tResult: {1}", _count, Pressenter.Iscount));
                        _count++;*/
                    }
                                       
                    VideoTrackBar.Maximum = Pressenter.VideoDisplayModel.TotalCount;
                    var nowframe = Pressenter.VideoDisplayModel.NowFrame;
                    //lbCurrentValue.Text = nowframe.ToString();
                    VideoTrackBar.Value = nowframe;                 
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (sw != null)
                    sw.Close();
                }
            }));
        }

        public void OnDeactive()
        {
            this.Visible = false;
        }

        private void btnLoadVideo_Click(object sender, EventArgs e)
        {
            Pressenter.LoadVideo();
            picBoxDisplayImage.SizeMode = PictureBoxSizeMode.StretchImage;

            btnSetup.Enabled = true;
            btnStart.Enabled = true;
            btnStop.Enabled = true;
            btnPause.Enabled = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Pressenter.StartVideo();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            Pressenter.PauseVideo();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Pressenter.StopVideo();
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            _frmSet.Show();

            btnProcess.Enabled = true;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            //_count = 0;
            Pressenter.FirstSegmentation(); 
            Pressenter.StartVideo();

            btnDisplay.Enabled = true;
        }

        private void VideoTrackBar_Scroll(object sender, EventArgs e)
        {
            Pressenter.VideoDisplayModel.NowFrame = VideoTrackBar.Value;
            //lbCurrentValue.Text = VideoTrackBar.Value.ToString();
        }

        private void VideoTrackBar_MouseDown(object sender, MouseEventArgs e)
        {
            Pressenter.PauseVideo();
        }

        private void VideoTrackBar_MouseUp(object sender, MouseEventArgs e)
        {
            Pressenter.VideoDisplayModel.NowFrame = VideoTrackBar.Value;
            //lbCurrentValue.Text = VideoTrackBar.Value.ToString();
            Pressenter.StartVideo();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            Pressenter_1.SwitchPage(EPageID.Display);
            Program.PlayerFirstName = FirstPlayer;
            Program.PlayerSecondName = SecondPlayer;
        }
    }
}
