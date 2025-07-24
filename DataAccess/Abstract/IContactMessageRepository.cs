using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IContactMessageRepository 
    {
        Task<List<ContactMessage>> GetAllContactAsync();
        Task<ContactMessage> GetByIdContactAsync(int id);
        Task AddContactAsync(ContactMessage contactMessage);
        Task UpdateContactAsync(ContactMessage contactMessage);
        Task DeleteContactAsync(int id);

    }
}
