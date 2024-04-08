using ProjectManagement.Dto;
using ProjectManagement.Models;

namespace ProjectManagement.ManagerInterfaces
{
    public interface ITaskManager
    {
        // Tasks
        public IQueryable<ProjectTaskDto> GetTasks();
        public Task<ProjectTask> GetTaskByIdAsync(Guid id);
        public Task<ProjectTaskDto> PostTaskAsync(ProjectTaskDto taskDto);
        public Task<ProjectTaskDto> PutTaskAsync(Guid id, ProjectTaskDto updateTaskDto);
        public Task DeleteTaskAsync(Guid id);
        
        // Sub Tasks
        public Task<ProjectTaskDto> PostSubTaskAsync(Guid parentId, ProjectTaskDto taskDto);
        public Task<ProjectTaskDto> PutSubTaskAsync(Guid id, ProjectTaskDto updateTaskDto);
    }
}