using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Draw.ShapeManagement.EnumShapes;

namespace Draw
{
    partial class Form1
    {
        private List<Button> shapeButtons = new List<Button>();

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            (sender as Button).SelectActiveButton(shapeButtons);
            shapeManager.setShape(EnumShape.Rectangle);
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            (sender as Button).SelectActiveButton(shapeButtons);
            shapeManager.setShape(EnumShape.Circle);
        }

        private void btnTriangle_Click(object sender, EventArgs e)
        {
            (sender as Button).SelectActiveButton(shapeButtons);
            shapeManager.setShape(EnumShape.Triangle);
        }

        private void btnHexagon_Click(object sender, EventArgs e)
        {
            (sender as Button).SelectActiveButton(shapeButtons);
            shapeManager.setShape(EnumShape.Hexagon);
        }

    }
}

