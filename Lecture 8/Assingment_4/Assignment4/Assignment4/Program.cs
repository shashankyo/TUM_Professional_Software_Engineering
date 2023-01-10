using System;
using System.Security.Cryptography.X509Certificates;

namespace ProSE
{
    class FirstClass
    {
        static void Main(string[] args)
        {
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

            //Console.WriteLine(hamburgSetup.GetTransactions());
            foreach (var a in hamburgSetup.debtMatrix)
            {
                Console.WriteLine(a.Key.Name);
                Console.WriteLine(a.Value);
            }


            var list = hamburgSetup.SettleDebt();

            Console.WriteLine("---------------------");
            Console.WriteLine("---------------------");
            Console.WriteLine("to settle the debts");
            foreach (var a in list)
            {
                Console.WriteLine($"{a.Item1} owes {a.Item2} {a.Item3} euro ");
            }
            SetUp.Payment georgePayment = new SetUp.Payment(userGeorge, userJohn, 100);
            SetUp.Payment georgePayment2 = new SetUp.Payment(userGeorge, userRingo, 100);
            SetUp.Payment georgePayment3 = new SetUp.Payment(userJohn, userRingo, 1100);

            hamburgSetup.AddPayment(georgePayment);
            hamburgSetup.AddPayment(georgePayment2);
            hamburgSetup.AddPayment(georgePayment3);

            var list2 = hamburgSetup.SettleDebt();

            Console.WriteLine("---------------------");
            Console.WriteLine("---------------------");
            Console.WriteLine("after payment");
            foreach (var a in list2)
            {
                Console.WriteLine($"{a.Item1} owes {a.Item2} {a.Item3} euro ");
            }
            //foreach (var a in hamburgSetup.Users)
            //{
            //    Console.WriteLine(a.Name);
            //}

            //Console.WriteLine(hamburgSetup.NumberOfUsers);
            //Console.WriteLine(hamburgSetup.TotalExpenses()); 
            //Console.WriteLine(hamburgSetup.TotalShareOfExpenses());
            //hamburgSetup.UserOwesOwner(planeTickets);
            //hamburgSetup.UserStatus(userPaul);
            //hamburgSetup.CurrentStand(hamburgSetup.Users);

            //foreach(User user in userList)
            //{
            //    Console.WriteLine(user.Name);
            //}
            //SetUp Hamburg = SetUp.CreateSetUp("Hamburg", userList);
            //foreach (var user in Hamburg.Users)
            //{
            //    Console.WriteLine(user.Name);
            //}
        }
    }
}