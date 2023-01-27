using System;
using System.Diagnostics;

static class Misc
{
    public static void Time(
        Func<int, double> piCalculator,
        string functionName, int numberOfSteps)
    {
        var stopWatch = Stopwatch.StartNew();
        var pi = piCalculator(numberOfSteps);
        Console.WriteLine($"{functionName}\t | {stopWatch.Elapsed}\t | {pi}");
    }
}