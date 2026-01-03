using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAutomation.Application.DTOs
{
    public class GenerateEmailRequest
    {
        // Option 1: existing job
        public Guid? JobId { get; set; }

        // Option 2: create new job
        public string? CompanyName { get; set; }
        public string? JobTitle { get; set; }
        public string? JobDescription { get; set; }
        public string? JobLocation { get; set; }
        public string? JobUrl { get; set; }

        // Required
        public Guid UserId { get; set; }
    }
}
