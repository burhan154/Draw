using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Draw.ShapeManagement.EnumShapes;

namespace Draw.ShapeManagement
{
    public class ShapeEntity
    {
        public Vector2 center { get; set; }
        public Vector2 endPoint { get; set; }
        public SolidBrush brush { get; set; }
        public EnumShape shape { get; set; }
    }
}
