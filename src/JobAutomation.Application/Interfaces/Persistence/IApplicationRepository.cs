using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobAutomation.Domain.Entities;

namespace JobAutomation.Application.Interfaces.Persistence
{
    public interface IApplicationRepository
    {
        Task AddAsync(JobAutomation.Domain.Entities.Application application, CancellationToken cancellationToken = default);

        Task<JobAutomation.Domain.Entities.Application?> GetByIdAsync(Guid applicationId, CancellationToken cancellationToken = default);

        Task UpdateAsync(JobAutomation.Domain.Entities.Application application, CancellationToken cancellationToken = default);
    }
}
