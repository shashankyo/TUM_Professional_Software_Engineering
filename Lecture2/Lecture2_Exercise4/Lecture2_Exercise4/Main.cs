using ProSE;
using System;
namespace ProSE
{


    class MyFirstClass
    {
        public static void Main(string[] args)
        {
            Point point1 = new Point(12, 20);
            Point point2 = new Point(3, 31);
            Console.WriteLine("Start Points:");
            Console.WriteLine($"Point1 has: {point1.x}, {point1.y}");
            Console.WriteLine($"Point2 has: {point2.x}, {point2.y}");
            ChangerByReference(point1, point2);
            ChangerByValue(point1, point2);
        }
        public static void Changer(ref Point firstpoint, ref Point secondpoint) // Reference
        {
            firstpoint = secondpoint;
            secondpoint = new Point(firstpoint.x, firstpoint.y);
            Console.WriteLine("ChangerByReference");
            Console.WriteLine($"Point1 has: {firstpoint.x}, {firstpoint.y}");
            Console.WriteLine($"Point2 has: {secondpoint.x}, {secondpoint.y}");

        }
        public static void ChangerByValue(Point firstpoint, Point secondpoint) //Value
        {
            Point temppoint = firstpoint; // 12, 20
            firstpoint = secondpoint; // 3, 31
            Console.WriteLine($"Point1 has: {firstpoint.x}, {firstpoint.y}"); // 3, 31
            firstpoint = temppoint; // 3, 31 dedi bilal
            //temppoint = new Point(100, 500);
            secondpoint = temppoint;

            Console.WriteLine("ChangerByValue");
            Console.WriteLine($"Point1 has: {firstpoint.x}, {firstpoint.y}"); // 3, 31 gelicek diyorum.
            Console.WriteLine($"Point2 has: {secondpoint.x}, {secondpoint.y}"); // 100, 500 basıcak
            Console.WriteLine($"Temppoint has: {temppoint.x}, {temppoint.y}"); // 100, 500 basıcak
        }
    }
}