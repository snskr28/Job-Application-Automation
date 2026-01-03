using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobAutomation.Domain.Common;

namespace JobAutomation.Domain.Entities
{
    public class Job : BaseEntity
    {
        public Guid CompanyId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Location { get; private set; }
        public string JobUrl { get; private set; }
        public DateTime DiscoveredAt { get; private set; }
        public bool IsInterested { get; private set; }

        private Job() { }

        public Job(
            Guid companyId,
            string title,
            string description,
            string location,
            string jobUrl)
        {
            CompanyId = companyId;
            Title = title;
            Description = description;
            Location = location;
            JobUrl = jobUrl;
            DiscoveredAt = DateTime.UtcNow;
            IsInterested = false;
        }

        public void MarkAsInterested()
        {
            IsInterested = true;
        }

        public void Ignore()
        {
            IsInterested = false;
        }
    }
}
