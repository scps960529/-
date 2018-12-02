using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Drawing;

namespace EmguCVFramework.ScoreboardDetection
{
    public class ScoreboardDetectorTest
    {
        public Mat Mat { get; private set; }

        public Bitmap PImage { get; set; }

        public Point PatternLocation { get; set; }

        public Size PatternSize { get; set; }
       
        public bool Result { get; private set; }

        public int Threshold { get; set; }

        private Image<Bgr, byte> Pattern;

        public ScoreboardDetectorTest()
        { }

        public void Program(Image<Bgr, byte> frame)
        {
            Pattern = new Image<Bgr, byte>(PImage);
            var PatternImage = Pattern.Resize(1280, 720, Inter.Linear);

            if (frame != null)
            {
                frame.ROI = new Rectangle(PatternLocation, PatternSize);
                PatternImage.ROI = new Rectangle(PatternLocation, PatternSize);

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
                    Result = (count * 4 < frame.Width * frame.Height); //this frame is a scoreboard frame
                }
                frame.Dispose();
            }           
        }
    }
}
