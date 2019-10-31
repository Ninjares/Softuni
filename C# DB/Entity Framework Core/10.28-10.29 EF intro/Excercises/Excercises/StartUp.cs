using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        
        public static void Main(string[] args)
        {
            SoftUniContext dbcontext = new SoftUniContext();
            Console.WriteLine(RemoveTown(dbcontext));
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var data = context.Employees.Where(e => e.Salary>50000).OrderBy(x => x.FirstName);
            foreach(var row in data)
            {
                sb.AppendLine($"{row.FirstName} - {row.Salary:F2}");
            }
            return sb.ToString();
        }
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var data = context.Employees.OrderBy(e => e.EmployeeId);
            foreach (var row in data)
            {
                sb.AppendLine($"{row.FirstName} {row.LastName}"+ (row.MiddleName==null?null:' '+row.MiddleName)+ $"{row.Department} {row.JobTitle} {row.Salary:F2}");
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

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var emps = context.Employees.Where(e => e.Department.Name == "Research and Development").OrderBy(e => e.Salary).ThenByDescending(e => e.FirstName);
            foreach (var employee in emps)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from Research and Development - ${employee.Salary:F2}");
            }
            return sb.ToString();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var completeclassarray = context.Employees.Where(e => e.EmployeesProjects.Any(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003)).Take(10)
                .Select(e => new
                {
                    FullName = e.FirstName + " " + e.LastName,
                    ManagerName = e.Manager.FirstName + " "+e.Manager.LastName,
                    Projects = e.EmployeesProjects.Select(p => new
                    {
                        Name = p.Project.Name,
                        Start = p.Project.StartDate,
                        End = p.Project.EndDate
                    })
                });
            foreach(var employee in completeclassarray)
            {
                sb.AppendLine($"{employee.FullName} - Manager: {employee.ManagerName}");
                foreach(var project in employee.Projects)
                {
                    
                    sb.AppendLine($"--{project.Name} - {project.Start.ToString("M/d/yyyy h:mm:ss tt")} - {(project.End == null ? "not finished" : project.End.Value.ToString("M/d/yyyy h:mm:ss tt"))}");
                }
            }
            
            return sb.ToString();
        }
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var addressSet = context.Addresses.OrderByDescending(a => a.Employees.Count).ThenBy(a => a.Town.Name).ThenBy(a => a.AddressText).Take(10)
                .Select(a => new
                {
                    Text = a.AddressText,
                    TownName = a.Town.Name,
                    EmpCount = a.Employees.Count
                }

                ); ;
            foreach (var address in addressSet)
                sb.AppendLine($"{address.Text}, {address.TownName} - {address.EmpCount} employees");
            return sb.ToString();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employee147 = context.Employees.Where(x => x.EmployeeId == 147).Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.JobTitle,
                Projects = e.EmployeesProjects.Select(p => p.Project.Name).OrderBy(s => s)
            }
            ).FirstOrDefault();
               
            sb.AppendLine(employee147.FirstName + " " + employee147.LastName + " - " + employee147.JobTitle);
            foreach (var project in employee147.Projects)
                sb.AppendLine(project);
            return sb.ToString();
        }
        public static string GetEmployee147v2(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employee147 = context.Employees.FirstOrDefault(x => x.EmployeeId == 147);

            sb.AppendLine(employee147.FirstName + " " + employee147.LastName + " - " + employee147.JobTitle);
            foreach (var project in employee147.EmployeesProjects.Select(ep => ep.Project))
                sb.AppendLine(project.Name);
            return sb.ToString();
        }
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var deps = context.Departments.Where(d => d.Employees.Count > 5).OrderBy(dep => dep.Employees.Count).ThenBy(dep => dep.Name).Select(dep => new
            {
                dep.Name,
                ManengerFullName = dep.Manager.FirstName + " " + dep.Manager.LastName,
                Employees = dep.Employees.OrderBy(x => x.FirstName).ThenBy(x => x.LastName)
            });
            foreach(var dep in deps)
            {
                sb.AppendLine($"{dep.Name} - {dep.ManengerFullName}");
                foreach (Employee employee in dep.Employees)
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
            }
            return sb.ToString();
        }
        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var projects = context.Projects.OrderByDescending(x => x.StartDate).Take(10).OrderBy(x => x.Name);
            foreach(Project project in projects)
            {
                sb.AppendLine(project.Name);
                sb.AppendLine(project.Description);
                sb.AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt"));
            }
            return sb.ToString();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employeesToIncreaseSalaries = context.Employees.Where(e => e.Department.Name == "Engineering" || e.Department.Name == "Tool Design" || e.Department.Name == "Marketing" || e.Department.Name == "Information Services");
            foreach (Employee employee in employeesToIncreaseSalaries) employee.Salary *= 1.12m;
            foreach (Employee employee in employeesToIncreaseSalaries.OrderBy(x => x.FirstName).ThenBy(x => x.LastName))
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
            context.Employees.UpdateRange(employeesToIncreaseSalaries);
            context.SaveChanges();
            return sb.ToString();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees.Where(x => x.FirstName.StartsWith("Sa")).OrderBy(x => x.FirstName).ThenBy(x => x.LastName);
            foreach (var emp in employees)
                sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle} - (${emp.Salary:f2})");
            return sb.ToString();
        }
        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            Project projectToRemove = context.Projects.FirstOrDefault(d => d.ProjectId == 2);
            EmployeeProject[] connectionsToRemove = context.EmployeesProjects.Where(x => x.ProjectId == 2).ToArray();
            context.EmployeesProjects.RemoveRange(connectionsToRemove);
            context.Projects.Remove(projectToRemove);
            context.SaveChanges();
            foreach (var dep in context.Projects.Take(10))
                sb.AppendLine(dep.Name);
            
            //context.Projects.Add(projectToRemove);
            //context.EmployeesProjects.AddRange(connectionsToRemove);              //How do I revert shit?
            //context.SaveChanges();
            return sb.ToString();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            Town towntodelete = context.Towns.FirstOrDefault(x => x.Name == "Seattle");
            Address[] addressestodelete = context.Addresses.Where(a => a.TownId == towntodelete.TownId).ToArray();
            Employee[] employeesToUpdate = context.Employees.Where(e => e.Address.TownId == towntodelete.TownId).ToArray();
            foreach (var employee in employeesToUpdate) employee.Address = null;
            context.Employees.UpdateRange(employeesToUpdate);
            context.Addresses.RemoveRange(addressestodelete);
            context.Towns.Remove(towntodelete);
            context.SaveChanges();
            sb.AppendLine($"{addressestodelete.Length} addresses in {towntodelete.Name} were deleted");
            return sb.ToString();

        }

    }
}
