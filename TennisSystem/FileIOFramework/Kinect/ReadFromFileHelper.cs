using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using SystemFramework.Kinect;

namespace FileIOFramework.Kinect
{
    public static class ReadFromFileHelper
    {
        public static FrameInfo Read(string filePath, string fileName)
        {
            // reference web-site:
            // http://blog.wahahajk.com/2009/06/c-serialize-binaryxml.html
            //binary case

            IFormatter binFmt = new BinaryFormatter();
            Stream s = File.Open(string.Format("{0}\\{1}.RawD", filePath, fileName), FileMode.Open);
            var obj = (FrameInfo)binFmt.Deserialize(s);
            s.Close();

            return obj;
        }
    }
}
