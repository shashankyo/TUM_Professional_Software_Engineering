using System;

namespace Lecture2
{
    public abstract class Vector
    {
        // abstract methods don't require definitions just declarations are enough but must be implemented/overriden in derived classes
        public abstract double Norm();
        // regular methods require definitions which can't be overriden in derived class but can be overloaded
        public static double DotProduct(Vector2D v1, Vector2D v2) 
        {
            return (v1.x * v2.x + v1.y * v2.y);
        }
        // virtual methods require definitions and can be overriden in derived class
        public virtual void Print() 
        {
            Console.WriteLine("Nothing to print as base class function is called and abstract class objects can't be instantiated.");
        }
    }

    public class Vector2D : Vector // inheritance DerivedClass:BaseClass
    {
        public double x, y; // member variables
        public Vector2D(double X, double Y) // constuctor
        {
            this.x = X;
            this.y = Y;
        }
        public override double Norm() // implementation of Norm
        {
            return Math.Sqrt(x * x + y * y);
        }
        public override void Print() // overriding Print from base class
        {
            Console.WriteLine("2D-Vector: [" + x + "," + y + "]"); 
        }

    }
    public class Vector3D : Vector
    {
        double x, y, z;
        public Vector3D(double X, double Y, double Z) 
        {
            this.x = X;
            this.y = Y;
            this.z = Z;
        }
        public override double Norm() // just another different implementation of Norm
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }
        public static double DotProduct(Vector3D v1, Vector3D v2) // overloading DotProduct from base class
        {
            return (v1.x * v2.x + v1.y * v2.y + v1.z * v2.z);
        }
        public override void Print() // overriding Print from base class
        {
            Console.WriteLine("3D-Vector: [" + x + "," + y + "," + z + "]");
        }
    }
}
