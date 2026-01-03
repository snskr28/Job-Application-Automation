using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAutomation.Application.Features.EmailGeneration
{
    public class GenerateEmailCommand
    {
        public Guid JobId { get; }
        public Guid UserId { get; }
        public string PromptType { get; }

        public GenerateEmailCommand(
            Guid jobId,
            Guid userId,
            string promptType = "email_body")
        {
            JobId = jobId;
            UserId = userId;
            PromptType = promptType;
        }
    }
}
