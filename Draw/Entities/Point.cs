using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.Entities
{
    public class Point
    {
        private Vector2 position;

        public Point()
        {
            this.Position = Vector2.Zero;
        }

        public Point(Vector2 position)
        {
            this.Position = position;
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

    }
}
