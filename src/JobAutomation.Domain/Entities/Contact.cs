using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobAutomation.Domain.Common;

namespace JobAutomation.Domain.Entities
{
    public class Contact : BaseEntity
    {
        public string Email { get; private set; }
        public string CompanyName { get; private set; }
        public string? JobProfile { get; private set; }

        private Contact() { }

        public Contact(string email, string companyName, string? jobProfile)
        {
            Email = email.Trim().ToLower();
            CompanyName = companyName.Trim();
            JobProfile = jobProfile?.Trim();
        }
    }
}
