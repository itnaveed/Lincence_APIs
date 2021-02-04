using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Database
{
    public partial class Licence_APIsContext : DbContext
    {
        public Licence_APIsContext()
        {
        }

        public Licence_APIsContext(DbContextOptions<Licence_APIsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Authorize> Authorizes { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Licence_APIs;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Authorize>(entity =>
            {
                entity.ToTable("Authorize");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ServiceId).HasColumnName("Service_id");

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Authorizes)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_Authorize_Services");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Authorizes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Authorize_Users");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("Log");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("End_Time");

                entity.Property(e => e.ServiceId).HasColumnName("Service_id");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Start_Time");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_Log_Services");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Log_Users");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AppName)
                    .HasMaxLength(50)
                    .HasColumnName("App_Name");

                entity.Property(e => e.Detail).HasMaxLength(50);

                entity.Property(e => e.Version).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cnic)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CNIC");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("is_Active");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
