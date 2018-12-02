using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Drawing;

namespace EmguCVFramework.ScoreboardDetection
{
    public class ScoreboardDetectorTest_2
    {
        public Mat Mat { get; private set; }

        public Bitmap CourtColorImage { get; set; }

        public Point CourtLocation { get; set; }

        public Size CourtSize { get; set; }

        public bool Result { get; private set; }

        public int Threshold { get; set; }

        private Image<Bgr, byte> Pattern;

        public int Iscount { get; private set; }

        //private Image<Bgr, byte> Pattern_1;
        //string Pattern_1_path = @"C:\img\blue.bmp";

        public ScoreboardDetectorTest_2()
        { }

        public void Program(Image<Bgr, byte> frame)
        {       
            Pattern = new Image<Bgr, byte>(CourtColorImage);
            var PatternImage = Pattern.Resize(1280, 720, Inter.Linear);

            if (frame != null)
            {
                frame.ROI = new Rectangle(CourtLocation, CourtSize);
                PatternImage.ROI = new Rectangle(CourtLocation, CourtSize);

                var diff = PatternImage.AbsDiff(frame);
                Image<Gray, byte>[] channels = diff.Split();
                channels = new Image<Gray, byte>[] { channels[0],
                                                     channels[1],
                                                     channels[2] };

                //channels R,G,B
                var m0 = channels[0].Mat;
                var m1 = channels[1].Mat;
                var m2 = channels[2].Mat;

                unsafe
                {
                    var pB = (byte*)m0.DataPointer;
                    var pG = (byte*)m1.DataPointer;
                    var pR = (byte*)m2.DataPointer;

                    int index = 0;
                    int count = 0;

                    for (int y = 0; y < frame.Height; y++)
                    {
                        for (int x = 0; x < frame.Width; x++)
                        {
                            if ((pB[index]) > Threshold || (pG[index]) > Threshold || (pR[index]) > Threshold)
                            {
                                count++;
                            }
                            index++;
                        }
                    }
                    Result = (count * 2 < frame.Height * frame.Width); //this frame is a scoreboard frame
                    Iscount = count;
                }
                frame.Dispose();
            }
        }
    } 
}

