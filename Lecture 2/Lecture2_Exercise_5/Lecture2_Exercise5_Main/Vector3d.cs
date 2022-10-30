using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSE
{
    public class Vector3d : Vector
    {
        public Vector3d(string aVectorName, double x, double y, double z)
        {
            Console.WriteLine("3d Vector name: " + aVectorName + " has been created.");
            Console.WriteLine("3d Vector x: " + x + " has been created.");
            Console.WriteLine("3d Vector x: " + y + " has been created.");
            Console.WriteLine("3d Vector x: " + z + " has been created.");

            this.x = x;
            this.y = y;
            this.z = z;
        }
        public override double GetNorm()
        {
            double value = Math.Sqrt(x * x + y * y + z * z);
            Console.WriteLine("Norm of the vector is " + value);
            return value;
        }

        //public override double GetDotProduct()
        //{
        //    double value = 
        //    return value;
        //}
        //public override string PrintVector()
        //{
        //    Console.WriteLine("3d Vector Coordinates are:");
        //    Console.WriteLine("x: " + x);
        //    Console.WriteLine("y: " + y);
        //    Console.WriteLine("z: " + z);
        //}

        public override void PrintVector()
        {
            string VectorCoordinates = $"Vector Coordinates x:{x}, y:{y}, z:{z}";
            Console.WriteLine(VectorCoordinates);
        }
    }
}
