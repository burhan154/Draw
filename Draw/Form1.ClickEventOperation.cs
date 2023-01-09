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
        private List<Button> operationButtons = new List<Button>();

        private void btnSelect_Click(object sender, EventArgs e)
        {
            (sender as Button).SelectActiveButtonDoubleClick(operationButtons);
            shapeManager.Select();
            drawingScreen.Invalidate();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            shapeManager.Remove();
            drawingScreen.Invalidate();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            shapeManager.Clear();
            drawingScreen.Invalidate();
        }
    }
}

