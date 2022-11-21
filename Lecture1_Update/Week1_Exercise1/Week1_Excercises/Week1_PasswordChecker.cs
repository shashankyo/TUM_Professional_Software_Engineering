// See https://aka.ms/new-console-template for more information
using System;
namespace ProSE
{
    public class MyFirstClass
    {
        public static void Main(string[] args)
        {
            string passWord = "Start123!";
            while (true)
            {
                Console.WriteLine("Hello! Please type in password to log in.");
                string inputPassword = Convert.ToString(Console.ReadLine());
                if (passWord == inputPassword)
                {
                    Console.WriteLine("Correct Password!");
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong Password, Try Again!");
                }
            }

        }


    }

}