// See https://aka.ms/new-console-template for more information
using System;
namespace ProSE
{
    public class MyFirstClass
    {
        public static void Main(string[] args)
        {
            //1. Excercise : to tell if the input number is even or odd
            //Console.WriteLine("Hello, This is the first exercise from the first week of Professional Software Engineering Please type in any number, i'll check if it is even or odd");
            //var UserInput = Console.ReadLine();
            //var UserInputInt = Int32.Parse(UserInput);

            //if (UserInputInt % 2 == 0)
            //{
            //    Console.WriteLine(UserInputInt + " is an even number.");
            //}
            //else
            //{
            //    Console.WriteLine(UserInputInt + " is an odd number.");
            //}
            //2. Exercise : 
            // The Input Array of [1,2,3,4,5] multiply each number with 2 and return the new array, bonus sum of the all elements

            int[] InputArray = { 1, 2, 3, 4, 5 };
            int InputArrayLength = InputArray.Length;
            int[] OutputArray = new int[5];
            for (int i = 0; i < InputArrayLength; i++)
            {
               int item1 = InputArray[i] * 2;
               int item1Int = Convert.ToInt32(item1);
               OutputArray[i] = item1Int;
               Console.WriteLine(OutputArray[i]);
               

            }
            int sumOutputArray = OutputArray.Sum();
            Console.WriteLine(sumOutputArray+" is the sum of output array.");
            Console.WriteLine(InputArray[4]+" was the input array.");
            Console.WriteLine(OutputArray[4]+" is the output array.");
            Console.Write($"OutputArray: {string.Join(", ", OutputArray)}");
        }
           

    }

}