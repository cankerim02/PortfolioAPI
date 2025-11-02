using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfServiceLogRepository : IServiceLogRepository
    {
        private readonly ApplicationDbContext _context;
        public EfServiceLogRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ServiceLog log)
        {
           _context.ServiceLogs.Add(log);
            await _context.SaveChangesAsync();
        }
    }
}
