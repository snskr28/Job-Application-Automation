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

            var userId = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(new
            {
                Id = userId,
                FullName = "Sanskar Bosmia",
                Email = "sanskarbosmia@gmail.com",
                ResumePath = "Full Stack Developer specializing in Angular and .NET with expertise in building high-performance REST APIs, advanced analytical dashboards, and scalable fintech applications. Experienced in Clean Architecture, Entity Framework Core, SQL optimization, and Azure cloud deployment.",
                PreferredTone = "professional",
                CreatedAt = DateTime.UtcNow
            });
        }
    }
}
