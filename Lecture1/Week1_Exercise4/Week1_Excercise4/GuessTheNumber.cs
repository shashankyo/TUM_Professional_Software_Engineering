// See https://aka.ms/new-console-template for more information
using System;
    namespace ProSE
{
    class MyFirstClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Guess The Number");
            Console.Write("Enter Number: ");
            int SecretNumber = 22;
            int InputNumber = Convert.ToInt32(Console.ReadLine());
            while (true)
            {
                if ( InputNumber == SecretNumber)
                {
                    Console.WriteLine(InputNumber + " is the secret number!");
                    break;
                }
                if ( InputNumber <= SecretNumber)
                {
                    Console.WriteLine(InputNumber + " is smaller than the secret number.");
                    return;
                }
                if ( InputNumber >= SecretNumber)
                {
                    Console.WriteLine(InputNumber + " is bigger than the secret number.");
                    return;
                }
            }
            return;

        }
    }
}
