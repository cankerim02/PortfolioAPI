using Business.Abstract;
using DataAccess.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DashboardServiceManager : IDashboardService
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardServiceManager(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        public async Task<DashboardDto> GetDashboardDataAsync()
        {
            var totalProjects = await _dashboardRepository.GetTotalProjectsAsync();
            var totalMessages = await _dashboardRepository.GetTotalMessagesAsync();
            var repliedMessages = await _dashboardRepository.GetRepliedMessagesAsync();

            return new DashboardDto
            {
                TotalProjects = totalProjects,
                TotalMessages = totalMessages,
                RepliedMessages = repliedMessages
            };
        }
    }
}
