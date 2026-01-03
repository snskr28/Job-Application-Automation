using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobAutomation.Application.Interfaces.Persistence;
using JobAutomation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobAutomation.Infrastructure.Persistence.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly JobAutomationDbContext _context;

        public JobRepository(JobAutomationDbContext context)
        {
            _context = context;
        }

        public async Task<Job?> GetByIdAsync(Guid jobId, CancellationToken cancellationToken)
        {
            return await _context.Jobs
                .FirstOrDefaultAsync(x => x.Id == jobId, cancellationToken);
        }

        public async Task AddAsync(Job job, CancellationToken cancellationToken)
        {
            await _context.Jobs.AddAsync(job, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Job job, CancellationToken cancellationToken)
        {
            _context.Jobs.Update(job);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
