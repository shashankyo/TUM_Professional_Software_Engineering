using System;
using System.Security.Cryptography.X509Certificates;

namespace ProSE
{
    class FirstClass
    {
        static void Main(string[] args)
        {

            /*
             *
             -- Assignment Objectives --
             * 1. Console Application, containing the following:
                • Main class and method
            -- Our Response --
            •Program Section of the Solution

                • Five functions that follow the use-cases you identified in Task 1. These functions should be
                    called in your main method 

            -- Our Response --
            • Create User / Add User
            • Create Setup
            • Create Expense / Add Expense
            • CurrentStatus (Current Debt Status, who owes who and how much...)
            • To Settle
            • Create Payment / Add Payment
            */
            Console.WriteLine("hello");

            User userJohn = new User("John");
            User userPaul = new User("Paul");
            User userGeorge = new User("George");
            User userRingo = new User("Ringo");

            List<User> users = new List<User>();
            users.Add(userJohn);
            users.Add(userPaul);
            users.Add(userGeorge);
            users.Add(userRingo);

            SetUp hamburgSetup = new SetUp("Hamburg", users);


            SetUp.Expense planeTickets = new SetUp.Expense("Plane Tickets", 600, userPaul);
            SetUp.Expense hotelExpense = new SetUp.Expense("Hotel", 900, userGeorge);
            SetUp.Expense beers = new SetUp.Expense("Beers", 300, userPaul);
            SetUp.Expense guitars = new SetUp.Expense("Guitars", 1500, userPaul);

            hamburgSetup.AddExpense(planeTickets);
            hamburgSetup.AddExpense(hotelExpense);
            hamburgSetup.AddExpense(beers);
            hamburgSetup.AddExpense(guitars);

            foreach (var a in hamburgSetup.debtMatrix)
            {
                Console.WriteLine(a.Key.Name);
                Console.WriteLine(a.Value);
            }

            hamburgSetup.CurrentStatus();


            //var list = hamburgSetup.SettleDebt();

            //Console.WriteLine("---------------------");
            //Console.WriteLine("---------------------");
            //Console.WriteLine("to settle the debts");
            //foreach (var a in list)
            //{
            //    Console.WriteLine($"{a.Item1} owes {a.Item2} {a.Item3} euro ");
            //}

            Console.WriteLine("---------------------");
            Console.WriteLine("---------------------");
            Console.WriteLine("new method Settle Debts");
            hamburgSetup.ToSettle();

            SetUp.Payment georgePayment = new SetUp.Payment(userJohn, userPaul, 1100);
            SetUp.Payment georgePayment2 = new SetUp.Payment(userRingo, userPaul, 1000);
            //SetUp.Payment georgePayment3 = new SetUp.Payment(userJohn, userRingo, 1100);

            hamburgSetup.AddPayment(georgePayment);
            hamburgSetup.AddPayment(georgePayment2);
            //hamburgSetup.AddPayment(georgePayment3);


            Console.WriteLine("---------------------");
            Console.WriteLine("---------------------");
            Console.WriteLine("after payment");
            hamburgSetup.ToSettle();

        }
    }
}