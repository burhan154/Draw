using Draw.Entities;
using Draw.ShapeManagement;
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
        private ShapeManager shapeManager = new ShapeManager();

        public Form1()
        {
            InitializeComponent();
        }

        private void drawingScreen_MouseMove(object sender, MouseEventArgs e)
        {
            currentPosition = PointToCartesian(e.Location);
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

        private Vector2 PointToCartesian(System.Drawing.Point point)
        {
            return new Vector2(PixelToMn(point.X), PixelToMn(drawingScreen.Height - point.Y));
        }
        private float PixelToMn(float pixel)
        {
            return pixel * 25.4f / DPI;
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
            e.Graphics.SetParameters(PixelToMn(drawingScreen.Height));
            //e.Graphics.GetPa
            shapeManager.drawScreen(e.Graphics , firstPoint, currentPosition);
            //label1.Text = currentPosition.X + "      " + currentPosition.Y;
            //label2.Text = PixelToMn(drawingScreen.Width) + "";
        }

        private void drawingScreen_MouseUp(object sender, MouseEventArgs e)
        {
            shapeManager.addActiveShape();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            shapeManager.setShape(EnumShape.Rectangle);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            shapeManager.setShape(EnumShape.Circle);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            shapeManager.setShape(EnumShape.Hexagon);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            shapeManager.setShape(EnumShape.Triangle);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            shapeManager.Select();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            shapeManager.setColor(Color.Red);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            shapeManager.setColor(Color.Blue);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            shapeManager.setColor(Color.Green);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            shapeManager.setColor(Color.Orange);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            shapeManager.setColor(Color.Black);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            shapeManager.setColor(Color.Yellow);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            shapeManager.setColor(Color.Purple);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            shapeManager.setColor(Color.Brown);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            shapeManager.setColor(Color.White);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            shapeManager.Remove();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            shapeManager.Clear();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            shapeManager.OpenShapes();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            shapeManager.SaveShapes();
        }
    }
}
