using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Photo_aggregator.DAL
{
    public partial class Photo_aggregatorContext : DbContext
    {
        public Photo_aggregatorContext()
        {
        }

        public Photo_aggregatorContext(DbContextOptions<Photo_aggregatorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeePosition> EmployeePositions { get; set; } = null!;
        public virtual DbSet<Photographer> Photographers { get; set; } = null!;
        public virtual DbSet<Publication> Publications { get; set; } = null!;
        public virtual DbSet<Request> Requests { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=192.168.50.205; Port=5432; Database=Photo_aggregator; Username=postgres; Password=postgres");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("pgcrypto");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("client");

                entity.Property(e => e.ClientId)
                    .ValueGeneratedNever()
                    .HasColumnName("client_id");

                entity.Property(e => e.ClientEmail)
                    .HasColumnType("character varying")
                    .HasColumnName("client_email");

                entity.Property(e => e.ClientName)
                    .HasColumnType("character varying")
                    .HasColumnName("client_name");

                entity.Property(e => e.ClientNumber).HasColumnName("client_number");

                entity.Property(e => e.ClientSurname)
                    .HasColumnType("character varying")
                    .HasColumnName("client_surname");

                entity.HasOne(d => d.ClientNavigation)
                    .WithOne(p => p.Client)
                    .HasForeignKey<Client>(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("client_id_fk");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");

                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedNever()
                    .HasColumnName("employee_id");

                entity.Property(e => e.EmployeeName)
                    .HasColumnType("character varying")
                    .HasColumnName("employee_name");

                entity.Property(e => e.EmployeePosition).HasColumnName("employee_position");

                entity.Property(e => e.EmployeeSurname)
                    .HasColumnType("character varying")
                    .HasColumnName("employee_surname");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithOne(p => p.Employee)
                    .HasForeignKey<Employee>(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("employees_id_fk");

                entity.HasOne(d => d.EmployeePositionNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EmployeePosition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("position_id_fk");
            });

            modelBuilder.Entity<EmployeePosition>(entity =>
            {
                entity.HasKey(e => e.PositionId)
                    .HasName("employee_position_pkey");

                entity.ToTable("employee_position");

                entity.Property(e => e.PositionId)
                    .ValueGeneratedNever()
                    .HasColumnName("position_id");

                entity.Property(e => e.PositionName)
                    .HasMaxLength(30)
                    .HasColumnName("position_name");
            });

            modelBuilder.Entity<Photographer>(entity =>
            {
                entity.ToTable("photographers");

                entity.Property(e => e.PhotographerId)
                    .ValueGeneratedNever()
                    .HasColumnName("photographer_id");

                entity.Property(e => e.PhotographerEmail)
                    .HasColumnType("character varying")
                    .HasColumnName("photographer_email");

                entity.Property(e => e.PhotographerName)
                    .HasMaxLength(50)
                    .HasColumnName("photographer_name");

                entity.Property(e => e.PhotographerSurname)
                    .HasColumnType("character varying")
                    .HasColumnName("photographer_surname");

                entity.Property(e => e.PhotographerWorkExperience).HasColumnName("photographer_work_experience");
            });

            modelBuilder.Entity<Publication>(entity =>
            {
                entity.ToTable("publications");

                entity.Property(e => e.PublicationId)
                    .ValueGeneratedNever()
                    .HasColumnName("publication_id");

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.Property(e => e.PublicationDate).HasColumnName("publication_date");

                entity.Property(e => e.PublicationsSource).HasColumnName("publications_source");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Publications)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("author_id_fk");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.ToTable("requests");

                entity.Property(e => e.RequestId)
                    .ValueGeneratedNever()
                    .HasColumnName("request_id");

                entity.Property(e => e.CleintId).HasColumnName("cleint_id");

                entity.Property(e => e.CreationDate).HasColumnName("creation_date");

                entity.Property(e => e.ExecutionDate).HasColumnName("execution_date");

                entity.Property(e => e.PhotographerId).HasColumnName("photographer_id");

                entity.Property(e => e.ServiceTypeId).HasColumnName("service_type_id");

                entity.HasOne(d => d.Cleint)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.CleintId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("client_id_fk");

                entity.HasOne(d => d.Photographer)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.PhotographerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("photographer_id");

                entity.HasOne(d => d.ServiceType)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.ServiceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("service_type_id_fk");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("reviews");

                entity.Property(e => e.ReviewId)
                    .ValueGeneratedNever()
                    .HasColumnName("review_id");

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.PhotographerId).HasColumnName("photographer_id");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("author_id_fk");

                entity.HasOne(d => d.Photographer)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.PhotographerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("photographer_id");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("services");

                entity.Property(e => e.ServiceId)
                    .ValueGeneratedNever()
                    .HasColumnName("service_id");

                entity.Property(e => e.ServiceDescription).HasColumnName("service_description");

                entity.Property(e => e.ServiceName)
                    .HasColumnType("character varying")
                    .HasColumnName("service_name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.UserLogin)
                    .HasColumnType("character varying")
                    .HasColumnName("user_login");

                entity.Property(e => e.UserPass)
                    .HasColumnType("character varying")
                    .HasColumnName("user_pass");

                entity.Property(e => e.UserRole)
                    .HasColumnType("character varying")
                    .HasColumnName("user_role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
