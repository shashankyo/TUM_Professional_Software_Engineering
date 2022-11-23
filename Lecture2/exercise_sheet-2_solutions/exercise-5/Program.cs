using System;

namespace Lecture2
{
    class Program
    {
        public static void Main()
        {
            // create mutiple instances/objects
            Vector2D v1 = new Vector2D(2.0, 5.0);
            Vector2D v2 = new Vector2D(1.5, 3.0);

            Vector3D v3 = new Vector3D(1.1, 2.2, 3.3);
            Vector3D v4 = new Vector3D(4.0, 6.5, 10.0);

            // relevant console outputs
            Console.WriteLine("2D Dot Product: " + Vector2D.DotProduct(v1, v2)); // function call to DotProduct inherited by Vector2D from Vector
            Console.WriteLine("3D Dot Product: " + Vector3D.DotProduct(v3, v4)); // function call to DotProduct implemented by Vector3D
            Console.WriteLine("2D Dot Product: " + Vector3D.DotProduct(v1, v2)); // function call to DotProduct inherited by Vector3D from Vector
            v1.Print();
            Console.WriteLine("Norm: " + v1.Norm());
            v3.Print();
            Console.WriteLine("Norm: " + v3.Norm());
        }
    }
}
