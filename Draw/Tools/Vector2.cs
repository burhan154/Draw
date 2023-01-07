using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw
{
    public class Vector2
    {
        private double x;
        private double y;

        public Vector2(double x,double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X
        {
            get { return x; }
            set { x = value; }
        }
        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        //public PointF ToPointF
        //{
        //    get
        //    {
        //        return new PointF((float)X, (float)Y);
        //    }
        //}

        public static Vector2 Zero
        {
            get { return new Vector2(0.0, 0.0); }
        }

        public double DistanceFrom(Vector2 vector2)
        {
            double dx = vector2.X - X;
            double dy = vector2.Y - Y;
            return Math.Sqrt(dx*dx+dy*dy);
        }

    }
}
