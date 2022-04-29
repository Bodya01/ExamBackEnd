using Exam.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exam.Data.Context
{
    public class ExamContext : DbContext
    {
        public ExamContext(DbContextOptions<ExamContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
