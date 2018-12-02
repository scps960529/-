using System.Windows.Forms;

namespace FileIOFramework.Video
{
    public class VideoSaveFileHelper
    {
        private SaveFileDialog sfd;
        public VideoSaveFileHelper()
        {
            sfd = new SaveFileDialog
            {
                InitialDirectory = "c:\\",
                Filter = "Video files(*.mp4) | *.mp4",
                RestoreDirectory = true,
            };
        }
        public string GetVideoSaveFilePath(out string name)
        {
            try
            {
                return sfd.ShowDialog() == DialogResult.OK ? sfd.FileName : "";
            }
            finally
            {
                name = sfd.FileName;
            }
        }
    }
}
