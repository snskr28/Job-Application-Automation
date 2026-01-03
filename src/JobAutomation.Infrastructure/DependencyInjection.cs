using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobAutomation.Application.Interfaces.AI;
using JobAutomation.Application.Interfaces.FileSystem;
using JobAutomation.Infrastructure.AI;
using JobAutomation.Infrastructure.FileSystem;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

            return services;
        }
    }
}
