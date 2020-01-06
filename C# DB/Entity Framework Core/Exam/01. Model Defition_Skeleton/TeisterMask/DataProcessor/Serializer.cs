namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        static XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var toserializer = context.Projects.Where(x => x.Tasks.Count() > 0).Select(x => new ProjectEDTO
            {
                TasksCount = x.Tasks.Count(),
                ProjectName = x.Name,
                HasEndDate = x.DueDate.HasValue ? "Yes" : "No",
                Tasks = x.Tasks.Select(t => new TaskEDTO 
                { 
                    Label = t.LabelType.ToString(), 
                    Name = t.Name }
                ).OrderBy(t => t.Name)
                .ToArray()
            }).OrderByDescending(x => x.TasksCount).ThenBy(x => x.ProjectName).ToArray();
            var serializer = new XmlSerializer(typeof(ProjectEDTO[]), new XmlRootAttribute("Projects"));
                using(TextWriter tw = new StringWriter())
                {
                    serializer.Serialize(tw, toserializer, namespaces);
                    return tw.ToString();
                }
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var objects = context.Employees

                .OrderByDescending(x => x.EmployeesTasks.Count()).ThenBy(x => x.Username)
                .Where(x => x.EmployeesTasks.Any(t => t.Task.OpenDate >= date))
                .Take(10)
                .Select(x => new
                {
                    x.Username,
                    Tasks = x.EmployeesTasks
                    .Where(t => t.Task.OpenDate >= date)
                    .OrderByDescending(t => t.Task.DueDate).ThenBy(t => t.Task.Name)
                    .Select(t => new
                    {
                        TaskName = t.Task.Name,
                        OpenDate = t.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                        DueDate = t.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        LabelType = t.Task.LabelType.ToString(),
                        ExecutionType = t.Task.ExecutionType.ToString()
                    })
                });
            return JsonConvert.SerializeObject(objects, Newtonsoft.Json.Formatting.Indented);
        }
    }
}