using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Draw.ShapeManagement.EnumShapes;

namespace Draw.Extensions
{
    class ShapeButton : Button
    {
        private EnumShape shape;

        public ShapeButton(EnumShape shape)
        {
            this.shape = shape;
        }

        public EnumShape Shape
        {
            get { return shape; }
        }
    }
}
