using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ProSE
{
    public class DatabaseFramework
    {

        public static void AddUserDebtStatus(UserDebtStatus userDebtStatus)
        {

            // Create a database
            // dotnet ef migrations add InitialCreate
            // dotnet ef database update

            using (var context = new UserDebtStatusContext())
            {
                context.DebtStatuses.Add(userDebtStatus);
                context.SaveChanges();
            }
        }

    }
}
