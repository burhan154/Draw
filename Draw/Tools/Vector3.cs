using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw
{
    public class Vector3 : Vector2
    {
        private double z;

        public Vector3(double x, double y,double z) :base(x,y)
        {
            this.Z = z;
        }

        public double Z
        {
            get { return z; }
            set { z = value; }
        }

        public static new Vector3 Zero
        {
            get { return new Vector3(0.0,0.0 ,0.0); }
        }

    }
}
