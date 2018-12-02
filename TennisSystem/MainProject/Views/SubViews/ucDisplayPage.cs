using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainProject.PlayerData;
using MainProject.Presenters;

namespace MainProject.Views.SubViews
{
    public partial class ucDisplayPage : UserControl
    {
        public frmPlayerWindow _frmPlayer;

        public MainPresenter _pressenter = new MainPresenter();
        public MainPresenter Pressenter { get; set; }

        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public ucDisplayPage()
        {
            InitializeComponent();

            Pressenter = new MainPresenter(EVideoType.Original);
            _frmPlayer = new frmPlayerWindow(Pressenter)
            {
                StartPosition = FormStartPosition.CenterScreen,
            };

            Pressenter.VideoDisplayModel.ImageDrawed += OnImageDrawed; //Draw ROI

            
        }

        private void OnImageDrawed(object sender, EventArgs e) //Draw ROI
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
                //StreamWriter sw = null;
                try
                {
                    if (picBoxDisplayImage.Image == null)
                        picBoxDisplayImage.Image = img;
                    else
                        picBoxDisplayImage.Invalidate();

                    if (Pressenter.CurrentVideoType == EVideoType.BoardDetect_2) //Detect the video 
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
                    /*if (sw != null)
                        sw.Close();*/
                }
            }));
        }

        public void OnDeactive()
        {
            this.Visible = false;
        }

        private void btnPlayerData_Click(object sender, EventArgs e)
        {
            _frmPlayer.Show();
            FirstName = Program.PlayerFirstName;
            SecondName = Program.PlayerSecondName;
            _frmPlayer.DataBase(FirstName, SecondName);
        }

        private void btnLoadVideo_Click(object sender, EventArgs e)
        {
            Pressenter.LoadVideo();
            picBoxDisplayImage.SizeMode = PictureBoxSizeMode.StretchImage;
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
    }
}
