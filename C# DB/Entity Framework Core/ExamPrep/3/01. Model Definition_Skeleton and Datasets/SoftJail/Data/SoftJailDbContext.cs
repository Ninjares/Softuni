namespace SoftJail.Data
{
	using Microsoft.EntityFrameworkCore;
    using SoftJail.Data.Models;

    public class SoftJailDbContext : DbContext
	{
        public DbSet<Prisoner> Prisoners { get; set; }
        public DbSet<Officer> Officers { get; set; }
        public DbSet<Cell> Cells { get; set; }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<OfficerPrisoner> OfficerPrisoners { get; set; }
		public SoftJailDbContext()
		{
		}

		public SoftJailDbContext(DbContextOptions options)
			: base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder
					.UseSqlServer(Configuration.ConnectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
            
            
            builder.Entity<Officer>(o =>
            {
                o.HasOne(x => x.Department).WithMany(x => x.Officers).HasForeignKey(x => x.DepartmentId);
            });
            builder.Entity<Cell>(c =>
            {
                c.HasOne(x => x.Department).WithMany(x => x.Cells).HasForeignKey(x => x.DepartmentId);
            });
            builder.Entity<Prisoner>(p =>
            {
                p.HasOne(x => x.Cell).WithMany(x => x.Prisoners).HasForeignKey(x => x.CellId);
            });
            builder.Entity<Mail>(m =>
            {
                m.HasOne(x => x.Prisoner).WithMany(x => x.Mails).HasForeignKey(x => x.PrisonerId);
            });
            builder.Entity<OfficerPrisoner>(op =>
            {
                op.HasKey(x => new { x.OfficerId, x.PrisonerId });
                op.HasOne(x => x.Prisoner).WithMany(x => x.PrisonerOfficers).HasForeignKey(x => x.PrisonerId).OnDelete(DeleteBehavior.Restrict);
                op.HasOne(x => x.Officer).WithMany(x => x.OfficerPrisoners).HasForeignKey(x => x.OfficerId);
                
            });
        }
	}
}