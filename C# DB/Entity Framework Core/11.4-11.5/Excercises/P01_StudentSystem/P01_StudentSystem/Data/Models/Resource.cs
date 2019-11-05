namespace P01_StudentSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Resource
    {
        public int ResourceId { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Url { get; set; } //Not unicode
        [Required]
        public ResourceType ResourceType { get; set; }
        [Required]
        public int CourseId { get; set; }

        public Course Course { get; set; }
    }

    public enum ResourceType
    {
        Video = 1,
        Presentation = 2,
        Document = 3,
        Other = 4
    }
}
