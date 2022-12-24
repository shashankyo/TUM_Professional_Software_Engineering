using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSE 

{
    public class PokedexContext : DbContext
    {
        public DbSet<Pokemon> Pokemons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=D:\\WIP\\00_Akademic_TUM_ITBE\\1. Semester\\Professional Software Engineering\\Lecture 8\\Lecture8_Exercises\\PokedexDatabase.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // will be added.
        }

    }

}
