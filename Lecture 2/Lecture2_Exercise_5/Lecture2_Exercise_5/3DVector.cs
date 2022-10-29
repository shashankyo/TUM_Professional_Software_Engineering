using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSE
{
    public class Vector3d : Vector
    {
        public Vector3d(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public override double GetNorm()
        {
            var result = Math.Sqrt(x * x + y * y + z * z);
            return result;
        }
    }
}
