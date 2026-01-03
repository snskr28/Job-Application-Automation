using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace JobAutomation.Infrastructure.Persistence
{
    public class JobAutomationDbContextFactory
        : IDesignTimeDbContextFactory<JobAutomationDbContext>
    {
        public JobAutomationDbContext CreateDbContext(string[] args)
        {
            var basePath = Path.GetFullPath(
                Path.Combine(
                    AppContext.BaseDirectory,
                    "..", "..", "..", "..", ".."));

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile(
                    "src/JobAutomation.API/appsettings.json",
                    optional: false)
                .Build();

            var optionsBuilder =
                new DbContextOptionsBuilder<JobAutomationDbContext>();

            optionsBuilder
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                .ConfigureWarnings(w =>
                    w.Ignore(RelationalEventId.PendingModelChangesWarning));

            return new JobAutomationDbContext(optionsBuilder.Options);
        }
    }
}
