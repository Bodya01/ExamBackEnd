using Exam.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data.EntityConfiguration
{
    public class ListConfiguration : IEntityTypeConfiguration<List>
    {
        public void Configure(EntityTypeBuilder<List> builder)
        {
            builder.ToTable("List");

            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id).ValueGeneratedOnAdd();

            builder.Property(l => l.ListType).IsRequired();

            builder.HasMany(l => l.Students)
                .WithMany(u => u.Lists);
        }
    }
}
