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
    public partial class ucPlayerInformationPage : UserControl
    {
        public MainPresenter Pressenter { get; set; }

        public ucPlayerInformationPage()
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
        private void btnOriginalVideo_Click(object sender, EventArgs e)
        {

        }

        private void btnPreProcessingVideo_Click(object sender, EventArgs e)
        {

        }

        private void btnAfterProcessingVideo_Click(object sender, EventArgs e)
        {

        }

        private void btnResultVideo_Click(object sender, EventArgs e)
        {

        }
    }
}
