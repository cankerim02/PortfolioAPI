using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProjectServicesManager : IProjectServices
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectServicesManager(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

       
        public async Task AddAsync(Project project) 
            => _projectRepository.AddProjectAsync(project);
       

        public Task DeleteAsync(int id)
          => _projectRepository.DeleteProjectAsync(id);

        public Task<List<Project>> GetAllAsync()
           => _projectRepository.GetAllProjectAsync();

        public Task<Project?> GetByIdAsync(int id)
           => _projectRepository.GetProjectByIdAsync(id);

        public Task UpdateAsync(Project project)
            => _projectRepository.UpdateProjectAsync(project);
    }
}
