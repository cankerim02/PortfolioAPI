using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _context;

        public DashboardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetTotalProjectsAsync()
        {
            return await _context.Projects.CountAsync();
        }

        public async Task<int> GetTotalMessagesAsync()
        {
            return await _context.ContactMessages.CountAsync();
        }

        public async Task<int> GetRepliedMessagesAsync()
        {
            return await _context.ContactMessages.Where(m => m.AdminReply !=null).CountAsync();
        }
    }

}
