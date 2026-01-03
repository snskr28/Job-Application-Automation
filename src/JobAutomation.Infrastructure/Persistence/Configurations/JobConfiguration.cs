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
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Description)
                .IsRequired();

            builder.Property(x => x.Location)
                .HasMaxLength(100);

            builder.Property(x => x.JobUrl)
                .HasMaxLength(500);

            builder.HasIndex(x => x.CompanyId);
            builder.HasIndex(x => x.DiscoveredAt);
            builder.HasIndex(x => x.IsInterested);

            builder.Property(x => x.CreatedAt)
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(x => x.CompanyName)
                .IsRequired()
                .HasMaxLength(200);

        }
    }
}
