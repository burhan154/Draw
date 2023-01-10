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

            preventOverflow(graphics.ClipBounds.Width, graphics.ClipBounds.Height);
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
