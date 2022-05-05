using Exam.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam.Data.EntityConfiguration
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Subject");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();

            builder.Property(s => s.Name).IsRequired();

            builder.HasOne(s => s.Teacher)
                .WithMany(u => u.Subjects)
                .HasForeignKey(s => s.TeacherId)
                .HasPrincipalKey(u => u.Id);

            builder.HasOne(s => s.Course)
                .WithMany(c => c.Subjects)
                .HasForeignKey(s => s.CourseId)
                .HasPrincipalKey(c => c.Id);
        }
    }
}
