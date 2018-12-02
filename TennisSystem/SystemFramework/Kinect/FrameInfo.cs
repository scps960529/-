using System;
using SystemFramework.DataStructure;

namespace SystemFramework.Kinect
{
    [Serializable]
    public class FrameInfo
    {
        public byte[] DepthImageData    { get; set; }

        public Vec3d[] SkeletonData     { get; set; }

        public byte[] ColorImageData    { get; set; }
        
        public byte[] BodyIndexImageData { get; set; }

        //Color Description
        public int ColorWidth           { get; set; }
        public int ColorHeight          { get; set; }

        //Depth Description
        public int DepthWidth           { get; set; }
        public int DepthHeight          { get; set; }

        public int SkeletonPointCount   { get; set; }

        public FrameInfo()
        {
            ColorWidth      = 5;
            ColorHeight     = 1;
            DepthWidth      = 5;
            DepthHeight     = 1;
            SkeletonPointCount = 25;
            DepthImageData      = new byte[DepthWidth * DepthHeight * 2];
            ColorImageData      = new byte[ColorWidth * ColorHeight * 3];
            BodyIndexImageData  = new byte[DepthWidth * DepthHeight * 1];
            SkeletonData        = new Vec3d[SkeletonPointCount];
        }
    }
}
