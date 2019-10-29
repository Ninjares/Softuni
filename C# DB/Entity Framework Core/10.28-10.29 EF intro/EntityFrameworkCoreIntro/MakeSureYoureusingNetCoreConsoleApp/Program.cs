using System;

namespace MakeSureYoureusingNetCoreConsoleApp
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.SqlServer;
    using Microsoft.EntityFrameworkCore.SqlServer.Design;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    class Program
    {
        static void Main(string[] args)
        {
            Func<Towns,bool> func = t => t.Name.StartsWith('1');    //EntityFrameWork Does not understand this
            Expression<Func<Towns, bool>> expr = t => t.Name.StartsWith('1');

            using (var db = new SoftuniContext())
            {
                var list = new List<Towns>();
                list.Where(func); //This accepts functions
                db.Towns.Where(expr); //This accepts expressions

                var result = db.Towns
                    .Where(t => t.Name.StartsWith("P") && t.TownId > 3)
                    .Select(t => t.Name)
                    .ToList();
                Console.WriteLine();

                var result2 = db.Employees
                    .Select(e => new
                    {
                        Name = e.FirstName + " " + e.LastName,
                        Department = e.Department.Name
                    }).ToList();
                Console.ReadLine();
            }
            
        }
    }
}
//Into package manager console
//Scaffold-DbContext    
//-Connection:  Server=.\SQLEXPRESS;Database=Softuni;Integrated Security=True
//-Provider:    Microsoft.EntityFrameworkCore.SqlServer
//-OutputDir:   Data