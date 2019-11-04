using System;

namespace P03_SalesDatabase
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using P03_SalesDatabase.Data;
    public class StartUp
    {
        static void Main(string[] args)
        {
            SalesContext db = new SalesContext();
            db.Database.EnsureDeleted();
            db.Database.Migrate(); //Deleting a whole database wtf?
            db.SaveChanges();
           
        }
    }
}
