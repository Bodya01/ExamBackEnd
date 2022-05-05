using Exam.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam.Data.Entities
{
    public class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.ToTable("Exam");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.ExamDate).IsRequired();
            builder.Property(e => e.TeacherId).IsRequired();

            builder.HasOne(e => e.Group)
                .WithMany(g => g.Exams)
                .HasForeignKey(e => e.GroupId)
                .HasPrincipalKey(g =>  g.Id);

            builder.HasOne(e => e.Teacher)
                .WithMany(g => g.Exams)
                .HasForeignKey(e => e.TeacherId)
                .HasPrincipalKey(g => g.Id);

            builder.HasOne(e => e.Course)
                .WithMany(g => g.Exams)
                .HasForeignKey(e => e.CourseId)
                .HasPrincipalKey(g => g.Id);
        }
    }
}
