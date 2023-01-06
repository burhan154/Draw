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
    class Hexagon:Shape
    {
        public Hexagon(Vector2 center, Vector2 endPoint, SolidBrush brush) : base(center, endPoint, brush)
        {
            ShapeEnum = EnumShape.Hexagon;
        }
        public override void Draw(Graphics graphics, SolidBrush brush)
        {
            graphics.DrawHexagon(brush, this);
        }

        public override bool isPointInside(Vector2 currentPosition)
        {
            return isPointInsideCircle(currentPosition);
        }

        public override void Select(Graphics graphics, SolidBrush brush, Vector2 currentPosition)
        {
            graphics.DrawHexagon(brush, new Entities.Rectangle(Center, new Vector2(EndPoint.X + 2, EndPoint.Y - 2),brush));        }
    }
}
