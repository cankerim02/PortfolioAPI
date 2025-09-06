using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
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
        private readonly IProjectRepository _projectRepository;


        public DashboardServiceManager(IDashboardRepository dashboardRepository, IProjectRepository projectRepository)
        {
            _dashboardRepository = dashboardRepository;
            _projectRepository = projectRepository;
        }

        public async Task<List<CalendarEventDto>> GetCalendarEventsAsync()
        {
            // projeleri çekip takvim formatına dönüştür
            var projects = await _projectRepository.GetAllProjectDtoAsync();

            var events = projects.Select(p => new CalendarEventDto
            {
                Title = p.ProjectName,
                Start = p.StartDate,
                End = p.EndDate,

            }).ToList();

            return events;
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
