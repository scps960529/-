using System;
using System.Windows.Forms;
using MainProject.Presenters;

namespace MainProject.Views.SubViews
{
    public partial class ucStartUpPage : UserControl
    {
        public MainPresenter Pressenter { get; set; }

        public ucStartUpPage()
        {
            InitializeComponent();
        }

        public void OnActive()
        {
            this.Visible = true;
        }

        public void OnDeactive()
        {
            this.Visible = false;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            Pressenter.SwitchPage(EPageID.About);
        }

        private void btnCatchVideo_Click(object sender, EventArgs e)
        {
            Pressenter.SwitchPage(EPageID.FirstSegmentation);
        }

    }
}
