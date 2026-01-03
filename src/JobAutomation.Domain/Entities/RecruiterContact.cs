using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobAutomation.Domain.Common;

namespace JobAutomation.Domain.Entities
{
    public class RecruiterContact : BaseEntity
    {
        public Guid CompanyId { get; private set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public bool AddedManually { get; private set; }

        private RecruiterContact() { }

        public RecruiterContact(
            Guid companyId,
            string email,
            string name = null,
            bool addedManually = true)
        {
            CompanyId = companyId;
            Email = email;
            Name = name;
            AddedManually = addedManually;
        }

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void UpdateEmail(string email)
        {
            Email = email;
        }
    }
}
