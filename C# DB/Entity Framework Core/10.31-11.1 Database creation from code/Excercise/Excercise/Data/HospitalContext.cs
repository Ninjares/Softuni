using System;
using System.Collections.Generic;
using System.Text;

namespace P01_HospitalDatabase.Data
{
    using P01_HospitalDatabase.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {

        }

        public HospitalContext(DbContextOptions options) : base(options)
        {
            //Necessary for judge
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Visitation> Visitations { get; set; }
        public DbSet<PatientMedicament> Prescriptions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(@"Server=.\SQLEXPRESS;Database=HospitalCodeFirst;Integrated Security=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(patient =>
            {
                patient.HasKey(k => k.PatientId);
                patient.Property(fn => fn.FirstName).IsUnicode(true);
                patient.Property(ln => ln.FirstName).IsUnicode(true);
                patient.Property(a => a.Address).IsUnicode(true);
                patient.Property(e => e.Email).IsUnicode(false);
            }
            );

            modelBuilder.Entity<PatientMedicament>(pm =>
            {
                pm.HasOne(p => p.Patient).WithMany(m => m.Prescriptions).HasForeignKey(x => x.PatientId).HasConstraintName("FK_PresciptionPatient");
                pm.HasOne(m => m.Medicament).WithMany(p => p.Prescriptions).HasForeignKey(x => x.MedicamentId).HasConstraintName("FK_PresciptionMedication");
                pm.HasKey(pmk => new { pmk.PatientId, pmk.MedicamentId });
                pm.ToTable("Prescriptions");
            });

            modelBuilder.Entity<Visitation>(visitation =>
            {
                visitation.Property(v => v.Comments).IsUnicode(true);
                visitation.HasOne(d => d.Doctor).WithMany(v => v.Visitations).HasForeignKey(x => x.DoctorId).HasConstraintName("FK_VisitationDoctor");
                visitation.HasOne(p => p.Patient).WithMany(v => v.Visitations).HasForeignKey(x => x.PatientId).HasConstraintName("FK_VisitationPatient");
            });
            modelBuilder.Entity<Diagnose>(diagnose =>
            {
                diagnose.Property(x => x.Comments).IsUnicode(true);
                diagnose.Property(x => x.Name).IsUnicode(true);
                diagnose.HasOne(d => d.Patient).WithMany(p => p.Diagnoses).HasForeignKey(x => x.PatientId).HasConstraintName("FK_DiagnosePatient");

            });
            modelBuilder.Entity<Medicament>(med =>
            {
                med.Property(x => x.Name).IsUnicode(true);
            });
            modelBuilder.Entity<Doctor>(doc =>
            {
                doc.Property(x => x.Name).IsUnicode(true);
                doc.Property(x => x.Specialty).IsUnicode(true);
            });
        }
    }
}
