using Exam.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam.Data.EntityConfiguration
{
    public class StudentConfiguraton : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");

            builder.Property(s => s.GroupId).IsRequired();
            builder.Property(s => s.BankAccout).IsRequired(false);

            builder.HasOne(u => u.Group)
                .WithMany(g => g.Students)
                .HasForeignKey(u => u.GroupId)
                .HasPrincipalKey(g => g.Id);
        }
    }
}
