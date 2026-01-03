using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobAutomation.Application.Interfaces.AI;
using JobAutomation.Application.Interfaces.FileSystem;
using JobAutomation.Application.Interfaces.Persistence;
using JobAutomation.Infrastructure.AI;
using JobAutomation.Infrastructure.FileSystem;
using JobAutomation.Infrastructure.Persistence.Repositories;
using JobAutomation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Diagnostics;
using JobAutomation.Application.Interfaces.Email;
using JobAutomation.Infrastructure.Email;

namespace JobAutomation.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // Prompt reader
            services.AddSingleton<IPromptReader>(sp =>
            {
                var promptsPath = Path.Combine(
                    AppContext.BaseDirectory,
                    "Prompts");

                return new PromptFileReader(promptsPath);
            });

            // Ollama HTTP client
            services.AddHttpClient<ILLMService, OllamaLLMService>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:11434");
            });

            services.AddDbContext<JobAutomationDbContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"));

                // EF Core 9: prevent false-positive PendingModelChanges crash
                options.ConfigureWarnings(w =>
                    w.Ignore(RelationalEventId.PendingModelChangesWarning));
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IEmailDraftRepository, EmailDraftRepository>();
            services.AddScoped<IEmailSender, SmtpEmailSender>();

            return services;
        }
    }
}
