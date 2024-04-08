using ProjectManagement.Dto;
using ProjectManagement.Models;

namespace ProjectManagement.ManagerInterfaces
{
    public interface IProjectManager
    {
        public IQueryable<ProjectDto> GetProjects();
        public Task<Project> GetProjectByIdAsync(Guid id);
        public Task<ProjectDto> PostProjectAsync(ProjectDto projectDto);
        public Task<ProjectDto> PutProjectAsync(Guid id, ProjectDto updateProjectDto);
        public Task DeleteProjectAsync(Guid id);
        public List<ProjectDto> GetProjectsList();
    }
}