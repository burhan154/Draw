using Draw.Entities;
using Draw.ShapeManagement;
using Draw.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Draw.ShapeManagement.EnumShapes;

namespace Draw
{
    public partial class Form1 : Form
    {
        private Vector2 currentPosition;
        private Vector2 firstPoint;
        private ShapeManager shapeManager;
        private Cartesian cartesian;

        private List<Button> fileButtons = new List<Button>();
        private List<Button> operationButtons = new List<Button>();
        private List<Button> colorButtons = new List<Button>();
        private List<Button> shapeButtons = new List<Button>();

        public Form1()
        {
            InitializeComponent();
            shapeManager = new ShapeManager();
            cartesian = new Cartesian(drawingScreen,DPI);
        }

        private void drawingScreen_MouseMove(object sender, MouseEventArgs e)
        {
            currentPosition = cartesian.PointToCartesian(e.Location);
            drawingScreen.Refresh();
        }
        private float DPI
        {
            get
            {
                using (var g = CreateGraphics())
                    return g.DpiX;
            }
        }

        private void drawingScreen_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                firstPoint = currentPosition;
                shapeManager.drawNewShape();
                drawingScreen.Refresh();
            }
        }

        private void drawingScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SetParameters(cartesian.PixelToMn(drawingScreen.Height));
            shapeManager.setGraphics(e.Graphics);
            shapeManager.drawScreen(firstPoint, currentPosition);
        }

        private void drawingScreen_MouseUp(object sender, MouseEventArgs e)
        {
            shapeManager.addActiveShape();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            (sender as Button).SelectActiveButton(shapeButtons);
            shapeManager.setShape(EnumShape.Rectangle);
        }
        private void button20_Click(object sender, EventArgs e)
        {
            (sender as Button).SelectActiveButton(shapeButtons);
            shapeManager.setShape(EnumShape.Circle);
        }
        private void button19_Click(object sender, EventArgs e)
        {
            (sender as Button).SelectActiveButton(shapeButtons);
            shapeManager.setShape(EnumShape.Hexagon);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            (sender as Button).SelectActiveButton(shapeButtons);
            shapeManager.setShape(EnumShape.Triangle);
        }
        private void ColorButton_Click(object sender, EventArgs e)
        {
            Button selectedColorButton = sender as Button;
            selectedColorButton.SelectActiveButton(colorButtons);
            shapeManager.setColor(selectedColorButton.BackColor);
            drawingScreen.Invalidate();
        }
        private void button17_Click(object sender, EventArgs e)
        {
            (sender as Button).SelectActiveButton(operationButtons);
            shapeManager.Remove();
            drawingScreen.Invalidate();
        }
        private void button16_Click(object sender, EventArgs e)
        {
            (sender as Button).SelectActiveButton(operationButtons);
            shapeManager.Clear();
            drawingScreen.Invalidate();
        }
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
        private void btnSelect_Click(object sender, EventArgs e)
        {
            (sender as Button).SelectActiveButtonDoubleClick(operationButtons);
            shapeManager.Select();
            drawingScreen.Invalidate();
        }
    }
}
