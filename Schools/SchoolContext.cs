using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Schools
{
    public partial class SchoolContext : DbContext
    {
        public SchoolContext()
        {
        }

        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Director> Director { get; set; }
        public virtual DbSet<School> School { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=School;Username=postgres;Password=P@ssw0rd");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.Entity<Director>(entity =>
            {
                entity.HasKey(e => e.Primarykey)
                    .HasName("director_pkey");

                entity.ToTable("director");

                entity.Property(e => e.Primarykey)
                    .HasColumnName("primarykey")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Fio)
                    .HasColumnName("fio")
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.HasKey(e => e.Primarykey)
                    .HasName("school_pkey");

                entity.ToTable("school");

                entity.Property(e => e.Primarykey)
                    .HasColumnName("primarykey")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Director).HasColumnName("director");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(256);

                entity.Property(e => e.Number).HasColumnName("number");

                entity.HasOne(d => d.DirectorNavigation)
                    .WithMany(p => p.School)
                    .HasForeignKey(d => d.Director)
                    .HasConstraintName("fk_director");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Primarykey)
                    .HasName("User_pkey");

                entity.Property(e => e.Primarykey)
                    .HasColumnName("primarykey")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(500);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
