using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using EmguCVFramework;
using EmguCVFramework.Data;
using EmguCVFramework.FaceDetection;
using EmguCVFramework.PreProcess;
using SystemFramework.FileIO;

namespace FunctionTest
{
    public partial class Form1 : Form
    {
        private IImageWrapData _img;
        private Graphics _gp;
        private ImageFaceDetector _faceDetector;
        private List<FaceInfos> _faceInfos;

        public Form1()
        {
            InitializeComponent();

            //picBoxImageMask.Parent = picBoxDisplayImage;
            picBoxImageMask.Location = new Point(300, 0);
            //picBoxImageMask.Dock = DockStyle.Fill;

            _faceDetector = new ImageFaceDetector();
        }

        private void Form1_Resize(object sender, System.EventArgs e)
        {
            DisplayImageDockToCenter();
        }

        private void OnShowDisplayImage(Bitmap bp)
        {
            picBoxDisplayImage.Image = bp;
            picBoxImageMask.Size = picBoxDisplayImage.Size;

            if (picBoxImageMask.Image != null)
            {
                if (_gp != null)
                    _gp.Dispose();
                picBoxImageMask.Image.Dispose();
            }
            picBoxImageMask.Image = new Bitmap(bp.Width, bp.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            _gp = Graphics.FromImage(picBoxImageMask.Image);

            DisplayImageDockToCenter();
        }

        private void DisplayImageDockToCenter()
        {
            picBoxDisplayImage.Left = (picBoxDisplayImage.Parent.Width - picBoxDisplayImage.Width) >> 1;
            picBoxDisplayImage.Top = (picBoxDisplayImage.Parent.Height - picBoxDisplayImage.Height) >> 1;
        }

        private void btnOpenImageFile_Click(object sender, EventArgs e)
        {
            string fullPath = "";
            FileIOHelper.CallOpenFileDialog("Select single photo"
                                        , "png|*.png|jpg|*.jpg|bmp|*.bmp"
                                        , out fullPath);

            try
            {
                FileIOHelper.FileExist(fullPath);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Exception Message", string.Format("No found the file.Path: {0}", fullPath));
                return;
            }

            _img = ECVFactory.CreateImageWrappData(fullPath);

            OnShowDisplayImage(_img.BitmapImageClone);
        }

        private void btnFaceDetection_Click(object sender, EventArgs e)
        {
            /*
            picBoxDisplayImage.Image = _img.BitmapImage;
            picBoxImageMask.Image = null;
            return;
            */
            _faceDetector.Execute(_img);
            picBoxImageMask.Image.Dispose();
            picBoxImageMask.Image = _faceDetector.DrawFaceBlockImage.BitmapImageClone;

            _faceInfos = _faceDetector.FaceInfos;
        }

        private void btnMainColorExtract_Click(object sender, EventArgs e)
        {
            var colorExtract = new MainColorExtract();

            colorExtract.Execute(_img, EColorType.RGB, new Rectangle(_faceInfos[0].Location, _faceInfos[0].Size));
        }
    }
}
