using Exam.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam.Data.EntityConfiguration
{
    public class MarkConfiguration : IEntityTypeConfiguration<Mark>
    {
        public void Configure(EntityTypeBuilder<Mark> builder)
        {
            builder.ToTable("Mark");

            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();

            builder.Property(m => m.PartialMark).IsRequired();
            builder.Property(m => m.ExamMark).IsRequired();
            builder.Property(m => m.TotalMark).IsRequired();

            builder.HasOne(m => m.Student)
                .WithMany(u => u.Marks)
                .HasForeignKey(m => m.StudentId)
                .HasPrincipalKey(u => u.Id);

            builder.HasOne(m => m.Subject)
                .WithMany(s => s.Marks)
                .HasForeignKey(m => m.SubjectId)
                .HasPrincipalKey(s => s.Id);
        }
    }
}
