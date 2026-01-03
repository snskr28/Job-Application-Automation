using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobAutomation.Domain.Common;

namespace JobAutomation.Domain.Entities
{
    public class EmailDraft : BaseEntity
    {
        public Guid JobId { get; private set; }
        public Guid UserId { get; private set; }
        public string Subject { get; private set; }
        public string Body { get; private set; }
        public bool GeneratedByAI { get; private set; }

        private EmailDraft() { }

        public EmailDraft(
            Guid jobId,
            Guid userId,
            string subject,
            string body,
            bool generatedByAI)
        {
            JobId = jobId;
            UserId = userId;
            Subject = subject;
            Body = body;
            GeneratedByAI = generatedByAI;
        }

        public void UpdateContent(string subject, string body)
        {
            Subject = subject;
            Body = body;
            GeneratedByAI = false;
        }
    }
}
