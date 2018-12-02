using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainProject.Presenters;

namespace MainProject.Views.SubViews
{
    public partial class ucSBDetectionPage : UserControl
    {
        public MainPresenter _pressenter = new MainPresenter();
        public MainPresenter Pressenter { get; set; }

        public ucSBDetectionPage()
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
        
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExtraction_Click(object sender, EventArgs e)
        {

        }

        private void btnRun_Click(object sender, EventArgs e)
        {

        }

        private void btnResult_Click(object sender, EventArgs e)
        {

        }

        private void btnSetupParameter_Click(object sender, EventArgs e)
        {

        }
    }
}
