using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobAutomation.Domain.Common;

namespace JobAutomation.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string ResumePath { get; private set; }
        public string PreferredTone { get; private set; }

        private User() { }

        public User(
            string fullName,
            string email,
            string resumePath,
            string preferredTone)
        {
            FullName = fullName;
            Email = email;
            ResumePath = resumePath;
            PreferredTone = preferredTone;
        }

        public void UpdateResume(string resumePath)
        {
            ResumePath = resumePath;
        }

        public void UpdatePreferredTone(string preferredTone)
        {
            PreferredTone = preferredTone;
        }
    }
}
