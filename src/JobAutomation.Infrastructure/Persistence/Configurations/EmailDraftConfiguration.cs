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
    public class EmailDraftConfiguration : IEntityTypeConfiguration<EmailDraft>
    {
        public void Configure(EntityTypeBuilder<EmailDraft> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Subject)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(x => x.Body)
                .IsRequired();

            builder.Property(x => x.GeneratedByAI)
                .IsRequired();

            builder.HasOne<Job>()
                .WithMany()
                .HasForeignKey(x => x.JobId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.CreatedAt)
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(x => x.UserId)
                .IsRequired();
        }
    }
}
