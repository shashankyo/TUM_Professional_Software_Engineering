using System;
using System.ComponentModel;
using System.Runtime.ExceptionServices;

namespace ProSE
{
    class Program
    {
        public delegate T AdditionHandler<T>(T firstArg, T secondArg);
        public static int Add(int firstArg, int secondArg) {

            return firstArg + secondArg;
        }
        public static string Add(string firstArg, string secondArg) {

            return firstArg + secondArg;
        }
        public static double Add(double firstArg, double secondArg) {

            return firstArg + secondArg;
        }


        public static void Main(string[] args)
        {

            // Normal Delegation with Legit Methods
            //Console.WriteLine("Main program..");
            //AdditionHandler<int> del1 = new AdditionHandler<int>(Add);
            //AdditionHandler<string> del2 = new AdditionHandler<string>(Add);
            //AdditionHandler<double> del3 = new AdditionHandler<double>(Add);

            //var resultDel1 = del1(1, 2);
            //var resultDel2 = del2("Koray", " Inal");
            //var resultDel3 = del3(2.31, -3.31);

            //Console.WriteLine(resultDel1);
            //Console.WriteLine(resultDel2);
            //Console.WriteLine(resultDel3);

            // Delegation with Lambda
            AdditionHandler<int> del1_l = (a,b) => a + b;
            AdditionHandler<string> del2_l = (a, b) => a + b;
            AdditionHandler<double> del3_l = (a, b) => a + b;

            var resultDel1 = del1_l(1, 2);
            var resultDel2 = del2_l("Koray", " Inal");
            var resultDel3 = del3_l(2.31, -3.31);

            Console.WriteLine(resultDel1);
            Console.WriteLine(resultDel2);
            Console.WriteLine(resultDel3);

        }
    }
}