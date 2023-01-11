using Draw.Extensions;
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
        private List<Button> shapeButtons = new List<Button>();
        private List<Button> operationButtons = new List<Button>();
        private List<Button> fileButtons = new List<Button>();

        //Buttonun rengini aktif renk olarak seçer.
        private void ColorButton_Click(object sender, EventArgs e)
        {
            Button selectedColorButton = sender as Button;
            selectedColorButton.SelectActiveButton(colorButtons);
            shapeManager.setColor(selectedColorButton.BackColor);
            drawingScreen.Invalidate();
        }

        //Şekil butonunun şeklini aktif şekiil olarak seçer.
        private void btnShape_Click(object sender, EventArgs e)
        {
            ShapeButton selectedButton = sender as ShapeButton;
            selectedButton.SelectActiveButton(shapeButtons);
            shapeManager.setShape(selectedButton.Shape);
            drawingScreen.Invalidate();
        }

        //Seç, sil ve temizle butonları.
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

        //Kaydet ve yükle butonları
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

