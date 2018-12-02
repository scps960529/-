using System;
using System.Windows.Forms;
using MainProject.Presenters; //

namespace MainProject.Views.SubViews
{
    public partial class ucSBProcessPage : UserControl
    {
        public MainPresenter Pressenter { get; set; } 

        public ucSBProcessPage()
        {
            InitializeComponent();
        }
        public void OnActive()
        {
            this.Visible = true;
            /*this.btnExtraction.Enabled = false;
            this.btnRecognize.Enabled = false;*/

        }

        public void OnDeactive()
        {
            this.Visible = false;
        }


        private void btnDetection_Click(object sender, EventArgs e)
        {
            Pressenter.SwitchPage(EPageID.Detection);
            /*btnDetection.Enabled = false;
            btnExtraction.Enabled = true;
            btnRecognize.Enabled = false;*/
        }

        private void btnExtraction_Click(object sender, EventArgs e)
        {
            Pressenter.SwitchPage(EPageID.Extraction);
            //btnDetection.Enabled = false;
        }

        private void btnRecognize_Click(object sender, EventArgs e)
        {
            Pressenter.SwitchPage(EPageID.Recongize);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
