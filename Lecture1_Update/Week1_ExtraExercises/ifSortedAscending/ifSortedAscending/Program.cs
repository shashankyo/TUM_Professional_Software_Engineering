using System;
    namespace MyNameSpace
{
    class MyFirstClass
    {
        public static void Main(string[] args)
        {
            int[] inputArray = new int[3];
            Console.WriteLine("Type in 3 numbers:");
            inputArray[0] = Convert.ToInt32(Console.ReadLine());
            inputArray[1] = Convert.ToInt32(Console.ReadLine());
            inputArray[2] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Input Array is: " + string.Join(",", inputArray));
            bool isSorted = true;
            for (int i=0; i <inputArray.Length -1; i++)
            {
                if (inputArray[i] > inputArray[i+1])
                {
                    isSorted = false;
                }
            }
        
            if (isSorted == true)
            {
                Console.WriteLine((string.Join(",", inputArray) + " given order of numbers are in an ascending order."));

            }
            else
            {
                Console.WriteLine((string.Join(",", inputArray) + " given order of numbers are not in an ascending order."));
            }
            


        }
    }
}