using System;
using System.IO.IsolatedStorage;
using System.Security.Cryptography.X509Certificates;

namespace ProSE
{
    class MyFirstClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Factorial Program");
            Console.WriteLine("Please type in number: ");
            int userInput = Convert.ToInt32(Console.ReadLine());
            bool IsUserInputValid = true;
            if (userInput <= 0)
            {
                IsUserInputValid = false;
            }
            else
            {
                IsUserInputValid = true;
            }
            if (IsUserInputValid == true)

            {
                Factorial(userInput);
                Console.WriteLine(Factorial(userInput));
            }
            else
            {
                Console.WriteLine("Type in a valid number!");
            }
        }
        public static double Factorial(int number)
        {
            if (number == 0)
            {
                return 1;

            }
            else
            {
                double factorial = 1;
                for (int i = number; i >= 1; i--)
                {
                    factorial = factorial * i;

                }
                return factorial;

            }

        }
    }
}