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
        private List<Button> fileButtons = new List<Button>();

        private void btnSave_Click(object sender, EventArgs e)
        {
            (sender as Button).SelectActiveButton(fileButtons);
            shapeManager.SaveShapes();
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            (sender as Button).SelectActiveButton(fileButtons);
            shapeManager.OpenShapes();
            drawingScreen.Invalidate();
        }  
    }
}

