using System.Drawing;
using System.Windows.Forms;
using FileIOFramework.Kinect;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SystemFramework.DataStructure;
using SystemFramework.Drawing;
using SystemFramework.Kinect;

namespace UnitTestProject
{
    public partial class UnitTest_main
    {
        [TestMethod]
        public void TestSaveFrameInfoMethod()
        {
            FrameInfo fi = new FrameInfo
            {
                DepthImageData = new byte[5],
                SkeletonData = new Vec3d[2],
            };

            fi.DepthImageData[0] = 0;
            fi.DepthImageData[1] = 1;
            fi.DepthImageData[2] = 2;
            fi.DepthImageData[3] = 4;
            fi.DepthImageData[4] = 8;

            fi.SkeletonData[0] = new Vec3d(0.2, 0.8, 0.3);
            fi.SkeletonData[1] = new Vec3d(0.2, 0.8, 0.3);


            SaveToFilieHelper.Save(@"E:\", "TestSave", fi);

            var testFI = ReadFromFileHelper.Read(@"E:\", "TestSave");
        }

        [TestMethod]
        public void TestSaveFrameInfoMethod_forNewTest()
        {
            var testFI = ReadFromFileHelper.Read(@"E:\", "TestSave");
        }
    }
}
