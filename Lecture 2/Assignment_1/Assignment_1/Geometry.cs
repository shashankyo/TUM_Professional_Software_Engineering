using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public abstract class ImplicitGeometry
    {
    public abstract bool IsInside(double x, double y);

        public void Visualize(double xGrid, double yGrid)
        {
            Console.WriteLine("Visualized");
        }

    }
    public class Circle : ImplicitGeometry
    {
        public override bool IsInside(double x, double y)
        {
            return;
        }
        public double x;
        public double y;
        public double radius;
        public Circle(double x, double y, double radius)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
            Console.WriteLine("Circle has been made.");

        }

       

    }
}


