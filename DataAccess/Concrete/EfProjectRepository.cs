using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;

        public EfProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddProjectAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProjectAsync(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Project>> GetAllProjectAsync()
        {
            var projects = await _context.Projects.ToListAsync();
          
            if (projects == null || !projects.Any())
                return new List<Project>();
            projects = projects.Select(p => new Project
            {
                Id = p.Id,
                Title = p.Title,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                Description = p.Description,
                ImageUrl = p.ImageUrl,
                ProjectUrl = p.ProjectUrl
            }).ToList();
            return projects;
        }

        public async Task<List<ProjectDto>> GetAllProjectDtoAsync()
        {
            return await _context.Projects
        .Select(p => new ProjectDto
        {
            Id = p.Id,
            ProjectName = p.Title,
            StartDate = p.StartDate,
            EndDate = p.EndDate
           
        })
        .ToListAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public async Task UpdateProjectAsync(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }
    }
}
