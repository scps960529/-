using System;
using System.IO;
using System.Windows.Forms;

namespace SystemFramework.FileIO
{
    public class FileIOHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fullPath"></param>
        public static void FileExist(string fullPath)
        {
            if (File.Exists(fullPath) == false)
                throw new NullReferenceException();
        }

        /// <summary>
        /// Call the Save File Dialog
        /// </summary>
        /// <param name="titleMsg">Save XXX file Dialog-Box</param>
        /// <param name="filter">Format: png|*.png</param>
        /// <param name="fullPath">output the full path</param>
        /// <returns></returns>
        public static DialogResult CallSaveFileDialog(string titleMsg, string filter, out string fullPath)
        {
            // reference web-site:
            // http://blog.wahahajk.com/2009/06/c-serialize-binaryxml.html

            SaveFileDialog sfd = new SaveFileDialog()
            {
                RestoreDirectory = true,
                Title = titleMsg,
                // Set filter for file extension and default file extension
                Filter = filter,
            };

            // Display OpenFileDialog by calling ShowDialog method ->ShowDialog()
            // Get the selected file name and display in a TextBox
            if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName != null)
            {
                fullPath = sfd.FileName; // file's full path.
                return DialogResult.OK;
            }

            fullPath = "";
            return DialogResult.Cancel;
        }

        /// <summary>
        /// Call the Open File Dialog
        /// </summary>
        /// <param name="titleMsg">Save XXX file Dialog-Box</param>
        /// <param name="filter">Format: png|*.png</param>
        /// <param name="fullPath">output the full path</param>
        /// <returns></returns>
        public static DialogResult CallOpenFileDialog(string titleMsg, string filter, out string fullPath)
        {
            // reference web-site:
            // http://blog.wahahajk.com/2009/06/c-serialize-binaryxml.html

            OpenFileDialog ofd = new OpenFileDialog()
            {
                RestoreDirectory = true,
                Title = titleMsg,
                // Set filter for file extension and default file extension
                Filter = filter,
            };

            // Display OpenFileDialog by calling ShowDialog method ->ShowDialog()
            // Get the selected file name and display in a TextBox
            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName != null)
            {
                fullPath = ofd.FileName; // file's full path.
                return DialogResult.OK;
            }

            fullPath = "";
            return DialogResult.Cancel;
        }
    }
}
