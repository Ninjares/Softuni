using System;

namespace CodeFirstExample
{
    using CodeFirstExample.Data;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            using var db = new StudentsDbContext();
            db.Database.EnsureCreated();
            db.Towns.Add(new Data.Models.Town
            {
                Name = "BumpaLand"
            });
            db.SaveChanges();
            db.Students.Add(new Data.Models.Student
            {
                FirstName = "Tashi",
                LastName = "Surbakov",
                registrationDate = DateTime.UtcNow,
                Type = Data.Models.StudentType.Enrolled,
                TownId = db.Towns.FirstOrDefault(x => x.Name=="BumpaLand").Id
                
            }
            ) ;
            db.SaveChanges();
        }
    }
}
