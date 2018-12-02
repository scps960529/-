using System.Windows.Forms;

namespace FileIOFramework.Video
{
    public class VideoFileHelper
    {
        private OpenFileDialog ofd;
        public VideoFileHelper()
        {
            ofd = new OpenFileDialog
            {
                InitialDirectory = "c:\\",
                Filter = "Video files(*.mp4) | *.mp4",
                RestoreDirectory = true,
            };
        }
        public string GetVideoFilePath(out string name)
        {
            try
            {
                return ofd.ShowDialog() == DialogResult.OK ? ofd.FileName : "";
            }
            finally
            {
                name = ofd.SafeFileName;
            }
        }
    }
}
