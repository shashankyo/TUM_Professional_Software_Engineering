using System;
namespace ProSE
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please type in complex number");
            var userInput = Console.ReadLine();
            ComplexNumber c;

            bool isInputCorrect = ComplexNumber.TryParseComplex(userInput, out c);

            if (isInputCorrect)
            {
                Console.WriteLine("Parsed Succesfully.");
            }
            else
            {
                Console.WriteLine("Parsing failed. Invalid input");
            }
            Console.WriteLine("Norm: " + c.GetNorm());
        }
    }
}