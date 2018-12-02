using System;
using System.Windows.Forms;
using MainProject.Events;
using MainProject.Presenters;
using MainProject.Views.SubViews;

namespace MainProject
{
    public partial class MainContainer : Form
    {
        private MainPresenter           _presenter;
        private ucStartUpPage           _startupPage;
        private ucFirstSegmentationPage _firstsegmentationPage;
        private ucDisplayPage           _displayPage;
        private ucAboutPage             _aboutPage;

        private EPageID                 _currectPageID;

        public MainContainer()
        {
            InitializeComponent();

            _presenter = new MainPresenter();

            _startupPage = new ucStartUpPage
            {
                Dock = DockStyle.Fill,
                Parent = panelCentext,
                Visible = true,
                Pressenter = _presenter,
            };

            _firstsegmentationPage = new ucFirstSegmentationPage
            {
                Dock = DockStyle.Fill,
                Parent = panelCentext,
                Visible = true,
                Pressenter_1 = _presenter,
            };

            _displayPage = new ucDisplayPage
            {
                Dock = DockStyle.Fill,
                Parent = panelCentext,
                Visible = false,
                Pressenter = _presenter,
            };

            _aboutPage = new ucAboutPage
            {
                Dock = DockStyle.Fill,
                Parent = panelCentext,
                Visible = false,
                Pressenter = _presenter,
            };
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainContainer_Load(object sender, EventArgs e)
        {
            _presenter.SwitchViewEventHandler += OnSwitchView;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            switch (_currectPageID)
            {
                case EPageID.FirstSegmentation:
                case EPageID.About:
                //case EPageID.Display:
                    _presenter.SwitchPage(EPageID.Startup);
                    break;
                case EPageID.Display:
                    _presenter.SwitchPage(EPageID.FirstSegmentation);
                    break;
                default:
                    break;
            }
        }

        private void OnSwitchView(object sender, PageIDEventArgs e)
        {
            _startupPage.OnDeactive();
            _firstsegmentationPage.OnDeactive();
            _displayPage.OnDeactive();
            _aboutPage.OnDeactive();

            btnBack.Enabled = true;
            switch (e.Value)
            {
                case EPageID.Startup:
                    _startupPage.OnActive();
                    _currectPageID = EPageID.Startup;
                    btnBack.Enabled = false;
                    break;
                case EPageID.About:
                    _aboutPage.OnActive();
                    _currectPageID = EPageID.About;
                    break;
                case EPageID.FirstSegmentation:
                    _firstsegmentationPage.OnActive();
                    _currectPageID = EPageID.FirstSegmentation;
                    break;
                case EPageID.Display:
                    _displayPage.OnActive();
                    _currectPageID = EPageID.Display;
                    break;
                default:
                    break;
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
