using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace DLib.WinForms.Drawing
{
    public static class Extensions
    {
        public static void DrawArrow(this Graphics graphics,
            Pen pen,
            float startX, float startY, float endX, float endY,
            float arrowheadLength,
            double arrowheadAngle)
        {
            if (pen == null) throw new ArgumentNullException("pen");

            double L = Math.Sqrt(Math.Pow(endX - startX, 2) + Math.Pow(endY - startY, 2));
            double cosA = (endX - startX) / L;
            double sinA = (endY - startY) / L;
            double arrowheadCos = Math.Cos(arrowheadAngle);
            double arrowheadSin = Math.Sin(arrowheadAngle);

            graphics.DrawLine(pen, startX, startY, endX, endY);
            graphics.DrawLine(pen,
                endX,
                endY,
                (float)(endX - arrowheadLength * (cosA * arrowheadCos + sinA * arrowheadSin)),
                (float)(endY - arrowheadLength * (sinA * arrowheadCos - cosA * arrowheadSin)));
            graphics.DrawLine(pen,
                endX,
                endY,
                (float)(endX - arrowheadLength * (cosA * arrowheadCos - sinA * arrowheadSin)),
                (float)(endY - arrowheadLength * (sinA * arrowheadCos + cosA * arrowheadSin)));
        }

        public static void DrawArrow(this Graphics graphics,
            Pen pen,
            Point start, Point end,
            float arrowheadLength,
            double arrowheadAngle)
        {
            graphics.DrawArrow(pen, start.X, start.Y, end.X, end.Y, arrowheadLength, arrowheadAngle);
        }




        public static GraphicsPath ToRoundedRect(this Rectangle Rect)
        {
            GraphicsPath path = new GraphicsPath();
            if (Rect.Width == 0 || Rect.Height == 0)
            {
                path.AddRectangle(Rect);
                return path;
            }
            if (Rect.Width >= Rect.Height) // горизонтальный овал
            {
                Rectangle rectLeft = new Rectangle(Rect.Left, Rect.Top, Rect.Height, Rect.Height);
                path.AddArc(rectLeft, 90, 180);
                path.AddLine(new Point(Rect.Left + Rect.Height / 2, Rect.Top), new Point(Rect.Right - Rect.Height / 2, Rect.Top));
                Rectangle rectRight = new Rectangle(Rect.Right - Rect.Height, Rect.Top, Rect.Height, Rect.Height);
                path.AddArc(rectRight, 270, 180);
            }
            else // вертикальный овал
            {
                Rectangle rectTop = new Rectangle(Rect.Left, Rect.Top, Rect.Width, Rect.Width);
                path.AddArc(rectTop, 180, 180);
                path.AddLine(new Point(Rect.Right, Rect.Top + Rect.Width / 2), new Point(Rect.Right, Rect.Bottom - Rect.Width / 2));
                Rectangle rectBottom = new Rectangle(Rect.Left, Rect.Bottom - Rect.Width, Rect.Width, Rect.Width);
                path.AddArc(rectBottom, 0, 180);
            }
            path.CloseFigure();
            return path;
        }


        public static GraphicsPath ToRoundedRect(this Rectangle Rect, int RoundRadius)
        {
            GraphicsPath path = new GraphicsPath();
            if (Rect.Width == 0 || Rect.Height == 0 || RoundRadius == 0)
            {
                path.AddRectangle(Rect);
                return path;
            }
            int Size = RoundRadius * 2;
            path.AddArc(new Rectangle(Rect.Left, Rect.Top, Size, Size), 180, 90);
            path.AddLine(new Point(Rect.Left + RoundRadius, Rect.Top), new Point(Rect.Right - RoundRadius, Rect.Top));
            path.AddArc(new Rectangle(Rect.Right - Size, Rect.Top, Size, Size), 270, 90);
            path.AddLine(new Point(Rect.Right, Rect.Top + RoundRadius), new Point(Rect.Right, Rect.Bottom - RoundRadius));
            path.AddArc(new Rectangle(Rect.Right - Size, Rect.Bottom - Size, Size, Size), 0, 90);
            path.AddLine(new Point(Rect.Right - RoundRadius, Rect.Bottom), new Point(Rect.Left + RoundRadius, Rect.Bottom));
            path.AddArc(new Rectangle(Rect.Left, Rect.Bottom - Size, Size, Size), 90, 90);
            path.AddLine(new Point(Rect.Left, Rect.Bottom - RoundRadius), new Point(Rect.Left, Rect.Top + RoundRadius));
            path.CloseFigure();
            return path;
        }


        //graphics.DrawPath | FillPath (GrasphicsPath)
    }
}
