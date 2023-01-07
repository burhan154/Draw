using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Draw.ShapeManagement.EnumShapes;

namespace Draw.ShapeManagement
{
    public class ShapeCreator
    {
        private Type[] types;

        public ShapeCreator()
        {
            types = Assembly.GetExecutingAssembly().GetTypes()
                           .Where(t => t.IsSubclassOf(typeof(Shape))).ToArray();
        }

        public Shape CreateNewShape(EnumShape shape, Vector2 firstPoint, Vector2 currentPosition, SolidBrush brush)
        {
            Shape newShape;
            foreach (Type T in types)
            {
                if(T.Name == shape.ToString()) 
                { 
                    newShape = (Shape)Activator.CreateInstance(T, firstPoint, currentPosition, brush);
                    return newShape;
                }   
            }
            return (Shape)Activator.CreateInstance(types[0], firstPoint, currentPosition, brush); ;
        }

        public Shape CreateNewShape(ShapeEntity shapeEntity)
        {
            return CreateNewShape(shapeEntity.shape, shapeEntity.center, shapeEntity.endPoint, shapeEntity.brush);
        }
    }
}
