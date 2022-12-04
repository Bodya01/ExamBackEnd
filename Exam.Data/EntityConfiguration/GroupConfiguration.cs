using Exam.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam.Data.EntityConfiguration
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Group");

            builder.HasKey(g => g.Id);
            builder.Property(g => g.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(g => g.Name).IsRequired().HasMaxLength(10);
        }
    }
}
