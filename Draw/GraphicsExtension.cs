using Draw.Entities;
using Draw.ShapeManagement;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw
{
     static class GraphicsExtension
     {
        private static float Height;

        public static void SetParameters(this Graphics g,float height)
        {
            Height = height;
        }
        public static void SetTransform(this Graphics g)
        {
            g.PageUnit = GraphicsUnit.Millimeter;
            g.TranslateTransform(0, Height);
            g.ScaleTransform(1.0f, -1.0f);
        }

        public static void DrawCircle(this Graphics g,Brush brush,Shape shape)
        {
            float x = (float)(shape.Center.X - shape.Radius());
            float y = (float)(shape.Center.Y - shape.Radius());
            var  r =  2 * (float)shape.Radius();

            g.SetTransform();
            g.FillEllipse(brush, x, y, r-1, r-1);
            g.ResetTransform();
        }

        public static void DrawRectangle(this Graphics g, Brush brush, Shape shape)
        {
            float zx = (float)Math.Abs(shape.EndPoint.X - shape.Center.X);
            float zy =  (float)Math.Abs(shape.EndPoint.Y - shape.Center.Y);

            float x = (float)(shape.Center.X - zx);
            float y = (float)(shape.Center.Y - zy);

            g.SetTransform();
            g.FillRectangle(brush, x, y, 2*zx,2* zy);
            g.ResetTransform();
        }

        public static void DrawHexagon(this Graphics g, Brush brush, Shape shape)
        {
            float x = (float)Math.Abs(shape.Center.X );
            float y = (float)Math.Abs(shape.Center.Y );
            var r =  (float)shape.Radius();
            var shapePoint = new PointF[6];

            for (int a = 0; a < 6; a++)
            {
                shapePoint[a] = new PointF(
                    x + r * (float)Math.Cos(a * 60 * Math.PI / 180f),
                    y + r * (float)Math.Sin(a * 60 * Math.PI / 180f));
            }
            
            g.SetTransform();
            g.FillPolygon(brush, shapePoint);
            g.ResetTransform();
        }
        public static void DrawTriangle(this Graphics g, Brush brush, Shape shape)
        {
            float cx = (float)(shape.Center.X);
            float cy = (float)(shape.Center.Y);

            float x =  (float)(shape.EndPoint.X );
            float y =  (float)(shape.EndPoint.Y );

            PointF point1, point2, point3;
            point1 = new PointF(x, y );
            point2 = new PointF(2*cx-x, y);
            point3 = new PointF(cx , 2 * cy-y);
            PointF[] curvePoints = { point1, point2, point3 };

            g.SetTransform();
            g.FillPolygon(brush, curvePoints);
            g.ResetTransform();
        }

    }
}
