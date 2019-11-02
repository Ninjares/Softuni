using System;

namespace Excercise
{
    using Excercise.Data;
    using Excercise.Data.Models;
    public class StartUp
    {
        static void Main(string[] args)
        {
            HospitalContext db = new HospitalContext();
            db.Database.EnsureCreated();
            db.SaveChanges();
        }
    }
}
