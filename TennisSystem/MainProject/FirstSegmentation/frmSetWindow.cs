using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MainProject.Presenters;
using FileIOFramework.Pattern;
using EmguCVFramework.CameraObject;
using RecognitionAlgorithmFramework.OCR;

namespace MainProject.FirstSegmentation
{
    public partial class frmSetWindow : Form
    {
        public MainPresenter _pressenter;

        public NameOCR _nameOCR = new NameOCR();

        private Bitmap CopyFrame = null;

        private Bitmap CourtColorImage = null;

        public string SavePath { get { return _pressenter.Path; } }

        public string playerFirst { get; set; }

        public string playerSecond { get; set; }

        public frmSetWindow(MainPresenter p)
        {
            InitializeComponent();

            _pressenter = p;

            ValueWTBar.Enabled = false;
            btnSaveFile.Enabled = false;
            btnReset.Enabled = false;
            btnApply.Enabled = false; 

            btnAO17MF.Enabled = true;
            btnAO17FF.Enabled = true;
            btnAO17FS.Enabled = true;
            btnAO16MF.Enabled = true;
            btnAO14MS.Enabled = true;
            btnWO17MF.Enabled = true;
            btnUO15MF.Enabled = true;
            btnUO13MF.Enabled = true;
            btnFO16MF.Enabled = true;
            btnFO13MF.Enabled = true;
        }

        #region >>> Rectangle Value <<<
        private int tempValueX = 0;
        private int tempValueY = 0;
        private int tempValueW = 0;
        private int tempValueH = 0;
        private int tempValueT = 25;
        private int courtValueX = 0;
        private int courtValueY = 0;
        private int courtValueW = 0;
        private int courtValueH = 0;
        #endregion

        public void DisableFunction()
        {
            btnApply.Enabled = false;
        }

        public void EnableFunction()
        {
            btnApply.Enabled = true;
        }

        private void frmSetAreaWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        #region >>> Scoreboard Location Value <<<
        private void btnAO17MF_Click(object sender, EventArgs e)
        {
            try
            {
                tempValueX = 82;
                tempValueY = 618;
                tempValueW = 158;
                tempValueH = 58;
                courtValueX = 159;
                courtValueY = 197;
                courtValueW = 958;
                courtValueH = 380;
                ValueWTBar.Value = tempValueW;
                CopyFrame = new Bitmap(_pressenter.VideoDisplayModel.DisplayImage);
                CourtColorImage = new Bitmap(Properties.Resources.AO17MF_CourtColorImage);
            }

            finally
            {
                var roi = new Rectangle(tempValueX, tempValueY, tempValueW, tempValueH);
                _pressenter.VideoDisplayModel.DrawRectangle(roi);

                var firstROI = new Rectangle(tempValueX + 38, tempValueY, tempValueW - 71, tempValueH / 2);
                _pressenter.VideoDisplayModel.FirstNameOCR(firstROI);

                var secondROI = new Rectangle(tempValueX + 38, tempValueY + (tempValueH / 2), tempValueW - 71, tempValueH / 2); 
                _pressenter.VideoDisplayModel.SecondNameOCR(secondROI);
            }

            OCRFunction();

            ValueWTBar.Enabled = true;
            btnSaveFile.Enabled = true;
            btnReset.Enabled = true;

            btnAO17FF.Enabled = false;
            btnAO17FS.Enabled = false;
            btnAO16MF.Enabled = false;
            btnAO14MS.Enabled = false;
            btnWO17MF.Enabled = false;
            btnUO15MF.Enabled = false;
            btnUO13MF.Enabled = false;
            btnFO16MF.Enabled = false;
            btnFO13MF.Enabled = false;
        }
     
