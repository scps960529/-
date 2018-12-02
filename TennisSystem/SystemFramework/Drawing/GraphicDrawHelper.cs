using System;
using System.Drawing;
using SystemFramework.Kinect;

namespace SystemFramework.Drawing
{
    public static class GraphicDrawHelper 
    {
        public static void DrawPoint(this Graphics g, Point p, ShapType type, Color color)
        {
            // 矩形繪製 : DrawRectangle (Pen pen , Rectangle rect)
            // Pen 物件 可決定 矩形顏色 、 寬度、樣式
            switch (type)
            {
                case ShapType.Rectangle:
                    g.DrawRectangle(new Pen(color), new Rectangle(p.X - 5, p.Y - 5, 11, 11));
                    break;
                case ShapType.FillRectangle:
                    g.FillRectangle(new SolidBrush(color), new Rectangle(p.X - 5, p.Y - 5, 11, 11));
                    break;
                case ShapType.Round:
                    g.DrawEllipse(new Pen(color), new Rectangle(p.X - 5, p.Y - 5, 11, 11));
                    break;
                case ShapType.FillRound:
                    g.FillEllipse(new SolidBrush(color), new Rectangle(p.X - 5, p.Y - 5, 11, 11));
                    break;
                default:
                    throw new NotSupportedException();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="type"></param>
        /// <param name="colorPoint"></param>
        /// <param name="colorLine"></param>
        /// <param name="arrPoints"></param>
        public static void DrawLinkPoints(this Graphics g, ShapType type, Color colorPoint, Color colorLine, params Point[] arrPoints)
        {
            //
            foreach (var p in arrPoints) 
            {
                switch (type)
                {   //Rectangle(起始x,起始y,寬,高);
                    case ShapType.Rectangle:
                        g.DrawRectangle(new Pen(colorPoint), new Rectangle(p.X - 5, p.Y - 5, 11, 11));
                        break;
                    case ShapType.FillRectangle:
                        g.FillRectangle(new SolidBrush(colorPoint), new Rectangle(p.X - 5, p.Y - 5, 11, 11));
                        break;
                    case ShapType.Round:
                        g.DrawEllipse(new Pen(colorPoint), new Rectangle(p.X - 5, p.Y - 5, 11, 11));
                        break;
                    case ShapType.FillRound:
                        g.FillEllipse(new SolidBrush(colorPoint), new Rectangle(p.X - 5, p.Y - 5, 11, 11));
                        break;
                    default:
                        throw new NotSupportedException();
                }
            }

            for (int i = 0; i < arrPoints.Length - 1; i++)
            {
                g.DrawLine(new Pen(colorLine), arrPoints[i], arrPoints[i + 1]);
            }
        }
    }
}