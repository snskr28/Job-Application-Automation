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
    public class RecruiterContactConfiguration : IEntityTypeConfiguration<RecruiterContact>
    {
        public void Configure(EntityTypeBuilder<RecruiterContact> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Name)
                .HasMaxLength(150);

            builder.Property(x => x.AddedManually)
                .IsRequired();

            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.HasOne<Company>()
                .WithMany()
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