        private void btnAO17FF_Click(object sender, EventArgs e)
        {
            try
            {
                tempValueX = 67;
                tempValueY = 631;
                tempValueW = 157;
                tempValueH = 50;
                courtValueX = 147;
                courtValueY = 200;
                courtValueW = 962;
                courtValueH = 380;
                ValueWTBar.Value = tempValueW;
                CopyFrame = new Bitmap(_pressenter.VideoDisplayModel.DisplayImage);
                CourtColorImage = new Bitmap(Properties.Resources.AO17FF_CourtColorImage);
            }

            finally
            {
                var roi = new Rectangle(tempValueX, tempValueY, tempValueW, tempValueH);
                _pressenter.VideoDisplayModel.DrawRectangle(roi);

                var firstROI = new Rectangle(tempValueX + 10, tempValueY, tempValueW - 48, tempValueH / 2);
                _pressenter.VideoDisplayModel.FirstNameOCR(firstROI);

                var secondROI = new Rectangle(tempValueX + 10, tempValueY + (tempValueH / 2), tempValueW - 48, tempValueH / 2);
                _pressenter.VideoDisplayModel.SecondNameOCR(secondROI);
            }

            OCRFunction();

            ValueWTBar.Enabled = true;
            btnSaveFile.Enabled = true;
            btnReset.Enabled = true;

            btnAO17MF.Enabled = false;
            btnAO17FS.Enabled = false;
            btnAO16MF.Enabled = false;
            btnAO14MS.Enabled = false;
            btnWO17MF.Enabled = false;
            btnUO15MF.Enabled = false;
            btnUO13MF.Enabled = false;
            btnFO16MF.Enabled = false;
            btnFO13MF.Enabled = false;
        }

        private void btnAO17FS_Click(object sender, EventArgs e)
        {
            try
            {
                tempValueX = 90;
                tempValueY = 583;
                tempValueW = 239;
                tempValueH = 61;
                courtValueX = 195;
                courtValueY = 204;
                courtValueW = 885;
                courtValueH = 350;
                ValueWTBar.Value = tempValueW;
                CopyFrame = new Bitmap(_pressenter.VideoDisplayModel.DisplayImage);
                CourtColorImage = new Bitmap(Properties.Resources.AO17FS_CourtColorImage);
            }

            finally
            {
                var roi = new Rectangle(tempValueX, tempValueY, tempValueW, tempValueH);
                _pressenter.VideoDisplayModel.DrawRectangle(roi);

                var firstROI = new Rectangle(tempValueX + 90, tempValueY, tempValueW - 102, tempValueH / 2);
                _pressenter.VideoDisplayModel.FirstNameOCR(firstROI);

                var secondROI = new Rectangle(tempValueX + 90, tempValueY + (tempValueH / 2), tempValueW - 102, tempValueH / 2);
                _pressenter.VideoDisplayModel.SecondNameOCR(secondROI);
            }

            OCRFunction();

            ValueWTBar.Enabled = true;
            btnSaveFile.Enabled = true;
            btnReset.Enabled = true;

            btnAO17MF.Enabled = false;
            btnAO17FF.Enabled = false;
            btnAO16MF.Enabled = false;
            btnAO14MS.Enabled = false;
            btnWO17MF.Enabled = false;
            btnUO15MF.Enabled = false;
            btnUO13MF.Enabled = false;
            btnFO16MF.Enabled = false;
            btnFO13MF.Enabled = false;
        }

        private void btnAO16MF_Click(object sender, EventArgs e)
        {
            try
            {
                tempValueX = 214;
                tempValueY = 619;
                tempValueW = 76;
                tempValueH = 57;
                courtValueX = 220;
                courtValueY = 194;
                courtValueW = 832;
                courtValueH = 333;
                ValueWTBar.Value = tempValueW;
                CopyFrame = new Bitmap(_pressenter.VideoDisplayModel.DisplayImage);
                CourtColorImage = new Bitmap(Properties.Resources.AO16MF_CourtColorImage);
            }

            finally
            {
                var roi = new Rectangle(tempValueX, tempValueY, tempValueW, tempValueH);
                _pressenter.VideoDisplayModel.DrawRectangle(roi);

                var firstROI = new Rectangle(tempValueX + 6, tempValueY, tempValueW - 29, tempValueH / 2);
                _pressenter.VideoDisplayModel.FirstNameOCR(firstROI);

                var secondROI = new Rectangle(tempValueX + 6, tempValueY + (tempValueH / 2), tempValueW - 29, tempValueH / 2);
                _pressenter.VideoDisplayModel.SecondNameOCR(secondROI);
            }

            OCRFunction();

            ValueWTBar.Enabled = true;
            btnSaveFile.Enabled = true;
            btnReset.Enabled = true;

            btnAO17MF.Enabled = false;
            btnAO17FF.Enabled = false;
            btnAO17FS.Enabled = false;
            btnAO14MS.Enabled = false;
            btnWO17MF.Enabled = false;
            btnUO15MF.Enabled = false;
            btnUO13MF.Enabled = false;
            btnFO16MF.Enabled = false;
            btnFO13MF.Enabled = false;
        }

