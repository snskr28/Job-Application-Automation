using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JobAutomation.Infrastructure.Persistence
{
    public class JobAutomationDbContextFactory
        : IDesignTimeDbContextFactory<JobAutomationDbContext>
    {
        public JobAutomationDbContext CreateDbContext(string[] args)
        {
            // Always resolve from solution root
            var basePath = Path.GetFullPath(
                Path.Combine(
                    AppContext.BaseDirectory,
                    "..", "..", "..", "..", ".."));

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile(
                    "src/JobAutomation.API/appsettings.json",
                    optional: false,
                    reloadOnChange: false)
                .Build();

            var optionsBuilder =
                new DbContextOptionsBuilder<JobAutomationDbContext>();

            optionsBuilder.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"));

            return new JobAutomationDbContext(optionsBuilder.Options);
        }
    }
}
