using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PigProject.Models
{
    public partial class FinalPigDBContext : DbContext
    {
        public FinalPigDBContext()
        {
        }

        public FinalPigDBContext(DbContextOptions<FinalPigDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CarDataTable> CarDataTables { get; set; } = null!;
        public virtual DbSet<CityTable> CityTables { get; set; } = null!;
        public virtual DbSet<CountyTable> CountyTables { get; set; } = null!;
        public virtual DbSet<PopDataTable> PopDataTables { get; set; } = null!;
        public virtual DbSet<VehicleTable> VehicleTables { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=FinalPigDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarDataTable>(entity =>
            {
                entity.HasKey(e => e.VehicleId);

                entity.ToTable("CarDataTable");

                entity.Property(e => e.VehicleId).HasColumnName("VehicleID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.ModelId).HasColumnName("ModelID");

                entity.Property(e => e.Vin).HasMaxLength(255);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.CarDataTables)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_CarDataTable_CityTable");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.CarDataTables)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK_CarDataTable_VehicleTable");
            });

            modelBuilder.Entity<CityTable>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.ToTable("CityTable");

                entity.Property(e => e.CityId)
                    .ValueGeneratedNever()
                    .HasColumnName("CityID");

                entity.Property(e => e.CityName).HasMaxLength(255);

                entity.Property(e => e.CountyId).HasColumnName("CountyID");

                entity.HasOne(d => d.County)
                    .WithMany(p => p.CityTables)
                    .HasForeignKey(d => d.CountyId)
                    .HasConstraintName("FK_CityTable_CountyTable");
            });

            modelBuilder.Entity<CountyTable>(entity =>
            {
                entity.HasKey(e => e.CountyId);

                entity.ToTable("CountyTable");

                entity.Property(e => e.CountyId)
                    .ValueGeneratedNever()
                    .HasColumnName("CountyID");

                entity.Property(e => e.CountyName).HasMaxLength(255);
            });

            modelBuilder.Entity<PopDataTable>(entity =>
            {
                entity.HasKey(e => e.AreaId);

                entity.ToTable("PopDataTable");

                entity.Property(e => e.AreaId).HasColumnName("AreaID");

                entity.Property(e => e.CityName).HasMaxLength(255);

                entity.Property(e => e.CountyId).HasColumnName("CountyID");

                entity.HasOne(d => d.County)
                    .WithMany(p => p.PopDataTables)
                    .HasForeignKey(d => d.CountyId)
                    .HasConstraintName("FK_PopDataTable_CountyTable");
            });

            modelBuilder.Entity<VehicleTable>(entity =>
            {
                entity.HasKey(e => e.ModelId);

                entity.ToTable("VehicleTable");

                entity.Property(e => e.ModelId)
                    .ValueGeneratedNever()
                    .HasColumnName("ModelID");

                entity.Property(e => e.MakeName).HasMaxLength(255);

                entity.Property(e => e.ModelName).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
