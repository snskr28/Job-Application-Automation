using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobAutomation.Domain.Common;
using JobAutomation.Domain.Enums;

namespace JobAutomation.Domain.Entities
{
    public class Application : BaseEntity
    {
        public Guid JobId { get; private set; }
        public Guid RecruiterContactId { get; private set; }
        public Guid EmailDraftId { get; private set; }
        public ApplicationStatus Status { get; private set; }
        public DateTime? SentAt { get; private set; }

        private Application() { }

        public Application(
            Guid jobId,
            Guid recruiterContactId,
            Guid emailDraftId)
        {
            JobId = jobId;
            RecruiterContactId = recruiterContactId;
            EmailDraftId = emailDraftId;
            Status = ApplicationStatus.Draft;
        }

        public void MarkAsSent()
        {
            Status = ApplicationStatus.Sent;
            SentAt = DateTime.UtcNow;
        }

        public void MarkAsReplied()
        {
            Status = ApplicationStatus.Replied;
        }
    }
}