        private void btnAO14MS_Click(object sender, EventArgs e)
        {
            try
            {
                tempValueX = 56;
                tempValueY = 36;
                tempValueW = 192;
                tempValueH = 44;
                courtValueX = 172;
                courtValueY = 215;
                courtValueW = 949;
                courtValueH = 373;
                ValueWTBar.Value = tempValueW;
                CopyFrame = new Bitmap(_pressenter.VideoDisplayModel.DisplayImage);
                CourtColorImage = new Bitmap(Properties.Resources.AO14MS_CourtColorImage);
            }

            finally
            {
                var roi = new Rectangle(tempValueX, tempValueY, tempValueW, tempValueH);
                _pressenter.VideoDisplayModel.DrawRectangle(roi);

                var firstROI = new Rectangle(tempValueX + 27, tempValueY, tempValueW - 124, tempValueH / 2);
                _pressenter.VideoDisplayModel.FirstNameOCR(firstROI);

                var secondROI = new Rectangle(tempValueX + 27, tempValueY + (tempValueH / 2), tempValueW - 108, tempValueH / 2);
                _pressenter.VideoDisplayModel.SecondNameOCR(secondROI);
            }

            OCRFunction();

            ValueWTBar.Enabled = true;
            btnSaveFile.Enabled = true;
            btnReset.Enabled = true;

            btnAO17MF.Enabled = false;
            btnAO17FF.Enabled = false;
            btnAO17FS.Enabled = false;
            btnAO16MF.Enabled = false;
            btnWO17MF.Enabled = false;
            btnUO15MF.Enabled = false;
            btnUO13MF.Enabled = false;
            btnFO16MF.Enabled = false;
            btnFO13MF.Enabled = false;
        }

        private void btnWO17MF_Click(object sender, EventArgs e)
        {
            try
            {
                tempValueX = 129;
                tempValueY = 40;
                tempValueW = 138;
                tempValueH = 54;
                courtValueX = 109;
                courtValueY = 245;
                courtValueW = 1080;
                courtValueH = 391;
                ValueWTBar.Value = tempValueW;
                CopyFrame = new Bitmap(_pressenter.VideoDisplayModel.DisplayImage);
                CourtColorImage = new Bitmap(Properties.Resources.WO17MF_CourtColorImage);
            }

            finally
            {
                var roi = new Rectangle(tempValueX, tempValueY, tempValueW, tempValueH);
                _pressenter.VideoDisplayModel.DrawRectangle(roi);

                var firstROI = new Rectangle(tempValueX + 6, tempValueY, tempValueW - 11, tempValueH / 2);
                _pressenter.VideoDisplayModel.FirstNameOCR(firstROI);

                var secondROI = new Rectangle(tempValueX + 6, tempValueY + (tempValueH / 2), tempValueW - 11, tempValueH / 2);
                _pressenter.VideoDisplayModel.SecondNameOCR(secondROI);
            }

            OCRFunction();

            ValueWTBar.Enabled = true;
            btnSaveFile.Enabled = true;
            btnReset.Enabled = true;

            btnAO17MF.Enabled = false;
            btnAO17FF.Enabled = false;
            btnAO17FS.Enabled = false;
            btnAO16MF.Enabled = false;
            btnAO14MS.Enabled = false;
            btnUO15MF.Enabled = false;
            btnUO13MF.Enabled = false;
            btnFO16MF.Enabled = false;
            btnFO13MF.Enabled = false;
        }

        private void btnUO15MF_Click(object sender, EventArgs e)
        {
            try
            {
                tempValueX = 65;
                tempValueY = 605;
                tempValueW = 177;
                tempValueH = 42;
                courtValueX = 194;
                courtValueY = 160;
                courtValueW = 890;
                courtValueH = 418;
                ValueWTBar.Value = tempValueW;
                CopyFrame = new Bitmap(_pressenter.VideoDisplayModel.DisplayImage);
                CourtColorImage = new Bitmap(Properties.Resources.UO15MF_CourtColorImage);
            }

            finally
            {
                var roi = new Rectangle(tempValueX, tempValueY, tempValueW, tempValueH);
                _pressenter.VideoDisplayModel.DrawRectangle(roi);

                var firstROI = new Rectangle(tempValueX + 23, tempValueY, tempValueW - 86, tempValueH / 2);
                _pressenter.VideoDisplayModel.FirstNameOCR(firstROI);

                var secondROI = new Rectangle(tempValueX + 23, tempValueY + (tempValueH / 2), tempValueW - 99, tempValueH / 2);
                _pressenter.VideoDisplayModel.SecondNameOCR(secondROI);
            }

            OCRFunction();

            ValueWTBar.Enabled = true;
            btnSaveFile.Enabled = true;
            btnReset.Enabled = true;

            btnAO17MF.Enabled = false;
            btnAO17FF.Enabled = false;
            btnAO17FS.Enabled = false;
            btnAO16MF.Enabled = false;
            btnAO14MS.Enabled = false;
            btnWO17MF.Enabled = false;
            btnUO13MF.Enabled = false;
            btnFO16MF.Enabled = false;
            btnFO13MF.Enabled = false;
        }

