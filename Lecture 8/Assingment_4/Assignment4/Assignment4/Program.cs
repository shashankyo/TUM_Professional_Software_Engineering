using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
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
            • To Settle (Which user needs to pay how much to whom in order to settle the debts)
            • Create Payment / Add Payment
            • Total Cost of the Setup
            • Cost of Setup for Each User

            */

            Console.WriteLine("----------------------");
            Console.WriteLine("-- Expense Splitter --");
            Console.WriteLine("----------------------");


            //• Create User / Add User

            User userJohn = new User("John",1);
            User userPaul = new User("Paul",2);
            User userGeorge = new User("George",3);
            User userRingo = new User("Ringo",4);

            List<User> users = new List<User>();
            users.Add(userJohn);
            users.Add(userPaul);
            users.Add(userGeorge);
            users.Add(userRingo);

            // • Create Setup
            SetUp hamburgSetup = new SetUp("Hamburg", users);

            //• Create Expense / Add Expense

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

             
            // • CurrentStatus(Current Debt Status, who owes who and how much...)

            hamburgSetup.CurrentStatus();

            Console.WriteLine("---------------------");
            Console.WriteLine("---------------------");

            //• To Settle(Which user needs to pay how much to whom in order to settle the debts)

            hamburgSetup.ToSettle();

            SetUp.Payment georgePayment = new SetUp.Payment(userJohn, userPaul, 1100);
            SetUp.Payment georgePayment2 = new SetUp.Payment(userRingo, userPaul, 1000);

            hamburgSetup.AddPayment(georgePayment);
            hamburgSetup.AddPayment(georgePayment2);



            Console.WriteLine("---------------------");
            Console.WriteLine("---After payments----");
            Console.WriteLine("---------------------");

            hamburgSetup.ToSettle();

            SetUp.Expense schnitzel = new SetUp.Expense("Schnitzel", 900, userRingo);
            hamburgSetup.AddExpense(schnitzel);
            Console.WriteLine("---------------------");
            Console.WriteLine("---After schnitzel---");
            Console.WriteLine("---------------------");


            hamburgSetup.ToSettle();
            hamburgSetup.TotalCost();
            hamburgSetup.CostForEachUser();

            
            
            Console.WriteLine("---------------------");
            hamburgSetup.CurrentStatus();
            Console.WriteLine("Final status is written in the database.");
            Console.WriteLine("---------------------");

            foreach (var i in hamburgSetup.debtMatrix)
            {
                var userdebtstatus = UserDebtStatus.CreateDebtStatus(i);
                DatabaseFramework.AddUserDebtStatus(userdebtstatus);
            }
        }
    }
}