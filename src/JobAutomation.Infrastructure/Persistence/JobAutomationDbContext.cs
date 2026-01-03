using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobAutomation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobAutomation.Infrastructure.Persistence
{
    public class JobAutomationDbContext : DbContext
    {
        public JobAutomationDbContext(DbContextOptions<JobAutomationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Company> Companies => Set<Company>();
        public DbSet<Job> Jobs => Set<Job>();
        public DbSet<RecruiterContact> RecruiterContacts => Set<RecruiterContact>();
        public DbSet<EmailDraft> EmailDrafts => Set<EmailDraft>();
        public DbSet<JobAutomation.Domain.Entities.Application> Applications => Set<JobAutomation.Domain.Entities.Application>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(JobAutomationDbContext).Assembly);
        }
    }
}
