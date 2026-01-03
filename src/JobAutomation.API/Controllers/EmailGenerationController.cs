using JobAutomation.Application.DTOs;
using JobAutomation.Application.Features.EmailGeneration;
using JobAutomation.Application.Interfaces.Persistence;
using JobAutomation.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobAutomation.API.Controllers
{
    [ApiController]
    [Route("api/email")]
    public class EmailGenerationController : ControllerBase
    {
        private readonly GenerateEmailHandler _handler;
        private readonly IJobRepository _jobRepository;

        public EmailGenerationController(
            GenerateEmailHandler handler,
            IJobRepository jobRepository)
        {
            _handler = handler;
            _jobRepository = jobRepository;
        }

        [HttpPost("generate")]
        public async Task<IActionResult> Generate(
            GenerateEmailRequest request,
            CancellationToken cancellationToken)
        {
            Guid jobId;

            // OPTION 1: Job already exists
            if (request.JobId.HasValue)
            {
                jobId = request.JobId.Value;
            }
            else
            {
                // OPTION 2: Create Job
                if (string.IsNullOrWhiteSpace(request.JobTitle) ||
                    string.IsNullOrWhiteSpace(request.JobDescription))
                {
                    return BadRequest("JobTitle and JobDescription are required");
                }

                var job = new Job(
                    companyId: Guid.NewGuid(),
                    companyName: request.CompanyName ?? "the hiring team",
                    title: request.JobTitle!,
                    description: request.JobDescription!,
                    location: request.JobLocation,
                    jobUrl: request.JobUrl
                );


                await _jobRepository.AddAsync(job, cancellationToken);
                jobId = job.Id;
            }

            var command = new GenerateEmailCommand(
                jobId: jobId,
                userId: request.UserId,
                promptType: "email_body"
            );

            var result = await _handler.HandleAsync(command, cancellationToken);

            return Ok(result);
        }

    }
}
