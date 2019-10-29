using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var data = context.Employees.OrderBy(e => e.EmployeeId).Select(e => new
            {
                FullName = e.FirstName + " " + e.LastName + (e.MiddleName == null ? "" : $" {e.MiddleName}"),
                Department = e.Department.Name,
                JobTitle = e.JobTitle,
                Salary = e.Salary
            }) ;
            foreach(var row in data)
            {
               sb.AppendLine($"{row.FullName} {row.Department} {row.JobTitle} {row.Salary:F2}");
            }
            string returnstring = sb.ToString();
            return returnstring;
            
        }
        public static void Main(string[] args)
        {
            SoftUniContext dbcontext = new SoftUniContext();
            Console.WriteLine(GetDepartmentsWithMoreThan5Employees(dbcontext));
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var data = context.Employees.OrderByDescending(e => e.Salary).Where(e => e.Salary>50000).Select(e => e.FirstName + " - " + $"{e.Salary:F2}");
            foreach(string row in data)
            {
                sb.AppendLine(row);
            }
            return sb.ToString();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            context.Addresses.Add(new Address() { AddressText = "Vitoshka 15", TownId = 4 });
            context.SaveChanges();
            int addressId = context.Addresses.Where(a => a.AddressText == "Vitoshka 15" && a.TownId == 4).Select(a => a.AddressId).FirstOrDefault();
            var nakov = context.Employees.Where(x => x.LastName == "Nakov").FirstOrDefault();
            nakov.AddressId = addressId;
            context.Employees.Update(nakov);
            context.SaveChanges();
            foreach(var addresstext in context.Employees.OrderByDescending(x => x.AddressId).Select(x => x.Address.AddressText).Take(10))
            {
                sb.AppendLine(addresstext);
            }
            return sb.ToString();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var deps = context.Departments.Where(x => x.Employees.Count > 5).OrderBy(x => x.Employees.Count).ThenBy(x => x.Name);
            foreach(var dep in deps)
            {
                sb.AppendLine(dep.Name +(dep.Manager==null?"":" - "+ dep.Manager.FirstName + " " + dep.Manager.LastName));
                foreach (var employee in dep.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
                    sb.AppendLine(employee.FirstName + " " + employee.LastName + " - " + employee.JobTitle);
            }
            return sb.ToString();
        }
    }
}
