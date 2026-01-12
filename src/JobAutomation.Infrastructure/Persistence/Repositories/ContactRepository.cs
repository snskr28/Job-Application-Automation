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
    public class ContactRepository : IContactRepository
    {
        private readonly JobAutomationDbContext _context;

        public ContactRepository(JobAutomationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistsByEmailAsync(string email, CancellationToken ct)
        {
            return await _context.Contacts
                .AnyAsync(x => x.Email == email.ToLower(), ct);
        }

        public async Task AddAsync(Contact contact, CancellationToken ct)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync(ct);
        }
    }
}