        private void btnUO13MF_Click(object sender, EventArgs e)
        {
            try
            {
                tempValueX = 246;
                tempValueY = 613;
                tempValueW = 134;
                tempValueH = 54;
                courtValueX = 258;
                courtValueY = 160;
                courtValueW = 765;
                courtValueH = 365;
                ValueWTBar.Value = tempValueW;
                CopyFrame = new Bitmap(_pressenter.VideoDisplayModel.DisplayImage);
                CourtColorImage = new Bitmap(Properties.Resources.UO13MF_CourtColorImage);
            }

            finally
            {
                var roi = new Rectangle(tempValueX, tempValueY, tempValueW, tempValueH);
                _pressenter.VideoDisplayModel.DrawRectangle(roi);

                var firstROI = new Rectangle(tempValueX + 12, tempValueY, tempValueW - 14, tempValueH / 2);
                _pressenter.VideoDisplayModel.FirstNameOCR(firstROI);

                var secondROI = new Rectangle(tempValueX + 12, tempValueY + (tempValueH / 2), tempValueW - 14, tempValueH / 2);
                _pressenter.VideoDisplayModel.SecondNameOCR(secondROI);
            }

            OCRFunction();

            ValueWTBar.Enabled = true;
            btnSaveFile.Enabled = true;
            btnReset.Enabled = true;

            btnAO17MF.Enabled = false;
            btnAO17FF.Enabled = false;
            btnAO17FS.Enabled = false;
            btnAO16MF.Enabled = false;
            btnAO14MS.Enabled = false;
            btnWO17MF.Enabled = false;
            btnUO15MF.Enabled = false;
            btnFO16MF.Enabled = false;
            btnFO13MF.Enabled = false;
        }

        private void btnFO16MF_Click(object sender, EventArgs e)
        {
            try
            {
                tempValueX = 66;
                tempValueY = 630;
                tempValueW = 169;
                tempValueH = 55;
                courtValueX = 220;
                courtValueY = 200;
                courtValueW = 772;
                courtValueH = 380;
                ValueWTBar.Value = tempValueW;
                CopyFrame = new Bitmap(_pressenter.VideoDisplayModel.DisplayImage);
                CourtColorImage = new Bitmap(Properties.Resources.FO16MF_CourtColorImage);
            }

            finally
            {
                var roi = new Rectangle(tempValueX, tempValueY, tempValueW, tempValueH);
                _pressenter.VideoDisplayModel.DrawRectangle(roi);

                var firstROI = new Rectangle(tempValueX + 67, tempValueY, tempValueW - 89, tempValueH / 2);
                _pressenter.VideoDisplayModel.FirstNameOCR(firstROI);

                var secondROI = new Rectangle(tempValueX + 67, tempValueY + (tempValueH / 2), tempValueW - 89, tempValueH / 2);
                _pressenter.VideoDisplayModel.SecondNameOCR(secondROI);
            }

            OCRFunction();

            ValueWTBar.Enabled = true;
            btnSaveFile.Enabled = true;
            btnReset.Enabled = true;

            btnAO17MF.Enabled = false;
            btnAO17FF.Enabled = false;
            btnAO17FS.Enabled = false;
            btnAO16MF.Enabled = false;
            btnAO14MS.Enabled = false;
            btnWO17MF.Enabled = false;
            btnUO15MF.Enabled = false;
            btnUO13MF.Enabled = false;
            btnFO13MF.Enabled = false;
        }

