using Draw.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.ShapeManagement
{

    static public class EnumShapes
    {
        public enum EnumShape { Circle, Hexagon, Triangle, Rectangle }

        public static Shape CreateNewShape(EnumShape shape , Vector2 firstPoint, Vector2 currentPosition, SolidBrush brush)
        {
            Shape newShape;
            if (shape == EnumShape.Rectangle)
            {
                newShape = new Entities.Rectangle(firstPoint, currentPosition, brush);
            }
            else if (shape == EnumShape.Circle)
            {
                newShape = new Circle(firstPoint, currentPosition, brush);
            }
            else if (shape == EnumShape.Triangle)
            {
                newShape = new Triangle(firstPoint, currentPosition, brush);
            }
            else if (shape == EnumShape.Hexagon)
            {
                newShape = new Hexagon(firstPoint, currentPosition, brush);
            }
            else
            {
                return new Entities.Rectangle(firstPoint, currentPosition, brush);
            }
            return newShape;
        }

        public static Shape CreateNewShape(ShapeEntity shapeEntity)
        {
            return CreateNewShape(shapeEntity.shape, shapeEntity.center, shapeEntity.endPoint, shapeEntity.brush);
        }
    }
}
