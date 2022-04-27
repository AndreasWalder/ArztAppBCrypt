using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ArztApp.BAL
{
    public partial class ArztContext : DbContext
    {
        public ArztContext()
        {
        }

        public ArztContext(DbContextOptions<ArztContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Medication> Medications { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Visit> Visits { get; set; } = null!;
        public virtual DbSet<VisitMedication> VisitMedications { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LWLNB2AB104\\SQLEXPRESS; Database=Arzt; Integrated Security=True; TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medication>(entity =>
            {
                entity.ToTable("Medication");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Firstname).HasMaxLength(50);

                entity.Property(e => e.Surname).HasMaxLength(50);

                entity.Property(e => e.Zip).HasColumnName("ZIP");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Pass).HasMaxLength(100);

                entity.Property(e => e.RegDate).HasColumnType("datetime");

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<Visit>(entity =>
            {
                entity.ToTable("Visit");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateOfVisit).HasColumnType("datetime");

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Visits)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Visit_Patient");
            });

            modelBuilder.Entity<VisitMedication>(entity =>
            {
                entity.ToTable("VisitMedication");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.Medication)
                    .WithMany(p => p.VisitMedications)
                    .HasForeignKey(d => d.MedicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VisitMedication_Medication");

                entity.HasOne(d => d.Visit)
                    .WithMany(p => p.VisitMedications)
                    .HasForeignKey(d => d.VisitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VisitMedication_Visit");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
