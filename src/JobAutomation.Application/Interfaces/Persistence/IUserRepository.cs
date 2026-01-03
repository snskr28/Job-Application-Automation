using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobAutomation.Domain.Entities;

namespace JobAutomation.Application.Interfaces.Persistence
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid userId, CancellationToken cancellationToken = default);

        Task UpdateAsync(User user, CancellationToken cancellationToken = default);
    }
}
