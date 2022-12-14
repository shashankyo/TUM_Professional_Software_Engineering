// See https://aka.ms/new-console-template for more information
using System;
    namespace ProSE
{
    class MyFirstClass
    {
        public static void Main(string[] args)
        {
            // Tax Percantages and Salary Limits
            int[] limit1 = {10000, 0};
            int[] limit2 = {50000, 25};
            int[] limit3 = {220000, 42};
            int[] salaries = { 15000, 30000, 85000, 250000, 5000 };
            int[] taxRates = new int[5];
            for (int i = 0; i < salaries.Length; i++)
            {
                int check = salaries[i];
                if (check <= limit1[0])
                {
                    taxRates[i] = limit1[1];
                }
                else if (check <= limit2[0])
                {
                    taxRates[i] = limit2[1];
                }
                else if (check <= limit3[0])
                {
                    taxRates[i] = limit3[1];
                }
                else
                    taxRates[i] = 45;
            }
            Console.WriteLine(taxRates[0]);
            Console.WriteLine(taxRates[1]);
            Console.WriteLine(taxRates[2]);
            Console.WriteLine(taxRates[3]);
            Console.WriteLine(taxRates[4]);
        }
    }
}