        private void btnFO13MF_Click(object sender, EventArgs e)
        {
            try
            {
                tempValueX = 64;
                tempValueY = 591;
                tempValueW = 72;
                tempValueH = 51;
                courtValueX = 170;
                courtValueY = 180;
                courtValueW = 941;
                courtValueH = 469;
                ValueWTBar.Value = tempValueW;
                CopyFrame = new Bitmap(_pressenter.VideoDisplayModel.DisplayImage);
                CourtColorImage = new Bitmap(Properties.Resources.FO13MF_CourtColorImage);
            }

            finally
            {
                var roi = new Rectangle(tempValueX, tempValueY, tempValueW, tempValueH);
                _pressenter.VideoDisplayModel.DrawRectangle(roi);

                var firstROI = new Rectangle(tempValueX + 12, tempValueY, tempValueW - 28, tempValueH / 2);
                _pressenter.VideoDisplayModel.FirstNameOCR(firstROI);

                var secondROI = new Rectangle(tempValueX + 12, tempValueY + (tempValueH / 2), tempValueW - 28, tempValueH / 2);
                _pressenter.VideoDisplayModel.SecondNameOCR(secondROI);
            }

            OCRFunction();

            ValueWTBar.Enabled = true;
            btnSaveFile.Enabled = true;
            btnReset.Enabled = true;

            btnAO17MF.Enabled = false;
            btnAO17FF.Enabled = false;
            btnAO17FS.Enabled = false;
            btnAO16MF.Enabled = false;
            btnAO14MS.Enabled = false;
            btnWO17MF.Enabled = false;
            btnUO15MF.Enabled = false;
            btnUO13MF.Enabled = false;
            btnFO16MF.Enabled = false;
        }       
        #endregion

        private void ValueWTBar_Scroll(object sender, EventArgs e)
        {
            tempValueW = ValueWTBar.Value;
            var roi = new Rectangle(tempValueX, tempValueY, tempValueW, tempValueH);
            _pressenter.VideoDisplayModel.DrawRectangle(roi);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {           
            var roi = new Rectangle(tempValueX, tempValueY, tempValueW, tempValueH);
            var roi_2 = new Rectangle(courtValueX, courtValueY, courtValueW, courtValueH);
            _pressenter.SetupFirstSegmentation(roi, roi_2, tempValueT, CopyFrame, CourtColorImage);

            _pressenter.StopVideo();
            _pressenter.ReloadVideo();

            if (playerFirst != null || playerSecond != null)
            {
                MessageBox.Show("球員一: " + playerFirst + "" + "球員二: " + playerSecond, "球員姓名辨識結果", MessageBoxButtons.OK);
            }

            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            CopyFrame = null;
            CourtColorImage = null;
            tempValueX = 0;
            tempValueY = 0;
            tempValueW = 0;
            tempValueH = 0;
            courtValueX = 0;
            courtValueY = 0;
            courtValueW = 0;
            courtValueH = 0;

            ValueWTBar.Value = tempValueW;

            var roi = new Rectangle(tempValueX, tempValueY, tempValueW, tempValueH);
            _pressenter.VideoDisplayModel.DrawRectangle(roi);

            ValueWTBar.Enabled = false;
            btnSaveFile.Enabled = false;
            btnReset.Enabled = false;
            btnApply.Enabled = false;

            btnAO17MF.Enabled = true;
            btnAO17FF.Enabled = true;
            btnAO17FS.Enabled = true;
            btnAO16MF.Enabled = true;
            btnAO14MS.Enabled = true;
            btnWO17MF.Enabled = true;
            btnUO15MF.Enabled = true;
            btnUO13MF.Enabled = true;
            btnFO16MF.Enabled = true;
            btnFO13MF.Enabled = true;
        }

        public void OCRFunction()
        {
            var first = new Bitmap(_pressenter.VideoDisplayModel.FNameROI.Width, _pressenter.VideoDisplayModel.FNameROI.Height);
            Graphics g = Graphics.FromImage(first);

            g.DrawImage(CopyFrame, 0, 0, _pressenter.VideoDisplayModel.FNameROI, GraphicsUnit.Pixel);

            if (first != null)
            {
                _nameOCR.PlayerName(first);
                playerFirst = _nameOCR.Name;
                playerFirst.Trim();
            }

            var second = new Bitmap(_pressenter.VideoDisplayModel.SNameROI.Width, _pressenter.VideoDisplayModel.SNameROI.Height);
            Graphics gs = Graphics.FromImage(second);

            gs.DrawImage(CopyFrame, 0, 0, _pressenter.VideoDisplayModel.SNameROI, GraphicsUnit.Pixel);

            if (second != null)
            {
                _nameOCR.PlayerName(second);
                playerSecond = _nameOCR.Name;
                playerSecond.Trim();
            }
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {          
            _pressenter.SaveVideo();
            btnApply.Enabled = true;

            try
            {
                lblSavePath.Text = SavePath;
            }

            catch
            { }
        }
    }
}
