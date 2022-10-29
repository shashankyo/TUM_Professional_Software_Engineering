using System;
namespace ProSE
{
    public abstract class Vector
    {
        public double x;
        public double y;
        public double z;


        public abstract double GetNorm();
    }
}