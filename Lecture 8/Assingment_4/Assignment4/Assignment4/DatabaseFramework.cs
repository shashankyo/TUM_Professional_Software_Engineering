using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSE
{
    public class DatabaseFramework
    {
        //public static void AddSetup(SetUp setup)
        //{
        //    using (var context = new SetupContext())
        //    {
        //        context.Setups.Add(setup);
        //        context.SaveChanges();
        //    }
        //}
        public static void AddUserDebtStatus(UserDebtStatus userDebtStatus)
        {
            using (var context = new SetupContext())
            {
                context.DebtStatuses.Add(userDebtStatus);
                context.SaveChanges();
            }
        }

    }
}
