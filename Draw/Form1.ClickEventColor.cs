using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw
{
    partial class Form1
    {
        private List<Button> colorButtons = new List<Button>();

        private void ColorButton_Click(object sender, EventArgs e)
        {
            Button selectedColorButton = sender as Button;
            selectedColorButton.SelectActiveButton(colorButtons);
            shapeManager.setColor(selectedColorButton.BackColor);
            drawingScreen.Invalidate();
        }
    }
}

