using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProSE_Assignment1
{
    public abstract class ImplicitGeometry
    {
        public abstract bool IsInside(double x, double y);

        public void Visualize(double xGrid, double yGrid)
        {
            // char gridChar = '.';
            for (double y = yGrid - 1; y >= 0; y--)
            {

                for (int x = 0; x < xGrid; x++)
                {
                    Console.Write($"({x},{y})");
                }
                Console.Write('\n');
            }
        }
    }
    //public class Circle : ImplicitGeometry
    //{
    //    public double xCenter;
    //    public double yCenter;
    //    public double radius;
    //    public override bool IsInside(double x, double y)
    //    {
    //        return Math.Sqrt(x * x + y * y);
    //    }
    //    public Circle(double xCenter, double yCenter, double radius)
    //    {
    //        this.xCenter = xCenter;
    //        this.yCenter = yCenter;
    //        this.radius = radius;
    //    }
    //}
    public class Rectangle : ImplicitGeometry
    {
        public double x1;
        public double x2;
        public double y1;
        public double y2;


        public Rectangle(double x1, double x2, double y1, double y2)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.y2 = y2;
        }
        public override bool IsInside(double x, double y)
        {
         Math.
    }
    //public abstract class Operation : ImplicitGeometry
    //{
    //    public abstract ImplicitGeometry Operation();

    //}
}
}


