using ProSE;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static ProSE.SetUp;

namespace ProSE
{
    public class User
    {
        public string Name { get; set; }

        public User(string Name)
        {
            this.Name = Name;
        }

    }
    public class SetUp
    {
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public Dictionary<User, decimal> debtMatrix = new Dictionary<User, decimal>();
        public int NumberOfUsers { get; set; }
        public List<Expense> Expenses { get; set; }
        public SetUp(string Name, List<User> Users)
        {
            this.Name = Name;
            this.Users = Users;
            this.NumberOfUsers = Users.Count;
            this.Expenses = new List<Expense>();
        }

        public void AddUser(User user)
        {
            // Add the participant to the list of participants
            Users.Add(user);
            // Initialize the participant's debt to zero
            debtMatrix.Add(user, 0);
        }
        public class Expense
        {
            public string Name { get; set; }
            public decimal Amount { get; set; }
            public User Owner { get; set; }
            public List<User> Payees { get; set; } = new List<User>();
            public Expense(string name, decimal amount, User owner)
            {
                Name = name;
                Amount = amount;
                Owner = owner;
            }
        }
        public void AddExpense(Expense expense)
        {
            List<User> otherUsers = OtherUsers(expense);
            expense.Payees = otherUsers;
            Expenses.Add(expense);

            // Add the expense amount to the payer's debt
            // negative values means that the user is owed
            AddDebt(expense.Owner, -expense.Amount);
            // Divide the expense amount among the payees and add it to their debt
            // positive values means the user owes someone
            decimal share = expense.Amount / otherUsers.Count;
            foreach (var payee in otherUsers)
            {
                AddDebt(payee, share);
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
        private void AddDebt(User participant, decimal amount)
        {
            // Check if the participant is already in the debtMatrix
            if (debtMatrix.ContainsKey(participant))
            {
                debtMatrix[participant] += amount;
            }
            else
            {
                debtMatrix.Add(participant, amount);
            }
        }

        public void CurrentStatus()
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("-Current Debt Status-");
            Console.WriteLine("---------------------");

            foreach (var i in debtMatrix)
            {
                if (i.Value >= 0)
                {
                    Console.WriteLine($"{i.Key.Name} owes {Math.Abs(i.Value)} euro");
                }
                else if (i.Value < 0)
                {
                    Console.WriteLine($"{i.Key.Name} is owed {Math.Abs(i.Value)} euro");

                }
            }
        }

        public void ToSettle()
        {
            // Grouping the debtors and creditors
            var owed = new List<(User, decimal)>();
            var owes = new List<(User, decimal)>();

            foreach (var item in debtMatrix)
            {
                if (item.Value < 0)
                    owed.Add((item.Key, item.Value));
                else
                    owes.Add((item.Key, item.Value));
            }


            // Sorting the lists
            owed = owed.OrderByDescending(t => Math.Abs(t.Item2)).ToList();
            owes = owes.OrderByDescending(t => t.Item2).ToList();


            // Check This part later!!
            var settledTransactions = new List<(User, User, decimal)>();
            int i = 0;
            int j = 0;
            while (i < owed.Count && j < owes.Count)
            {
                decimal amount = Math.Min(Math.Abs(owed[i].Item2), owes[j].Item2);
                if (amount > 0)
                {
                    settledTransactions.Add((owed[i].Item1, owes[j].Item1, amount));
                    owed[i] = (owed[i].Item1, owed[i].Item2 + amount);
                    owes[j] = (owes[j].Item1, owes[j].Item2 - amount);
                    if (owes[j].Item2 == 0)
                        j++;
                    if (owed[i].Item2 == 0)
                        i++;
                }
            }
            Console.WriteLine("To settle the debts:");
            foreach (var trans in settledTransactions)
            {
                Console.WriteLine("From: " + trans.Item2.Name + "  To: " + trans.Item1.Name + "  Amount: " + trans.Item3);
            }
        }

        public class Payment
        {
            public User Payer { get; set; }

            public User Payee { get; set; }

            public decimal Amount { get; set; }

            public Payment(User payer, User payee, decimal amount)
            {
                this.Payer = payer;
                this.Payee = payee;
                this.Amount = amount;
            }

        }
        public void AddPayment(Payment payment)
        {

            if (debtMatrix.ContainsKey(payment.Payee) && debtMatrix.ContainsKey(payment.Payer))
            {
                debtMatrix[payment.Payer] += -payment.Amount;
                debtMatrix[payment.Payee] += payment.Amount;
            }
            else
            {
                debtMatrix.Add(payment.Payer, -payment.Amount);
                debtMatrix.Add(payment.Payee, payment.Amount);
            }
        }
    }

    public class UserDebtStatus
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public decimal DebtStatus { get; set; }

        //public string SetUpName { get; set; }

        public UserDebtStatus(string userName, decimal debtStatus)
        {
            UserName = userName;

            DebtStatus = debtStatus;
        }

        public static UserDebtStatus CreateDebtStatus(KeyValuePair<User, decimal> a)
        {
            //string a = Di

            string username = a.Key.Name;
            decimal debt = a.Value;
            
            UserDebtStatus userDebtStatus = new UserDebtStatus(username, debt);
            return userDebtStatus;
            
        }

    }
}
