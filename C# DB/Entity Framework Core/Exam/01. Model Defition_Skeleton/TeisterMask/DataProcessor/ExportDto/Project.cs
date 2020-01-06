using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Project")]
    public class ProjectEDTO
    {
        [XmlAttribute]
        public int TasksCount { get; set; }
        public string ProjectName { get; set; }
        public string HasEndDate { get; set; }
        [XmlArray]
        public TaskEDTO[] Tasks { get; set; }
    }
    [XmlType("Task")]
    public class TaskEDTO
    {
        public string Name { get; set; }
        public string Label { get; set; }
    }
}
