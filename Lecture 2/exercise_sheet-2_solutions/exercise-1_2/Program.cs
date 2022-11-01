using System;

namespace PSWE
{
    class Lecture2
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a complex number: ");
            var x = Console.ReadLine();

            Complex c;

            bool works = Complex.TryParseComplex(x, out c);

            if (works) // checks if parsing worked or not
            {
                Console.WriteLine("Parsed successfully.");
            }
            else
            {
                Console.WriteLine("Parsing failed. Invalid complex number.");
            }
            Console.WriteLine("Norm: " + c.GetNorm());
            
        }
    } // Lecture2
} //PSWE