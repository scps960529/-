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
        public void TestDrawingPoints1()
        {
            Form f = new Form(); // 新增 Form 物件

            Graphics g = Graphics.FromHwnd(f.Handle);
            //
            Point p1 = new Point(10, 10);
            Point p2 = new Point(50, 50);
            g.DrawPoint(p1
                        , ShapType.Rectangle
                        , Color.Yellow);

            g.DrawPoint(p2
                        , ShapType.FillRectangle
                        , Color.Yellow);

            g.DrawLine(new Pen(Color.Red)
                        , p1
                        , p2);
        }

        [TestMethod]
        public void TestDrawingPoints2()
        {
            Form f = new Form();

            Graphics g = Graphics.FromHwnd(f.Handle);

            Point p1 = new Point(10, 10);
            Point p2 = new Point(20, 20);
            Point p3 = new Point(30, 30);
            Point p4 = new Point(40, 40);
            Point p5 = new Point(50, 50);
            g.DrawLinkPoints(ShapType.Rectangle
                        , Color.Yellow, Color.Red, p1, p2, p3, p4, p5);
        }
    }
}
