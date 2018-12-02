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
    public partial class ucAboutPage : UserControl
    {
        public MainPresenter _pressenter = new MainPresenter();
        public MainPresenter Pressenter { get; set; }

        public ucAboutPage()
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
    }
}
