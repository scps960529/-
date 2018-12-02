using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using SystemFramework.Kinect;

namespace FileIOFramework.Kinect
{
    public static class SaveToFilieHelper
    {
        public static void Save(string filePath, string fileName, FrameInfo fiData)
        {
            // reference web-site:
            // http://blog.wahahajk.com/2009/06/c-serialize-binaryxml.html
            //binary case

            IFormatter binFmt = new BinaryFormatter();
            Stream s = File.Open(string.Format("{0}\\{1}.RawD", filePath, fileName), FileMode.Create);
            binFmt.Serialize(s, fiData);
            s.Close();
        }
    }
}
