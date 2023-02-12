using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static ProSE.SetUp;

namespace ProSE
{
    public class UserDebtStatusContext : DbContext
    {
        public DbSet<UserDebtStatus> DebtStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            // the filepath might needs to be changed!!!

            optionsBuilder.UseSqlite("UserDebtStatusDatabase.db");

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserDebtStatus>().HasKey(b => b.UserName);

        }


    }
}
