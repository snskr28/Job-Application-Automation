using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobAutomation.Domain.Entities;

namespace JobAutomation.Application.Interfaces.Persistence
{
    public interface IJobRepository
    {
        Task<Job?> GetByIdAsync(Guid jobId, CancellationToken cancellationToken = default);

        Task AddAsync(Job job, CancellationToken cancellationToken = default);

        Task UpdateAsync(Job job, CancellationToken cancellationToken = default);
    }
}
