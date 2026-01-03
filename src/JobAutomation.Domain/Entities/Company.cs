using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobAutomation.Domain.Common;

namespace JobAutomation.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; private set; }
        public string CareerPageUrl { get; private set; }
        public string Website { get; private set; }

        private Company() { }

        public Company(string name, string careerPageUrl, string website)
        {
            Name = name;
            CareerPageUrl = careerPageUrl;
            Website = website;
        }

        public void UpdateCareerPage(string careerPageUrl)
        {
            CareerPageUrl = careerPageUrl;
        }

        public void UpdateWebsite(string website)
        {
            Website = website;
        }
    }
}
