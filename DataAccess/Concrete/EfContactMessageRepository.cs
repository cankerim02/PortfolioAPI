using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfContactMessageRepository : IContactMessageRepository
    {
        private readonly ApplicationDbContext _context;

        public EfContactMessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddContactAsync(ContactMessage contactMessage)
        {
            await _context.ContactMessages.AddAsync(contactMessage);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContactAsync(int id)
        {
            var contactMessage = await _context.ContactMessages.FindAsync(id);
            if (contactMessage != null)
            {
                _context.ContactMessages.Remove(contactMessage);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ContactMessage>> GetAllContactAsync()
        {
            return await _context.ContactMessages.ToListAsync();
        }

        public async Task<ContactMessage> GetByIdContactAsync(int id)
        {
            return await _context.ContactMessages.FindAsync(id);
        }

        public async Task UpdateContactAsync(ContactMessage contactMessage)
        {
            _context.ContactMessages.Update(contactMessage);
            await _context.SaveChangesAsync();
        }
    }
}
