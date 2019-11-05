namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext() { }
        public StudentSystemContext(DbContextOptions options) : base(options) { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(s =>
            {
                s.Property(x => x.Birthday).IsRequired(false);
                s.Property(x => x.PhoneNumber).HasColumnType("Char(10)");
                s.Property(x => x.PhoneNumber).IsUnicode(false);
            });
            modelBuilder.Entity<Course>(c =>
            {

            });
            modelBuilder.Entity<Resource>(r =>
            {
                r.HasOne(x => x.Course).WithMany(c => c.Resources).HasForeignKey(x => x.CourseId).HasConstraintName("FK_CourseResource");
                r.Property(x => x.Url).IsUnicode(false);
            });
            modelBuilder.Entity<Homework>(h =>
            {
                h.HasOne(x => x.Student).WithMany(s => s.HomeworkSubmissions).HasForeignKey(x => x.StudentId).HasConstraintName("FK_StudentHWSubmissions");
                h.HasOne(x => x.Course).WithMany(c => c.HomeworkSubmissions).HasForeignKey(x => x.CourseId).HasConstraintName("FK_CourseHomework");
                h.Property(x => x.Content).IsUnicode(false);
            });
            modelBuilder.Entity<StudentCourse>(sc =>
            {
                sc.HasKey(x => new {x.CourseId, x.StudentId });
                sc.HasOne(x => x.Student).WithMany(s => s.CourseEnrollments).HasForeignKey(x => x.StudentId).HasConstraintName("FK_StudentEnrolledCourses");
                sc.HasOne(x => x.Course).WithMany(c => c.StudentsEnrolled).HasForeignKey(x => x.CourseId).HasConstraintName("FK_StudentsInCourse");
            });
        }
    }
}
