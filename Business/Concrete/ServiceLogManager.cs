using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ServiceLogManager : IServiceLogServices
    {
        private readonly IServiceLogRepository _repo;
        public ServiceLogManager(IServiceLogRepository repo)
        {
            _repo = repo;
        }

        public async Task LogAsync(ServiceLog log)
        {
           await _repo.AddAsync(log);
        }
    }
}
