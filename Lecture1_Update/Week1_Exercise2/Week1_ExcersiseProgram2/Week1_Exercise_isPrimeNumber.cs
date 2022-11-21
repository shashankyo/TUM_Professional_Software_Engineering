// See https://aka.ms/new-console-template for more information
using System;
    namespace ProSE
    {
        class MyFirstClass
        {
            static void Main(string[] args)
            {
            Console.Write("Enter a Number : ");
            int number = int.Parse(Console.ReadLine());
            int i = 2;
            bool isPrime = true;
            do
            {
                if (number % i == 0)
                {
                    //Console.WriteLine("Burda");
                    isPrime = false;
                    Console.WriteLine(number + " is not a prime number.");
                    //break;

                }
                else
                {
                    Console.WriteLine(number + " is a prime number.");
                }

                i++;
            }
            while (i <= number/2);

            if (isPrime)
            {
                Console.WriteLine(number + " is a prime number.");
            }
            else
            {
                Console.WriteLine(number + " is not a prime number.");
            }
        }

        }
    }