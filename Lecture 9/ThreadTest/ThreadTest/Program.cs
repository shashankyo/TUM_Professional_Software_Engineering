using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Thread Safe Program");

            MyClass mc = new MyClass();

            Thread t1 = new Thread(mc.printVariables);
            t1.Start(1);

            mc.printVariables(2);

            mc.printVariables(3);
        }
    }
}
