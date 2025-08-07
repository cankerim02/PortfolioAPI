using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAndPasswordAsync(string email, string password);
        Task<User> GetByEmailAsync(string email);
        Task AddAsync(User user);
    }
}
