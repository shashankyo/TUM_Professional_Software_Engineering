using System;

namespace Lecture7
{
    class MainClass
    {
        public delegate T AdditionHandler<T>(T arg1, T arg2);

        // practically the same as a normal method (keep in mind they don't work in the same way as was shown in the lecture)
        public static string ConcatString(string first, string second) => first + second;
        public static double AddDouble(double first, double second) => first + second;
        public static int AddInt(int first, int second) => first + second;

        public static void Main(string[] argArray)
        {
            //setup 3 delegates for 3 data types and add the three methods to them
            AdditionHandler<string> ConcatStringHandler = ConcatString;
            AdditionHandler<double> AddDoubleHAndler = AddDouble;
            AdditionHandler<int> AddIntHandler = AddInt;

            // using the three delegates and printing the output to the console
            string firstString = "Professional Software ";
            string secondString = "development";
            System.Console.WriteLine($"Concatenating \"{firstString}\" and \"{secondString}\": ");
            System.Console.WriteLine(ConcatStringHandler(firstString, secondString));

            double firstDouble = 3.4;
            double secondDouble = 1.2;
            System.Console.WriteLine($"Adding \"{firstDouble}\" and \"{secondDouble}\": ");
            System.Console.WriteLine(AddDoubleHAndler(firstDouble, secondDouble));

            int firstInt = 3;
            int secondInt = 1;
            System.Console.WriteLine($"Adding \"{firstInt}\" and \"{secondInt}\": ");
            System.Console.WriteLine(AddIntHandler(firstInt, secondInt));
        }
    }
}