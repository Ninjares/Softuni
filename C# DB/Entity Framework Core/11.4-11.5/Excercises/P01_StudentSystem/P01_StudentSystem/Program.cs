using System;

namespace P01_StudentSystem
{
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data;
    public class StartUp
    {
      
        static void Main(string[] args)
        {
            StudentSystemContext db = new StudentSystemContext();
            db.Database.Migrate();
        }
    }
}
