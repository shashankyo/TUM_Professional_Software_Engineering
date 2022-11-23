using System;
        namespace Exercise
    {
        class myFirstClass
        {
            public static void Main(string[] args)
            {
                Console.WriteLine("if Number Contains the Digit 3");
                Console.Write("Please type in the number: ");
                int inputNumber = Convert.ToInt32(Console.ReadLine());
                    while (inputNumber > 0)
                {
                if (inputNumber % 10 == 3)
                {
                    Console.WriteLine(inputNumber + " has 3 in its digits.");
                    break;
                }
                else
                {
                    Console.WriteLine(inputNumber + " does not have 3 in its digits.");
                    break;

                }
            }

            }
        }
    }
