using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobAutomation.Application.Interfaces.AI;
using JobAutomation.Application.Interfaces.FileSystem;
using JobAutomation.Domain.Entities;

namespace JobAutomation.Application.Features.EmailGeneration
{
    public class GenerateEmailHandler
    {
        private readonly ILLMService _llmService;
        private readonly IPromptReader _promptReader;

        public GenerateEmailHandler(
            ILLMService llmService,
            IPromptReader promptReader)
        {
            _llmService = llmService;
            _promptReader = promptReader;
        }

        public async Task<GenerateEmailResult> HandleAsync(
            GenerateEmailCommand command,
            Job job,
            User user,
            CancellationToken cancellationToken = default)
        {
            var systemPrompt =
                await _promptReader.ReadAsync("system", cancellationToken);

            var userPromptTemplate =
                await _promptReader.ReadAsync(command.PromptType, cancellationToken);

            var userPrompt = userPromptTemplate
                .Replace("{{JobTitle}}", job.Title)
                .Replace("{{CompanyName}}", "Company") // placeholder for now
                .Replace("{{JobDescription}}", job.Description)
                .Replace("{{ResumeText}}", user.ResumePath)
                .Replace("{{Tone}}", user.PreferredTone);

            var emailBody = await _llmService.GenerateAsync(
                systemPrompt,
                userPrompt,
                cancellationToken);

            var emailDraft = new EmailDraft(
                job.Id,
                subject: $"Application for {job.Title}",
                body: emailBody,
                generatedByAI: true);

            return new GenerateEmailResult(
                emailDraft.Id,
                emailDraft.Subject,
                emailDraft.Body,
                emailDraft.GeneratedByAI);
        }
    }
}
