using Microsoft.EntityFrameworkCore;
using ProjectManagement.DbContexts;
using ProjectManagement.Dto;
using ProjectManagement.Mappers;
using ProjectManagement.Models;

namespace ProjectManagement.Managers
{
    public class TaskManager(ProjectManagementDbContext dbcontext)
    {
        private readonly ProjectManagementDbContext _dbcontext = dbcontext;

        // Tasks
        public IEnumerable<ProjectTaskDto> GetTasks()
        {
            var tasks = _dbcontext.Tasks;
            return tasks.Select(t => t.ToDto());
        }

        public async Task<ProjectTask> GetTaskByIdAsync(Guid id)
        {
            return await _dbcontext.Tasks.SingleAsync(t => t.Id == id);
        }

        public async Task<ProjectTaskDto> PostTaskAsync(ProjectTaskDto projecTasktDto)
        {
           var projectTask = new ProjectTask();
           projecTasktDto.ToEntity(projectTask);
           await _dbcontext.Tasks.AddAsync(projectTask);
           await _dbcontext.SaveChangesAsync();
           return projectTask.ToDto();
        }       

        public async Task<ProjectTaskDto> PutTaskAsync(Guid id, ProjectTaskDto updateTaskDto)
        {
            var task = await GetTaskByIdAsync(id) ?? throw new Exception("Task Doesn't Exist.");
            updateTaskDto.ToEntity(task);
            await _dbcontext.SaveChangesAsync();
            return task.ToDto();
        }

        public async Task DeleteTaskAsync(Guid id)
        {
            var task = await GetTaskByIdAsync(id);
            if (task != null)
            {
                _dbcontext.Tasks.Remove(task);
                await _dbcontext.SaveChangesAsync();
            }
        }

        // Sub Tasks
        public async Task<ProjectTaskDto> PostSubTaskAsync(Guid parentId, ProjectTaskDto subTaskDto) 
        {
            var parentTask = await GetTaskByIdAsync(parentId);
            if (parentTask != null)
            {
                var subTask = new ProjectTask();
                subTaskDto.ToEntity(subTask);
                subTask.ParentTaskId = parentId;
                _dbcontext.Tasks.Add(subTask);
                await _dbcontext.SaveChangesAsync();
                return subTask.ToDto();
            }
            else {
                throw new Exception("Task Id doesn't exist");
            }
        }

        public async Task<ProjectTaskDto> PutSubTaskAsync(Guid id, ProjectTaskDto updateSubTaskDto)
        {
            var subTask = await GetTaskByIdAsync(id) ?? throw new Exception("Task Doesn't Exist.");
            updateSubTaskDto.ToEntity(subTask);
            await _dbcontext.SaveChangesAsync();
            return subTask.ToDto();
        }
    }
}