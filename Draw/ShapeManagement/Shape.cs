using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Draw.Entities;
using static Draw.ShapeManagement.EnumShapes;

namespace Draw.ShapeManagement
{
    public abstract class Shape
    {
        public ShapeEntity shapeEntity = new ShapeEntity();

        public Shape() : this(Vector2.Zero, Vector2.Zero, new SolidBrush(Color.Gray))
        {
        }

        public Shape(Vector2 center, Vector2 endPoint, SolidBrush brush)
        {
            this.Center = center;
            this.EndPoint = endPoint;
            this.Brush = (SolidBrush)brush.Clone();
        }

        public SolidBrush Brush
        {
            get { return shapeEntity.brush; }
            set { shapeEntity.brush = (SolidBrush)value.Clone(); }
        }

        public Vector2 Center
        {
            get { return shapeEntity.center; }
            set { shapeEntity.center = value; }
        }

        public Vector2 EndPoint
        {
            get { return shapeEntity.endPoint; }
            set { shapeEntity.endPoint = value; }
        }

        public EnumShape ShapeEnum
        {
            get { return shapeEntity.shape; }
            set { shapeEntity.shape = value; }
        }

        public Vector2 StartPoint()
        {
            double zx = Math.Abs(EndPoint.X - Center.X);
            double zy = Math.Abs(EndPoint.Y - Center.Y);
            double x = (Center.X - zx);
            double y = (Center.Y - zy);

            return new Vector2(x,  y);
        }

        public double Radius()
        {
            return Center.DistanceFrom(EndPoint);
        }

        public void Move(Vector2 newPoint)
        {
            var x = EndPoint.X - Center.X;
            var y = EndPoint.Y - Center.Y;

            Center.X = newPoint.X;
            Center.Y = newPoint.Y;

            EndPoint.X = Center.X + x;
            EndPoint.Y = Center.Y + y; 
        }

        protected void preventOverflow(double width, double height)
        {

            if ( StartPoint().Y  < 0)
            {
                Move(new Vector2(Center.X, Center.Y - StartPoint().Y));
            }
            if (2*Center.Y - StartPoint().Y > height)
            {
                Move(new Vector2(Center.X, height - (Center.Y - StartPoint().Y)));
            }
            if (StartPoint().X < 0)
            {
                Move(new Vector2(Center.X - StartPoint().X, Center.Y));
            }
            if (2 * Center.X - StartPoint().X > width)
            {
                Move(new Vector2(width - (Center.X- StartPoint().X), Center.Y));
            }
        }
        protected void preventOverflowCircle(double width, double height)
        {
            //Radius()
            if (Center.Y -Radius() < 0)
            {
                Move(new Vector2(Center.X, Radius()));
            }
            if (Center.Y + Radius() > height)
            {
                Move(new Vector2(Center.X, height - Radius()));
            }
            if (Center.X - Radius() < 0)
            {
                Move(new Vector2(Radius(), Center.Y));
            }
            if (Center.X+ Radius() > width)
            {
                Move(new Vector2(width - Radius(), Center.Y));
            }
        }


        protected bool isPointInsideRectangle(Vector2 point)
        {
            double zx = Math.Abs(EndPoint.X - Center.X);
            double zy = Math.Abs(EndPoint.Y - Center.Y);
            double x = (Center.X - zx);
            double y = (Center.Y - zy);

            if (point.X > x && point.X < x+2*zx && point.Y > y && point.Y < y + 2 * zy)
               return true;

            return false;
        }

        protected bool isPointInsideCircle(Vector2 point)
        {
            if ((point.X - Center.X) * (point.X - Center.X) +
            (point.Y - Center.Y) * (point.Y - Center.Y) <= Radius() * Radius())
                return true;
            
            return false;
        }


        public void Draw(Graphics graphics)
        {
            Draw(graphics, Brush);
        }

        public abstract bool isPointInside(Vector2 currentPosition);
        public abstract void Select(Graphics graphics, SolidBrush brush, Vector2 currentPosition);
        public abstract void Draw(Graphics graphics, SolidBrush brush);
    }
}
