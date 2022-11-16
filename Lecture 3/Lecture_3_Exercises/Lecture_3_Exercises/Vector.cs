using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProSE_Lecture3
{
    public interface IVector
    {
    public double GetNorm();
    public void PrintNorm();
    }
    public class Vector2D : IVector
    {
        public double x;
        public double y;

        public Vector2D(double x, double y)
        {
            this.x = x;
            this.y = y;

        }
    public double GetNorm()
        {
            double value = Math.Sqrt(x * x + y * y);
            return value;
        }
        public void PrintNorm()
        {
            Console.WriteLine(GetNorm());
        }
    }

    public class Vector3D : IVector
    {
        double x;
        double y;
        double z;
        public Vector3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public double GetNorm()
        {
            double value = Math.Sqrt(x * x + y * y + z * z);
            return value;
        }
        public void PrintNorm()
        {
            Console.WriteLine(GetNorm());
        }

    }
    
}
