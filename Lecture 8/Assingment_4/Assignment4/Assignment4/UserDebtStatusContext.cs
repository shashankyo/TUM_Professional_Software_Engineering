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
            optionsBuilder.UseSqlite("Data Source = D:\\WIP\\00_Akademic_TUM_ITBE\\1. Semester\\Professional Software Engineering\\Lecture 8\\Assingment_4\\Assignment4\\Assignment4\\UserDebtStatusDatabase.db");

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserDebtStatus>().HasKey(b => b.UserName);

        }


    }
}
