using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSE
{
    public abstract class Vector
    {
        public double x;
        public double y;
        public double z;
        public abstract double GetNorm();
        //public abstract double GetDotProduct();
        //public abstract string PrintVector();

        public virtual void PrintVector()
        {
            Console.WriteLine("VectorCoordinates");
        }
        //public double GetDotProduct()
        //{

        //}
    }


}
