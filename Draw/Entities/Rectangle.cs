using Draw.ShapeManagement;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Draw.ShapeManagement.EnumShapes;

namespace Draw.Entities
{
    class Rectangle: Shape
    {
        public Rectangle(Vector2 center, Vector2 endPoint, SolidBrush brush) : base(center, endPoint, brush)
        {
            ShapeEnum = EnumShape.Rectangle;
        }

        public override void Draw(Graphics graphics, SolidBrush brush)
        {
            //if (isLineInside(0.0, StartPoint().X))
            //{
            //    Move(new Vector2(Center.X - StartPoint().X, Center.Y));
            //}
            //if (isLineInside(0.0, StartPoint().Y))
            //{
            //    Move(new Vector2(Center.X, Math.Abs(EndPoint.Y- Center.Y)));
            //}
            //if (isLineInside( 2 * Center.X - StartPoint().X, graphics.ClipBounds.Width ))
            //{
            //    Move(new Vector2(Math.Abs(graphics.ClipBounds.Width - (Center.X - StartPoint().X)), Center.Y));
            //}
            //if (isLineInside(2 * Center.Y - StartPoint().Y / 2, graphics.ClipBounds.Height  ))
            //{
            //    Move(new Vector2(Math.Abs(Center.X ), Math.Abs(graphics.ClipBounds.Height - (Center.Y - StartPoint().Y/2))));
            //}

            //preventOverflow(graphics.ClipBounds.Width, graphics.ClipBounds.Height);

            
            if (isPointInside(new Vector2(Center.X , 0)))
            {
                Move(new Vector2(Center.X, Math.Abs(EndPoint.Y - Center.Y)));
            }
            if (isPointInside(new Vector2(Center.X, graphics.ClipBounds.Height)))
            {
                Move(new Vector2(Center.X, Math.Abs(graphics.ClipBounds.Height - (Center.Y - StartPoint().Y))));
            }
            if (isPointInside(new Vector2(0, Center.Y)))
            {
                Move(new Vector2(Center.X - StartPoint().X, Center.Y));
            }
            if (isPointInside(new Vector2(graphics.ClipBounds.Width, Center.Y)))
            {
                Move(new Vector2(Math.Abs(graphics.ClipBounds.Width - (Center.X - StartPoint().X)), Center.Y));
            }

            graphics.DrawRectangle(brush, this);

        }

        public override bool isPointInside(Vector2 currentPosition)
        {
            return isPointInsideRectangle(currentPosition);
        }

        public override void Select(Graphics graphics, SolidBrush brush, Vector2 currentPosition)
        {
            graphics.DrawRectangle(brush, new Rectangle(Center, new Vector2(StartPoint().X - 2, StartPoint().Y - 2), brush));
           
        }
    }
}
