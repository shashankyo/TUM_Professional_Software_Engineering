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
    public class UserDebtStatus
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public decimal DebtStatus { get; set; }

        public UserDebtStatus(string userName, decimal debtStatus, int id)
        {
            UserName = userName;
            Id = id;
            DebtStatus = debtStatus;
        }

        public static UserDebtStatus CreateDebtStatus(KeyValuePair<User, decimal> a)
        {

            string username = a.Key.Name;
            decimal debt = a.Value;
            int id = a.Key.Id;
            
            UserDebtStatus userDebtStatus = new UserDebtStatus(username, debt, id);
            return userDebtStatus;
            
        }

    }
}
