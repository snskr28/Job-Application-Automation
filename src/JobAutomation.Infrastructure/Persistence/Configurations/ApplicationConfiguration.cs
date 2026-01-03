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
    public class ApplicationConfiguration : IEntityTypeConfiguration<JobAutomation.Domain.Entities.Application>
    {
        public void Configure(EntityTypeBuilder<JobAutomation.Domain.Entities.Application> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.SentAt);

            builder.HasOne<Job>()
                .WithMany()
                .HasForeignKey(x => x.JobId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<RecruiterContact>()
                .WithMany()
                .HasForeignKey(x => x.RecruiterContactId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<EmailDraft>()
                .WithMany()
                .HasForeignKey(x => x.EmailDraftId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.CreatedAt)
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(x => x.Status)
                .HasConversion<int>()
                .IsRequired();
        }
    }
}
