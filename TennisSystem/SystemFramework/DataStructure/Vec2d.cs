using System;

namespace SystemFramework.DataStructure
{
    [Serializable]
    public class Vec2d
    {
        public double X { get; set; }

        public double Y { get; set; }

        public virtual bool HasData { get; protected set; }

        public Vec2d(double x = -999, double y = -999)
        {
            HasData = (x != -999 || y != -999) ? false : true;
            if (HasData)
            {
                X = (x == -999) ? 0 : x;
                Y = (y == -999) ? 0 : y;
            }
            else
                X = Y = 0;
        }
    }
}