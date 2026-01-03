using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using JobAutomation.Application.Interfaces.AI;
using JobAutomation.Application.Interfaces.FileSystem;
using JobAutomation.Application.Interfaces.Persistence;
using JobAutomation.Domain.Entities;

namespace JobAutomation.Application.Features.EmailGeneration
{
    public class GenerateEmailHandler
    {
        private readonly ILLMService _llmService;
        private readonly IPromptReader _promptReader;
        private readonly IUserRepository _userRepository;
        private readonly IJobRepository _jobRepository;
        private readonly IEmailDraftRepository _emailDraftRepository;

        public GenerateEmailHandler(
            ILLMService llmService,
            IPromptReader promptReader,
            IUserRepository userRepository,
            IJobRepository jobRepository,
            IEmailDraftRepository emailDraftRepository)
        {
            _llmService = llmService;
            _promptReader = promptReader;
            _userRepository = userRepository;
            _jobRepository = jobRepository;
            _emailDraftRepository = emailDraftRepository;
        }

        public async Task<GenerateEmailResult> HandleAsync(
    GenerateEmailCommand command,
    CancellationToken cancellationToken)
        {
            var user = await _userRepository
                .GetByIdAsync(command.UserId, cancellationToken)
                ?? throw new InvalidOperationException("User not found");

            var job = await _jobRepository
                .GetByIdAsync(command.JobId, cancellationToken)
                ?? throw new InvalidOperationException("Job not found");

            var systemPrompt =
                await _promptReader.ReadAsync("system", cancellationToken);

            var userPromptTemplate =
                await _promptReader.ReadAsync(command.PromptType, cancellationToken);

            var userPrompt = userPromptTemplate
                .Replace("{{JobTitle}}", job.Title)
                .Replace("{{CompanyName}}", job.CompanyName ?? "your team")
                .Replace("{{JobDescription}}", job.Description)
                .Replace("{{ResumeText}}", user.ResumePath)
                .Replace("{{Tone}}", user.PreferredTone);

            var emailBody = await _llmService.GenerateAsync(
                systemPrompt,
                userPrompt,
                cancellationToken);

            emailBody = Regex.Replace(
                emailBody,
                @"(?i)(best regards|sincerely|regards)[\s\S]*$",
                string.Empty
            ).Trim();

            emailBody += $"\n\nBest regards,\n{user.FullName}";

            var emailDraft = new EmailDraft(
                jobId: job.Id,
                userId: user.Id,
                subject: $"Application for {job.Title}",
                body: emailBody,
                generatedByAI: true
            );

            await _emailDraftRepository.AddAsync(emailDraft, cancellationToken);

            return new GenerateEmailResult(
                emailDraft.Id,
                emailDraft.Subject,
                emailDraft.Body,
                true);
        }
    }
}
