using System;

namespace SystemFramework.DataStructure
{
    [Serializable]
    public sealed class Vec3d : Vec2d
    {
        public double Z { get; set; }

        public Vec3d(double x = -999, double y = -999, double z = -999)
            :base(x, y)
        {
            HasData = (HasData || z != -999) ? false : true;
            if (HasData)
            {
                Z = (z == -999) ? 0 : z;
            }
            else
                Z = 0;
        }
    }
}