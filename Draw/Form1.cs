using Draw.Entities;
using Draw.Extensions;
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

//Hüseyin Burhan Başaran
//github.com/burhan154

namespace Draw
{
    public partial class Form1 : Form
    {
        private Vector2 currentPosition;
        private Vector2 firstPoint;
        private ShapeManager shapeManager;
        private Cartesian cartesian;

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


            foreach (var button in colorButtons)
            {
                if (button.BackColor.ToArgb().Equals(shapeManager.getColor().ToArgb()))
                    button.SelectActiveButton(colorButtons);
            }

            foreach (ShapeButton button in shapeButtons)
            {
                if (button.Shape.Equals(shapeManager.getShape()))
                    button.SelectActiveButton(shapeButtons);
            }
        }

        /// Button click event kodları Form1'in içerisindedir. 

    }
}
