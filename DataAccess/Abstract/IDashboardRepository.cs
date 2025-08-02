
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IDashboardRepository
    {
        Task<int> GetTotalProjectsAsync();
        Task<int> GetTotalMessagesAsync();
        Task<int> GetRepliedMessagesAsync();
    }
}
