using System;
using System.Numerics;

namespace ProSE
{

    class ComplexNumber
    {
        public double real;
        public double imaginary;

    

        public ComplexNumber(double real, double imaginary)
        {

            this.real = real;
            this.imaginary = imaginary;
            
        }
        public double GetNorm()
        {
            var XX = Math.Sqrt(real * real + imaginary * imaginary);
            return XX;

        }
        public static bool TryParseComplex(string userInput, out ComplexNumber complexUserInput)
        {
            double real = 0;
            double imaginary = 0;

            bool isValid = ComplexNumber.IsValidComplex(userInput, out real, out imaginary);
            complexUserInput = new ComplexNumber(real, imaginary);

            return isValid;

        }
        private static bool IsValidComplex(string userInput, out double real, out double imaginary)
        {
            real = 0;
            imaginary = 0;
            bool validReal = false, validImaginary = false;

            string cleanUserInput = userInput.Replace(" ", "");
            int operatorIndex = ComplexNumber.IndexOfOperator(cleanUserInput);
            if (operatorIndex != -1)
            {
                string realAsString = cleanUserInput.Substring(0, operatorIndex);
                string imaginaryAsString = cleanUserInput.Substring(operatorIndex + 1 , cleanUserInput.Length - 1);

                validReal = double.TryParse(realAsString, out real);
                validImaginary = double.TryParse(imaginaryAsString, out imaginary);

            }

            else
            {
                int iIndex = IndexOfI(cleanUserInput);
                if (iIndex == -1) // checks if 'i' or 'I' is found
                {
                    // if 'i' is not found, input could be real so try parsing only real part
                    string realAsString = cleanUserInput;
                    validReal = double.TryParse(
                            realAsString, out real
                        );
                    validImaginary = true;
                }
                else // if found, try parsing as imaginary
                {
                    string imaginaryAsString = cleanUserInput.Substring(
                            0, cleanUserInput.Length - iIndex
                        );
                    validReal = true;
                    validImaginary = double.TryParse(
                            imaginaryAsString, out imaginary
                        );
                }
            }

            return validReal && validImaginary;
        }
        private static int IndexOfOperator(string userInput) 
        {
            int index = userInput.IndexOf('+');

            if (index == -1) // if '+' not found, search for '-'
            {
                index = userInput.IndexOf('-');
            }

            return index;
        }
        private static int IndexOfI(string userInput)
            {
                int index = userInput.IndexOf("i");
                if (index == -1)
                {
                    index = userInput.IndexOf("I");
                }
                return index;
            }
        // private static bool IsValidComplex(string userInput , out double real , out double imaginary)
    }
}