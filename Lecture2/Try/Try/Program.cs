using System;
namespace Koray
{
    class MyFirstClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please type in a number");
            string userInput = Convert.ToString(Console.ReadLine());
            Int32.TryParse(userInput, out int result);
            Console.WriteLine(result);

        }
    }
}