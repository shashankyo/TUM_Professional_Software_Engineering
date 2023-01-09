using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProSE
{

    public class SetUp
    {
        public string Name { get; set; }

        public List<User> Users { get; set; }

        public int NumberOfUsers { get; set; }

        public List<Expense> Expenses { get; set; }
        public SetUp(string Name, List<User> Users)
        {
            this.Name = Name;
            this.Users = Users;
            this.NumberOfUsers = Users.Count;
            this.Expenses = new List<Expense>();
        }
        //public List<User> GetUserList()
        //{
        //    List<User> userList = new List<User>();

        //    return userList;
        //}
        public List<User> AddUser(User user1)
        {
            List<User> userList = new List<User>();
            userList.Add(user1);
            return userList;
        }
        public double TotalExpenses()
        {
            float SumOfExpenses = 0;
            foreach (Expense expense in Expenses)
            {
                SumOfExpenses = SumOfExpenses + expense.Amount;
            }
            return SumOfExpenses;
        }
        public int GetUserCount()
        {
            return Users.Count;
        }
        public double TotalShareOfExpenses()
        {
            double a = 0;

            a= TotalExpenses()/ this.NumberOfUsers;
            return a;
        }
        public void UserOwesOwner(Expense expense)
        {
            List<User> otherUsers = new List<User>();
            foreach(var i in this.Users)
            {
                if (i != expense.Owner)
                {
                    otherUsers.Add(i);
                }
                else
                {  
                }
            }
            float eachShare = expense.Amount / this.NumberOfUsers;

            foreach (var i in otherUsers)
            {
                Console.WriteLine($"{i.Name} owes {expense.Owner.Name} {eachShare}");
            }

        }
        public List<User> OtherUsers(Expense expense)
        {
            List<User> otherUsers = new List<User>();
            foreach (var i in this.Users)
            {
                if (i != expense.Owner)
                {
                    otherUsers.Add(i);
                }
            }
            return otherUsers;
        }
        public List<User> OtherUsers(User user)
        {
            List<User> otherUsers = new List<User>();
            foreach (var i in this.Users)
            {
                if (i != user)
                {
                    otherUsers.Add(i);
                }
            }
            return otherUsers;
        }
        public float EachShare(Expense expense)
        {
            float eachShare = expense.Amount / this.NumberOfUsers;
            return eachShare;
        }
        public float TotalEachShare(List<Expense> expenses)
        {
            float totalAmount = 0;
            foreach (var i in expenses)
            {
                totalAmount = totalAmount + i.Amount;
            }
            float totalEachShare = totalAmount / this.NumberOfUsers;
            return totalEachShare;
        }
        public void UserStatus(User user)
        {
            double hasPaid = 0;
            foreach(var i in this.Expenses)
            {
                if( i.Owner == user)
                {
                    hasPaid = hasPaid + i.Amount;
                }
            }
            Console.WriteLine($"{user.Name} has paid {hasPaid} his share was {TotalEachShare(this.Expenses)}");
            double theDifference = hasPaid - TotalEachShare(this.Expenses);
            if (theDifference > 0)
            {
                Console.WriteLine($"{user.Name} has been owed {theDifference}");

                var differenceShare = theDifference / this.NumberOfUsers;
                var a = OtherUsers(user);
                foreach (var i in a)
                {
                    Console.WriteLine($"{i.Name} owes {differenceShare}");
                }
                
            }
            else
            {
                Console.WriteLine($"{user.Name} owes someone {Math.Abs(theDifference)}");
            }
        }
        public void CurrentStand(List<User> users)
        {
            foreach(var i in users)
            {
                UserStatus(i);
            }
        }

        //public static SetUp CreateSetUp(string Name, List<User> Users)
        //{
        //    SetUp setup = new SetUp();
        //    Name = setup.Name;
        //    Users = setup.Users;
        //    return setup;
        //}
        // WIP
        //public SetUp CreateSetUp()
        //{

        //    SetUp newSetup = new SetUp();

        //    return newSetup;
        //}

    }
    public class User
    {
        public string Name { get; set; }
        
        public User(string Name)
        {
            this.Name = Name;
        }
    }
    public class Expense
    {
        public string Name { get; set; }
        public float Amount { get; set; }

        public User Owner { get; set; }

        public Expense(string name, float amount, User owner)
        {
            Name = name;
            Amount = amount;
            Owner = owner;
   
        }
    }
}
