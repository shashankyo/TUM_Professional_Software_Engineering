using System;
using System.Linq;

namespace Koray
{
    class FirstClass
    {

        public static void Main(string[] args)
        {
            int[] inputArray = new int[3];

            inputArray[0] = Convert.ToInt32(Console.ReadLine());
            inputArray[1] = Convert.ToInt32(Console.ReadLine());
            inputArray[2] = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Your array is: ");
            foreach (var item in inputArray)
            {
                Console.WriteLine(item.ToString());
            }
            int min = inputArray.Min();

            Console.Write("Minimum value is :");
            Console.WriteLine(min);

        }
    }
}