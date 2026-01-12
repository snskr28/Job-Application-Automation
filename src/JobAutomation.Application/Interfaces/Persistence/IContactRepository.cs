using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobAutomation.Domain.Entities;

namespace JobAutomation.Application.Interfaces.Persistence
{
    public interface IContactRepository
    {
        Task<bool> ExistsByEmailAsync(string email, CancellationToken ct);
        Task AddAsync(Contact contact, CancellationToken ct);
    }
}
