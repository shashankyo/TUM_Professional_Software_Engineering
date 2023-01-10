using ProSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
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
            AddDebt(expense.Owner, -expense.Amount);
            // Divide the expense amount among the payees and add it to their debt
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
        public List<Tuple<string, string, decimal>> SettleDebt()
        {
            List<Tuple<string, string, decimal>> transactions = new List<Tuple<string, string, decimal>>();

            // sort the dictionary by debt
            var debtList = debtMatrix.OrderBy(d => Math.Abs(d.Value)).ToList();

            for (int i = 0; i < debtList.Count; i++)
            {
                for (int j = i + 1; j < debtList.Count; j++)
                {
                    var payer = debtList[i];
                    var payee = debtList[j];
                    decimal amount = Math.Min(Math.Abs(payer.Value), payee.Value);
                    // only pay if payer owe more than 0
                    if (amount > 0)
                    {
                        // add transaction
                        transactions.Add(new Tuple<string, string, decimal>(payer.Key.Name, payee.Key.Name, amount));
                        debtMatrix[payer.Key] += amount;
                        debtMatrix[payee.Key] -= amount;
                    }
                }
            }
            return transactions;
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
            this.debtMatrix[payment.Payer] += -payment.Amount;
            this.debtMatrix[payment.Payee] += payment.Amount;
            //if (debtMatrix.ContainsKey(payment.Payee) && debtMatrix.ContainsKey(payment.Payer))
            //{
            //    debtMatrix[payment.Payer] += -payment.Amount;
            //    debtMatrix[payment.Payee] += payment.Amount;
            //}
            //else
            //{
            //    debtMatrix.Add(payment.Payer, -payment.Amount);
            //    debtMatrix.Add(payment.Payee, payment.Amount);
            //}
        }
    }
}
