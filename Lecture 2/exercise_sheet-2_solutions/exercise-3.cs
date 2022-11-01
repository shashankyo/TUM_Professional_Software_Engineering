/* This program returns factorial of a non-negative number.
        * It takes user input from console, checks if it is non-negative.
        * Compute: n! = n*(n-1)! = n*(n-1)*...*3*2*1 (recursively)
        * Special case: 0! = 1  */
using System;
namespace Lecture2
{
    class FactorialExercise
    {
        // a function named 'Factorial' is defined which takes one integer-type input and returns an integer-type value
        public static int Factorial(int number) // 'static' so that a class object isn't required when calling this
        {
            if (number == 0)
                return 1; // 0! = 1
            else
                return number * Factorial(number - 1); // n! = n*(n-1)!
        }
        public static void Main()
        {
            Console.Write("Enter a number: ");
            int inputNumber = Convert.ToInt32(Console.ReadLine()); // reading and converting user input
           
            while(inputNumber < 0) // check for negative numbers
            {
                Console.Write("Number shouldn't be negative.\nEnter a number: ");
                inputNumber = Convert.ToInt32(Console.ReadLine());
            }

            int result = FactorialExercise.Factorial(inputNumber); // function call to 'Factorial' defined above 
            Console.WriteLine(inputNumber + "! is " + result);
        }
    } // FactorialExercise
} // Lecture2