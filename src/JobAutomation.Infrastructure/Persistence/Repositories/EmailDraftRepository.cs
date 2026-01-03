using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobAutomation.Application.Interfaces.Persistence;
using JobAutomation.Domain.Entities;

namespace JobAutomation.Infrastructure.Persistence.Repositories
{
    public class EmailDraftRepository : IEmailDraftRepository
    {
        private readonly JobAutomationDbContext _context;

        public EmailDraftRepository(JobAutomationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(EmailDraft emailDraft, CancellationToken cancellationToken)
        {
            await _context.EmailDrafts.AddAsync(emailDraft, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<EmailDraft?> GetByIdAsync(Guid emailDraftId, CancellationToken cancellationToken)
        {
            return await _context.EmailDrafts.FindAsync(
                new object[] { emailDraftId }, cancellationToken);
        }
    }
}
