using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobAutomation.Domain.Entities;

namespace JobAutomation.Application.Interfaces.Persistence
{
    public interface IEmailDraftRepository
    {
        Task AddAsync(EmailDraft emailDraft, CancellationToken cancellationToken = default);

        Task<EmailDraft?> GetByIdAsync(Guid emailDraftId, CancellationToken cancellationToken = default);
    }
}
