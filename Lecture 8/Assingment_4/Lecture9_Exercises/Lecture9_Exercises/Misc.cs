using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ex1
{
    static class Misc
    {
        public static void Time(
            Func<int, double> piCalculator, string functionName, int numberOfTimeSteps
            )
        {
            var stopwatch = Stopwatch.StartNew();
            var pi = piCalculator(numberOfTimeSteps);

            Console.WriteLine($"{functionName}\t | {stopwatch.Elapsed}\t | {pi}");
        }
    }
}
