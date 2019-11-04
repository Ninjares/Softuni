using System;

namespace P01_HospitalDatabase
{
    using P01_HospitalDatabase.Data;
    using P01_HospitalDatabase.Data.Models;
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
