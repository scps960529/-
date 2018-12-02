using System;
using System.Windows.Forms;
using MainProject.Presenters;

namespace MainProject.Views.SubViews
{
    public partial class ucVideoProcessingPage : UserControl
    {
        public MainPresenter Pressenter { get; set; }

        public ucVideoProcessingPage()
        {
            InitializeComponent();
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
                try
                {
                    if (picBoxDisplayImage.Image == null)
                        picBoxDisplayImage.Image = img;
                    else
                        picBoxDisplayImage.Invalidate();
                }
                catch (Exception)
                {
                    throw;
                }
            }));
        }

        public void OnDeactive()
        {
            this.Visible = false;
        }

        private void btnFirstSegmenation_Click(object sender, EventArgs e)
        {
            Pressenter.SwitchPage(EPageID.Catch);
        }
        
        private void btnSBProcessing_Click(object sender, EventArgs e)
        {
            Pressenter.SwitchPage(EPageID.SBProcessing);
        }

        private void btnVideoSummary_Click(object sender, EventArgs e)
        {
            Pressenter.SwitchPage(EPageID.Result);
        }

        private void btnStartVideo_Click(object sender, EventArgs e)
        {
            Pressenter.StartVideo();
        }

        private void btnStopVideo_Click(object sender, EventArgs e)
        {
            Pressenter.StopVideo();
        }

        private void btnPauseVideo_Click(object sender, EventArgs e)
        {
            Pressenter.PauseVideo();
        }

        private void btnPlayerInformation_Click(object sender, EventArgs e)
        {
            Pressenter.SwitchPage(EPageID.PlayerInformation);
        }

        private void btnShowSegmenationWindow_Click(object sender, EventArgs e)
        {
            var form = new ScoreBoardSegmetationAP.Form1();
            form.Show();
        }

    }
}
