using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw.Tools
{
    public class Cartesian
    {
        private PictureBox _drawingScreen;
        private float _DPI;

        public Cartesian(PictureBox drawingScreen,float DPI)
        {
            _drawingScreen = drawingScreen;
            _DPI = DPI;
        }

        public Vector2 PointToCartesian(System.Drawing.Point point)
        {
            return new Vector2(PixelToMn(point.X ), PixelToMn(_drawingScreen.Height - point.Y));
        }
        public float PixelToMn(float pixel)
        {
            return pixel * 25.4f / _DPI;
        }
    }
}
