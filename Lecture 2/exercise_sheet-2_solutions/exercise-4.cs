using System;

namespace Lecture2
{
    class Point
    {
        public double x, y;
        public Point(double X, double Y) // constructor
        {
            this.x = X;
            this.y = Y;
        }
    } // Point
    class Program
    {
        public static void ReplacePoint(Point a, Point b) // passing by value
        {
            a = b;
        }
        public static void ReplacePoint(ref Point a, Point b) // passing by reference, overload for the above function 
        {
            a = b;
        }
        public static void Main()
        {
            Point firstPoint = new Point(0, 0);
            Point secondPoint = new Point(1, 1);

            Console.WriteLine("Original: (" + firstPoint.x + "," + firstPoint.y + ")");
            Program.ReplacePoint(firstPoint, secondPoint);
            Console.WriteLine("Modified (pass by value): (" + firstPoint.x + "," + firstPoint.y + ")");
            Program.ReplacePoint(ref firstPoint, secondPoint);
            Console.WriteLine("Modified (pass by reference): (" + firstPoint.x + "," + firstPoint.y + ")");
        }
    } // Program
} // Lecture2

