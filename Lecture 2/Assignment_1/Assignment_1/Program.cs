using Assignment_1;
using System;
namespace ProSE_Assignment1
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hey!");
            Circle c1 = new Circle(0, 0, 2);
            c1.Visualize(3, 4);
        }
    }
}