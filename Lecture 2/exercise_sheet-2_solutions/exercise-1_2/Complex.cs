namespace PSWE
{
    class Complex
    {
        public double Real { get; set;  }
        public double Imaginary { get; set; }

        public Complex(double real, double imaginary) // constructor
        {
            this.Real = real;
            this.Imaginary = imaginary;
        }

        // Member functions or methods
        public double GetNorm()
        {
            return Math.Sqrt(
                Math.Pow(Real, 2) + Math.Pow(Imaginary, 2)
            );
        }

        //Static methods
        public static Complex CreateComplexValue(double real, double imaginary)
        {
            return new Complex(real, imaginary);
        }

        public static bool TryParseComplex(string userInput, out Complex complexUserInput)
        {
            double real = 0;
            double imaginary = 0;

            bool isValid = Complex.IsValidComplex(userInput, out real, out imaginary); // getting real and imaginary values by passing them as reference

            complexUserInput = new Complex(real, imaginary);

            return isValid;
        }

        private static bool IsValidComplex(string userInput, out double real, out double imaginary)
        {
            bool validReal = false, validImaginary = false;

            real = 0;
            imaginary = 0;

            string cleanedUserInput = userInput.Replace(" ", ""); // cleaning whitespaces from the input string

            int operatorIndex = Complex.IndexOfOperator(cleanedUserInput);
            if (operatorIndex != -1) // checks if operator '+' or '-' is found
            {
                // if found try parsing both real and imaginary parts
                string realAsString = cleanedUserInput.Substring(
                        0, operatorIndex
                    );
                string imaginaryAsString = cleanedUserInput.Substring(
                        operatorIndex + 1, cleanedUserInput.Length - operatorIndex - 2
                    );

                validReal = double.TryParse(
                        realAsString, out real
                    );

                validImaginary = double.TryParse(
                        imaginaryAsString, out imaginary
                    );
            }
            else
            {
                int iIndex = IndexOfI(cleanedUserInput);
                if (iIndex == -1) // checks if 'i' or 'I' is found
                {
                    // if 'i' is not found, input could be real so try parsing only real part
                    string realAsString = cleanedUserInput;
                    validReal = double.TryParse(
                            realAsString, out real
                        );
                    validImaginary = true;
                }
                else // if found, try parsing as imaginary
                {
                    string imaginaryAsString = cleanedUserInput.Substring(
                            0, cleanedUserInput.Length - iIndex
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
            int index = userInput.IndexOf('i');

            if (index == -1) // if 'i' not found, search for 'I'
            {
                index = userInput.IndexOf('I');
            }

            return index;
        }
    } // Complex
} //PSWE