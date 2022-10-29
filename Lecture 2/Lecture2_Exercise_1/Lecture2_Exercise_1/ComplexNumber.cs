using ProSE;
using System;
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
    }
}