using System;
    namespace Extraexcercises
{
    class MyFirstClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("if Leap Year.");
            Console.Write("Type in year:");
            int inputYear = Convert.ToInt32(Console.ReadLine());
            if (inputYear % 4 == 0)
            {
                Console.WriteLine(inputYear + " is a leap year.");
            }
            else
            {
                Console.WriteLine(inputYear + " is not a leap year");
            }
        }
    }
}