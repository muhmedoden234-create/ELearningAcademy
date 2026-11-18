using ELearningAcademy.Helpers;
using ELearningAcademy.Models;
using Microsoft.EntityFrameworkCore;

namespace ELearningAcademy.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseEnrollment> CourseEnrollments { get; set; }
        public DbSet<CourseModule> Modules { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<AnswerOption> AnswerOptions { get; set; }
        public DbSet<TestAttempt> TestAttempts { get; set; }
        public DbSet<StudentAnswer> StudentAnswers { get; set; }
        public DbSet<StudentAnswerOption> StudentAnswerOptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(AppConfig.ConnectionString,
                    ServerVersion.Parse(AppConfig.MySqlServerVersion));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4");
            modelBuilder.UseCollation("utf8mb4_unicode_ci");

            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("Users", t => t.HasCheckConstraint("CK_Users_Role", "`Role` IN (1, 2)"));
                e.HasKey(u => u.Id);
                e.Property(u => u.FullName).HasMaxLength(150).IsRequired();
                e.Property(u => u.Login).HasMaxLength(50).IsRequired();
                e.HasIndex(u => u.Login).IsUnique();
                e.Property(u => u.PasswordHash).HasMaxLength(256).IsRequired();
                e.Property(u => u.Role).HasConversion<int>();
            });

            modelBuilder.Entity<Course>(e =>
            {
                e.ToTable("Courses");
                e.Property(c => c.Title).HasMaxLength(200).IsRequired();
                e.Property(c => c.Description).HasMaxLength(2000);
                e.HasOne(c => c.CreatedBy)
                    .WithMany(u => u.CreatedCourses)
                    .HasForeignKey(c => c.CreatedByUserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<CourseEnrollment>(e =>
            {
                e.ToTable("CourseEnrollments");
                e.HasIndex(x => new { x.CourseId, x.StudentId }).IsUnique();
                e.HasOne(x => x.Course)
                    .WithMany(c => c.Enrollments)
                    .HasForeignKey(x => x.CourseId)
                    .OnDelete(DeleteBehavior.Cascade);
                e.HasOne(x => x.Student)
                    .WithMany(u => u.Enrollments)
                    .HasForeignKey(x => x.StudentId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<CourseModule>(e =>
            {
                e.ToTable("Modules");
                e.Property(m => m.Title).HasMaxLength(200).IsRequired();
                e.Property(m => m.Description).HasMaxLength(2000);
                e.HasOne(m => m.Course)
                    .WithMany(c => c.Modules)
                    .HasForeignKey(m => m.CourseId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Lesson>(e =>
            {
                e.ToTable("Lessons");
                e.Property(l => l.Title).HasMaxLength(200).IsRequired();
                e.Property(l => l.ContentRtf).HasColumnType("longtext");
                e.HasOne(l => l.Module)
                    .WithMany(m => m.Lessons)
                    .HasForeignKey(l => l.ModuleId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Test>(e =>
            {
                e.ToTable("Tests");
                e.Property(t => t.Title).HasMaxLength(200).IsRequired();
                e.Property(t => t.Description).HasMaxLength(1000);
                e.HasOne(t => t.Module)
                    .WithOne(m => m.Test)
                    .HasForeignKey<Test>(t => t.ModuleId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Question>(e =>
            {
                e.ToTable("Questions", t =>
                {
                    t.HasCheckConstraint("CK_Questions_Type", "`Type` IN (1, 2, 3)");
                    t.HasCheckConstraint("CK_Questions_Points", "`Points` > 0");
                });
                e.Property(q => q.Text).HasMaxLength(2000).IsRequired();
                e.Property(q => q.Type).HasConversion<int>();

                e.Property(q => q.ImageData).HasColumnType("longblob");
                e.HasOne(q => q.Test)
                    .WithMany(t => t.Questions)
                    .HasForeignKey(q => q.TestId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<AnswerOption>(e =>
            {
                e.ToTable("AnswerOptions");
                e.Property(o => o.Text).HasMaxLength(500).IsRequired();
                e.HasOne(o => o.Question)
                    .WithMany(q => q.Options)
                    .HasForeignKey(o => o.QuestionId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TestAttempt>(e =>
            {
                e.ToTable("TestAttempts", t =>
                {
                    t.HasCheckConstraint("CK_TestAttempts_Score", "`ScoreObtained` >= 0 AND `ScoreObtained` <= `MaxScore`");
                    t.HasCheckConstraint("CK_TestAttempts_Percent", "`Percent` >= 0 AND `Percent` <= 100");
                });
                e.Property(a => a.Percent).HasPrecision(5, 2);
                e.HasOne(a => a.Test)
                    .WithMany(t => t.Attempts)
                    .HasForeignKey(a => a.TestId)
                    .OnDelete(DeleteBehavior.Cascade);
                e.HasOne(a => a.Student)
                    .WithMany(u => u.TestAttempts)
                    .HasForeignKey(a => a.StudentId)
                    .OnDelete(DeleteBehavior.Cascade);
                e.HasIndex(a => new { a.StudentId, a.TestId });
            });

            modelBuilder.Entity<StudentAnswer>(e =>
            {
                e.ToTable("StudentAnswers", t =>
                    t.HasCheckConstraint("CK_StudentAnswers_Points", "`PointsAwarded` >= 0"));
                e.Property(a => a.TextAnswer).HasMaxLength(1000);
                e.HasOne(a => a.TestAttempt)
                    .WithMany(t => t.Answers)
                    .HasForeignKey(a => a.TestAttemptId)
                    .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(a => a.Question)
                    .WithMany()
                    .HasForeignKey(a => a.QuestionId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<StudentAnswerOption>(e =>
            {
                e.ToTable("StudentAnswerOptions");
                e.HasKey(x => new { x.StudentAnswerId, x.AnswerOptionId });
                e.HasOne(x => x.StudentAnswer)
                    .WithMany(a => a.SelectedOptions)
                    .HasForeignKey(x => x.StudentAnswerId)
                    .OnDelete(DeleteBehavior.Cascade);
                e.HasOne(x => x.AnswerOption)
                    .WithMany()
                    .HasForeignKey(x => x.AnswerOptionId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
