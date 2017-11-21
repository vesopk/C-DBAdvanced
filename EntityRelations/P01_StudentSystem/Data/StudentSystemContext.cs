using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        public StudentSystemContext()
        {
        }

        public StudentSystemContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                    .IsUnicode(false)
                    .IsRequired(false)
                    .HasColumnType("char(10)");

                entity.Property(e => e.RegisteredOn)
                    .IsRequired(true)
                    .HasColumnType("DATETIME")
                    .HasDefaultValueSql("GETDATE()");

                entity.Property(e => e.Birthday)
                    .IsRequired(false)
                    .HasColumnType("DATETIME");

                entity.HasMany(e => e.HomeworkSubmissions)
                    .WithOne(e => e.Student)
                    .HasForeignKey(e => e.StudentId)
                    .HasConstraintName("FK_Students_Homeworks");
                
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CourseId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(80);

                entity.Property(e => e.Description)
                    .IsRequired(false)
                    .IsUnicode();

                entity.Property(e => e.StartDate)
                    .IsRequired()
                    .HasColumnType("DATETIME");

                entity.Property(e => e.EndDate)
                    .IsRequired()
                    .HasColumnType("DATETIME2");

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasColumnType("decimal(5,2)");

                entity.HasMany(e => e.HomeworkSubmissions)
                    .WithOne(e => e.Course)
                    .HasForeignKey(e => e.CourseId)
                    .HasConstraintName("FK_Courses_Homeworks");

                entity.HasMany(e => e.Resources)
                    .WithOne(e => e.Course)
                    .HasForeignKey(e => e.ResourceId)
                    .HasConstraintName("FK_Courses_Resources");
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(e => e.ResourceId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(50);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .IsUnicode(false);
                
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.HasKey(e => e.HomeworkId);

                entity.Property(e => e.Content)
                    .IsRequired()
                    .IsUnicode();

                entity.Property(e => e.SubmissionTime)
                    .IsRequired()
                    .HasColumnType("DATETIME")
                    .HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(k => new {k.StudentId, k.CourseId});

                entity.HasOne(e => e.Student)
                    .WithMany(s => s.CourseEnrollments)
                    .HasForeignKey(sc => sc.StudentId);

                entity.HasOne(e => e.Course)
                    .WithMany(e => e.StudentsEnrolled)
                    .HasForeignKey(e => e.CourseId);
            });
        }
    }
}
