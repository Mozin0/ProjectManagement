using Microsoft.EntityFrameworkCore;
using ProjectManagement.DbContexts;
using ProjectManagement.Dto;
using ProjectManagement.ManagerInterfaces;
using ProjectManagement.Mappers;
using ProjectManagement.Models;

namespace ProjectManagement.Managers
{
    public class ProjectManager(ProjectManagementDbContext dbcontext) : IProjectManager
    {
        private readonly ProjectManagementDbContext _dbcontext = dbcontext;

        public IQueryable<ProjectDto> GetProjects()
        {
            var projects = _dbcontext.Projects;
            return projects.Select(p => p.ToDto());
        }

        public List<ProjectDto> GetProjectsList()
        {
            var projects = _dbcontext.Projects.ToList();
            return projects.Select(p => p.ToDto()).ToList();
        }

        public async Task<Project> GetProjectByIdAsync(Guid id)
        {
            return await _dbcontext.Projects.SingleAsync(p => p.Id == id);
        }

        public async Task<ProjectDto> PostProjectAsync(ProjectDto projectDto)
        {
           var project = new Project();
           projectDto.ToEntity(project);
           await _dbcontext.Projects.AddAsync(project);
           await _dbcontext.SaveChangesAsync();
           return project.ToDto();
        }

        public async Task<ProjectDto> PutProjectAsync(Guid id, ProjectDto updateProjectDto)
        {
            var project = await GetProjectByIdAsync(id) ?? throw new Exception("Project Doesn't Exist.");
            updateProjectDto.ToEntity(project);
            await _dbcontext.SaveChangesAsync();
            return project.ToDto();
        }

        public async Task DeleteProjectAsync(Guid id)
        {
            var project = await GetProjectByIdAsync(id);
            if (project != null)
            {
                _dbcontext.Projects.Remove(project);
                await _dbcontext.SaveChangesAsync();
            }
        }
    }
}