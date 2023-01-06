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
    class Triangle : Shape
    {
        public Triangle(Vector2 center, Vector2 endPoint, SolidBrush brush) : base(center, endPoint, brush)
        {
            ShapeEnum = EnumShape.Triangle;
        }

        public override void Draw(Graphics graphics, SolidBrush brush)
        {
            //graphics.DrawRectangle(new SolidBrush(Color.Red), new Rectangle(Center, new Vector2(EndPoint.X+1,EndPoint.Y-1)));
            graphics.DrawTriangle(brush, this);
        }

        public override bool isPointInside(Vector2 currentPosition)
        {
            return isPointInsideRectangle(currentPosition);
        }

        public override void Select(Graphics graphics, SolidBrush brush, Vector2 currentPosition)
        {
            graphics.DrawRectangle(brush, new Rectangle(Center, EndPoint, brush));
        }
    }
}
