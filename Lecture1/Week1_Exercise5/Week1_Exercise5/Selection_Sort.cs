// See https://aka.ms/new-console-template for more information
using System;
    namespace ProSE
{
    class MyFirstClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please type in 5 numbers");
            int input1 = Convert.ToInt32(Console.ReadLine());
            int input2 = Convert.ToInt32(Console.ReadLine());
            int input3 = Convert.ToInt32(Console.ReadLine());
            int input4 = Convert.ToInt32(Console.ReadLine());
            int input5 = Convert.ToInt32(Console.ReadLine());
            int[] inputArray = new int[] { input1, input2, input3, input4, input5 };
            Console.WriteLine("[{0}]", string.Join(", ", inputArray));
            int n = inputArray.Length;

            // One by one move boundary of unsorted subarray
            for (int i = 0; i < n - 1; i++)
            {
                // Find the minimum element in unsorted array
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                    if (inputArray[j] < inputArray[min_idx])
                        min_idx = j;

                // Swap the found minimum element with the first
                // element
                int temp = inputArray[min_idx];
                inputArray[min_idx] = inputArray[i];
                inputArray[i] = temp;

            }
            Console.WriteLine("[{0}]", string.Join(", ", inputArray));
        }
    }
}