using System.Windows.Forms;

namespace FileIOFramework.Pattern
{
    public class PatternFileHelper
    {
        private OpenFileDialog ofd;
        public PatternFileHelper()
        {
            ofd = new OpenFileDialog
            {
                InitialDirectory = "c:\\",
                Filter = "Pattern files(*.bmp) | *.bmp",
                RestoreDirectory = true,
            };
        }
        public string GetPatternFilePath(out string name)
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
