using System;

class Program
{
    const int numberOfSteps = 1000_000;

    public static void Main(string[] args)
    {
        Console.WriteLine("Function\t | Elapsed Time\t\t | Estimated Pi");
        Console.WriteLine(new string('-', 60));

        Misc.Time(PiCalculators.SerialLinqPi, "S-Linq".PadRight(10), numberOfSteps);
        Misc.Time(PiCalculators.ParallelLinqPi, "P-Linq".PadRight(10), numberOfSteps);
        Misc.Time(PiCalculators.SerialPi, "S-For Loop", numberOfSteps);
        Misc.Time(PiCalculators.ParallelPi, "P-For Loop", numberOfSteps);
    }


}