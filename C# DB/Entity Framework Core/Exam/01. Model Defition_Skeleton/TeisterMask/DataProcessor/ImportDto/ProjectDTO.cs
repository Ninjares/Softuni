using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Project")]
    public class ProjectDTO
    {
        public string Name { get; set; }
        public string OpenDate { get; set; }
        public string DueDate { get; set; }
        [XmlArray("Tasks")]
        public TaskDTO[] Tasks { get; set; }
    }
    [XmlType("Task")]
    public class TaskDTO
    {
        public string Name { get; set; }
        public string OpenDate { get; set; }
        public string DueDate { get; set; }
        public int ExecutionType { get; set; }
        public int LabelType { get; set; }
    }
}
