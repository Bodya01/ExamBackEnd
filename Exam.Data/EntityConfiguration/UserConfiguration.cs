using Exam.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam.Data.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.GroupId).IsRequired(false);

            builder.HasOne(u => u.Group)
                .WithMany(g => g.Students)
                .HasForeignKey(u => u.GroupId)
                .HasPrincipalKey(g => g.Id);
        }
    }
}
