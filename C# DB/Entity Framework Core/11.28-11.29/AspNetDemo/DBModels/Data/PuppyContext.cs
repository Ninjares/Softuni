using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBModels.Data
{
    class PuppyContext : DbContext
    {
        public DbSet<Puppy> Puppies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server = 93.123.83.236,27020; Database = Puppies; Integrated Security=False; User ID = Ninjares; Password = nadenica;");
            // Server=.\SQLEXPRESS;Database=Puppies;Integrated Security=True
            // Source = myServerAddress; Initial Catalog = myDataBase; Integrated Security = SSPI; User ID = myDomain\myUsername; Password = myPassword;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Puppy>(x =>
            {
                x.HasKey(p => p.Id).HasName("PK_Pupper");
                x.Property(p => p.Breed).IsRequired(true).IsUnicode(false);
                x.Property(p => p.Name).IsRequired(false).IsUnicode(true);
            });
        }
    }
}
