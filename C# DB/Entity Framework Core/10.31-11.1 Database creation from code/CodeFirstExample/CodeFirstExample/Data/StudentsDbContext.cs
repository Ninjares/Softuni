using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstExample.Data
{
    using Microsoft.EntityFrameworkCore;
    using CodeFirstExample.Data.Models;
    class StudentsDbContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Town> Towns { get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=StudentsCodeFirst;Integrated Security=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(st => st.Town)
                .WithMany(t => t.Students)
                .HasForeignKey(st => st.TownId);
        }
    }
}


//Version 16.3.7 is downloaded and ready to install