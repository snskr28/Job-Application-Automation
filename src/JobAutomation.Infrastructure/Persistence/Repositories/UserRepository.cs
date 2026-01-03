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
    public class UserRepository : IUserRepository
    {
        private readonly JobAutomationDbContext _context;

        public UserRepository(JobAutomationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);
        }

        public async Task UpdateAsync(User user, CancellationToken cancellationToken)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
