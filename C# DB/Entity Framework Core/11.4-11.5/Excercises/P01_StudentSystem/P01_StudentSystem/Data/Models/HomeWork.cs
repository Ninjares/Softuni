namespace P01_StudentSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Homework
    {
        public int HomeworkId { get; set; }
        [Required]
        public string Content { get; set; } //not unicode
        [Required]
        public ContentType ContentType { get; set; }
        [Required]
        public DateTime SubmissionTime { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int CourseId { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }

    }

    public enum ContentType
    {
        Application = 1,
        Pdf = 2,
        Zip = 3
    }
}
