using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAutomation.Application.Features.EmailGeneration
{
    public class GenerateEmailResult
    {
        public Guid EmailDraftId { get; }
        public string Subject { get; }
        public string Body { get; }
        public bool GeneratedByAI { get; }

        public GenerateEmailResult(
            Guid emailDraftId,
            string subject,
            string body,
            bool generatedByAI)
        {
            EmailDraftId = emailDraftId;
            Subject = subject;
            Body = body;
            GeneratedByAI = generatedByAI;
        }
    }
}
