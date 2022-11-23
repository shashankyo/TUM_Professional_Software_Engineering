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

        //public double CalculateDotProduct();
        public void PrintNorm();
    }
    public class Vector2D<T> :IVector
    {
        public T x;
        public T y;

        public Vector2D(T x, T y)
        {
            this.x = x;
            this.y = y;
        }
    public double GetNorm()
        {
            var x = Conver
            double value = Math.Sqrt(x * x + y * y);
            return value;
        }
        public void PrintNorm()
        {
            Console.WriteLine(GetNorm());
        }
        public double CalculateDotProduct(Vector2D<T> otherVector)
        {
            return this.x * otherVector.x + this.y * otherVector.y;
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
        public double CalculateDotProduct(Vector3D otherVector)
        {
           return this.x * otherVector.x + this.y * otherVector.y + this.z * otherVector.z;

        }

    }
    
}
