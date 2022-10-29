using ProSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProSe
{
    class Class1
    {
        public static void Main(string[] args)
        {
            ComplexNumber case1 = new ComplexNumber(3, 4);
            Console.WriteLine(case1.GetNorm());

        }
    }
}
