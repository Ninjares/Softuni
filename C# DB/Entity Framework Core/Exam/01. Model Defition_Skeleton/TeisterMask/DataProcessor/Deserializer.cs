namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.Text;
    using System.Xml.Serialization;
    using TeisterMask.DataProcessor.ImportDto;
    using System.IO;
    using TeisterMask.Data.Models;
    using System.Globalization;
    using TeisterMask.Data.Models.Enums;
    using Newtonsoft.Json;
    using System.Linq;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            var serializer = new XmlSerializer(typeof(ProjectDTO[]), new XmlRootAttribute("Projects"));
            var dtos = (ProjectDTO[])serializer.Deserialize(new StringReader(xmlString));
            foreach(ProjectDTO projectDTO in dtos)
            {
                Project project = new Project
                {
                    Name = projectDTO.Name,
                    OpenDate = DateTime.ParseExact(projectDTO.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                };
                if (!String.IsNullOrEmpty(projectDTO.DueDate)) project.DueDate = DateTime.ParseExact(projectDTO.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                else project.DueDate = null;
                if (IsValid(project))
                {
                    context.Projects.Add(project);
                    List<Task> tasks = new List<Task>();
                    foreach (TaskDTO taskdto in projectDTO.Tasks)
                    {
                        Task task = new Task
                        {
                            Name = taskdto.Name,
                            OpenDate = DateTime.ParseExact(taskdto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                            DueDate = DateTime.ParseExact(taskdto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                            ExecutionType = (ExecutionType)taskdto.ExecutionType,
                            LabelType = (LabelType)taskdto.LabelType,
                            Project = project
                        };
                        if (!project.DueDate.HasValue)
                        {
                            if (IsValid(task) && task.OpenDate > project.OpenDate)
                                    context.Tasks.Add(task);
                            else sb.AppendLine(ErrorMessage);
                        }
                        else
                        {
                            if (IsValid(task) && task.OpenDate > project.OpenDate && task.DueDate > project.DueDate.Value)
                                context.Tasks.Add(task);
                            else sb.AppendLine(ErrorMessage);
                        }
                    }
                    context.Tasks.AddRange(tasks);
                    sb.AppendLine(String.Format(SuccessfullyImportedProject, project.Name, tasks.Count));
                }
                else sb.AppendLine(ErrorMessage);
            }
            context.SaveChanges();
            return sb.ToString();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var dtos = JsonConvert.DeserializeObject<EmployeeDTO[]>(jsonString);
            foreach(EmployeeDTO employeeDTO in dtos)
            {
                List<EmployeeTask> tasks = new List<EmployeeTask>();
                Employee employee = new Employee
                {
                    Username = employeeDTO.Username,
                    Email = employeeDTO.Email,
                    Phone = employeeDTO.Phone
                };
                if (IsValid(employee))
                {
                    foreach(int taskid in employeeDTO.Tasks.Distinct())
                    {
                        if (context.Tasks.Any(x => x.Id == taskid))
                        {
                            EmployeeTask employeeTask = new EmployeeTask
                            {
                                TaskId = taskid,
                                Employee = employee
                            };
                            tasks.Add(employeeTask);
                        }
                    }
                    context.Employees.Add(employee);
                    context.EmployeesTasks.AddRange(tasks);
                    sb.AppendLine(String.Format(SuccessfullyImportedEmployee, employee.Username, tasks.Count));
                }
                else sb.AppendLine(ErrorMessage);

            }
            context.SaveChanges();
            return sb.ToString();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}