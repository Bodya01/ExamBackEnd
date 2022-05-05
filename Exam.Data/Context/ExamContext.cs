using Exam.Data.Entities;
using Exam.Data.EntityConfiguration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Exam.Data.Context
{
    public class ExamContext : IdentityDbContext<User>
    {
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<List> Lists { get; set; }
        public DbSet<Data.Entities.Exam> Exams { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Course> Courses { get; set; }

        public ExamContext(DbContextOptions<ExamContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new ExamConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new ListConfiguration());
            modelBuilder.ApplyConfiguration(new MarkConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationConfiguration());
            modelBuilder.ApplyConfiguration(new RefreshTokenConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
