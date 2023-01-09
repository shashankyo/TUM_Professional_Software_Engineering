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


            Expense planeTickets = new Expense("Plane Tickets", 500, userPaul);
            Expense hotelExpense = new Expense("Hotel", 900, userGeorge);
            Expense beers = new Expense("Beers", 300, userPaul);
            Expense guitars = new Expense("Guitars", 1500, userPaul);



            hamburgSetup.Expenses.Add(planeTickets);
            hamburgSetup.Expenses.Add(hotelExpense);
            hamburgSetup.Expenses.Add(beers);
            hamburgSetup.Expenses.Add(guitars);


            foreach (var a in hamburgSetup.Users)
            {
                Console.WriteLine(a.Name);
            }

            //Console.WriteLine(hamburgSetup.NumberOfUsers);
            //Console.WriteLine(hamburgSetup.TotalExpenses()); 
            //Console.WriteLine(hamburgSetup.TotalShareOfExpenses());
            //hamburgSetup.UserOwesOwner(planeTickets);
            //hamburgSetup.UserStatus(userPaul);
            hamburgSetup.CurrentStand(hamburgSetup.Users);
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