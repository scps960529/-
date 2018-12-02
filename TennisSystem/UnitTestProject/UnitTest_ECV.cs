using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using EmguCVFramework;
using EmguCVFramework.MaskFilters;
using EmguCVFramework.PreProcess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    public partial class UnitTest_main
    {
        [TestMethod]
        public void TestImageWrapData()
        {
            try
            {
                #region path
                var folder1 = @"D:\新增資料夾\微微\";
                var folder2 = @"D:\新增資料夾\";
                var filePath1 = folder1 + @"1474597914162.jpg";
                var filePath2 = folder2 + @"OrgBitmap.jpg";
                var filePath3 = folder2 + @"CvBitmap.jpg";
                var filePath4 = folder2 + @"B.jpg";
                var filePath5 = folder2 + @"G.jpg";
                var filePath6 = folder2 + @"R.jpg";
                var filePath7 = folder2 + @"RGB.jpg";
                var filePath8 = folder2 + @"LaplaceEdgeEnhance.jpg";
                var filePath9 = folder2 + @"TestColorSpace.jpg";
                Debug.Assert(File.Exists(filePath1));
                #endregion

                Bitmap bp = new Bitmap(filePath1);
                Debug.Assert(bp.PixelFormat == System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                bp.Save(filePath2);
                var img = ECVFactory.CreateImageWrappData(bp);
                Debug.Assert(img != null);

                var test0 = img.GetChannelImage(EImageChannel.Channel_0);
                Debug.Assert(test0 != null);
                var test1 = img.GetChannelImage(EImageChannel.Channel_1);
                Debug.Assert(test1 != null);
                var test2 = img.GetChannelImage(EImageChannel.Channel_2);
                Debug.Assert(test2 != null);
                var test3 = img.GetChannelImage(EImageChannel.Channel_3);
                Debug.Assert(test3 == null);

                var imgCopy = img.BitmapImageClone;
                imgCopy.Save(filePath3);
                Debug.Assert(File.Exists(filePath3));

                Debug.Assert(bp.Height == img.Height);
                Debug.Assert(bp.Width == img.Width);

                var imgB = test0.HistogramEqualization();
                ECVFactory.GreyToRGBImage(imgB).Dispose();
                var imgG = test1.HistogramEqualization();
                var imgR = test2.HistogramEqualization();
                var imgRGB = ECVFactory.GreyToRGBImage(test0.Height, test0.Width, test0, test1, test2);

                imgRGB.BitmapImageClone.Save(filePath7);
                Debug.Assert(File.Exists(filePath7));

                imgB = ECVFactory.GreyToRGBImage(imgB, EImageChannel.Channel_0);
                imgB.BitmapImageClone.Save(filePath4);
                Debug.Assert(File.Exists(filePath4));
                
                imgG = ECVFactory.GreyToRGBImage(imgG, EImageChannel.Channel_1);
                imgG.BitmapImageClone.Save(filePath5);
                Debug.Assert(File.Exists(filePath5));

                imgR = ECVFactory.GreyToRGBImage(imgR, EImageChannel.Channel_2);
                imgR.BitmapImageClone.Save(filePath6);
                Debug.Assert(File.Exists(filePath6));

                img.LaplaceEdgeEnhance();
                img.BitmapImageClone.Save(filePath8);
                Debug.Assert(File.Exists(filePath8));

                /*
                img.ChangeColorSpace(EColorType.ARGB);
                img.BitmapImageClone.Save(filePath9);
                Debug.Assert(File.Exists(filePath9));
                */
                bp.Dispose();
                test0.Dispose();
                test1.Dispose();
                test2.Dispose();
                imgB.Dispose();
                imgG.Dispose();
                imgR.Dispose();
                imgRGB.Dispose();
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception e)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                throw;
            }
        }

        [TestMethod]
        public void TestSkinDetection()
        {
            #region path
            var folder1 = @"D:\新增資料夾\微微\";
            var folder2 = @"D:\新增資料夾\";
            var filePath1 = folder1 + @"1473946373710.jpg";
            var filePath2 = folder2 + @"OrgBitmap.jpg";
            var filePath3 = folder2 + @"CvBitmap.jpg";
            var filePath4 = folder2 + @"Skin_YCbCr.jpg";
            var filePath5 = folder2 + @"Skin_HSV.jpg";
            var filePath6 = folder2 + @"R.jpg";
            Debug.Assert(File.Exists(filePath1));
            #endregion

            Bitmap bp = new Bitmap(filePath1);
            Debug.Assert(bp.PixelFormat == System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            bp.Save(filePath2);
            var img = ECVFactory.CreateImageWrappData(bp);
            Debug.Assert(img != null);

            var imgCopy = img.BitmapImageClone;
            imgCopy.Save(filePath3);
            Debug.Assert(File.Exists(filePath3));

            var kernel_YCbCr = new SkinDetection(SkinDetection.Type.YCbCr);
            var result_YCbCr = kernel_YCbCr.Execute(img);
            result_YCbCr.BitmapImageClone.Save(filePath4);
            Debug.Assert(File.Exists(filePath4));

            var kernel_HSV = new SkinDetection(SkinDetection.Type.HSV);
            var result_HSV = kernel_HSV.Execute(img);
            result_HSV.BitmapImageClone.Save(filePath5);
            Debug.Assert(File.Exists(filePath5));
        }

        [TestMethod]
        public void TestHalftonFilter()
        {
            HalftonFilter filter = new HalftonFilter();
        }
    }
}
