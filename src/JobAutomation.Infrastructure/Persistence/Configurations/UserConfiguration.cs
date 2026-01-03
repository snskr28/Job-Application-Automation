using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobAutomation.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace JobAutomation.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FullName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.ResumePath)
                .IsRequired();

            builder.Property(x => x.PreferredTone)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
