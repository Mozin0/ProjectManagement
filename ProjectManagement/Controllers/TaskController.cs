using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Dto;
using ProjectManagement.Managers;

namespace ProjectManagement.Controllers
{
    [ApiController]
    [Route("api/v1/tasks")]
    public class TaskController(TaskManager manager) : ControllerBase
    {
        private readonly TaskManager _manager = manager;

        [HttpGet]
        public IActionResult Get()
        {
            var projects = _manager.GetTasks();
            if (projects == null)
            {
                return NotFound(projects);  
            }
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var task = await _manager.GetTaskByIdAsync(id);
            if (task == null)
            {
                return NotFound(task);  
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(ProjectTaskDto projectTaskDto)
        {
            var task = await _manager.PostTaskAsync(projectTaskDto);
            if (task == null)
            {
                return NotFound(task);  
            }
            return Created(string.Empty, task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, ProjectTaskDto projectTaskDto)
        {
            var task = await _manager.PutTaskAsync(id, projectTaskDto);
            if (task == null)
            {
                return NotFound(task);  
            }
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _manager.DeleteTaskAsync(id);
            return Ok();
        }

        // Sub Tasks
         [HttpPost("{parentId}/subtasks")]
        public async Task<IActionResult> PostSubAsync(Guid parentId, ProjectTaskDto projectTaskDto)
        {
            var subTask = await _manager.PostSubTaskAsync(parentId, projectTaskDto);
            if (subTask == null)
            {
                return NotFound(subTask);  
            }
            return Created(string.Empty, subTask);
        }

        [HttpPut("{parentId}subtasks/{id}")]
        public async Task<IActionResult> PutSubAsync(Guid parentId, Guid id, ProjectTaskDto projectTaskDto)
        {
            var subTask = await _manager.PutTaskAsync(id, projectTaskDto);
            if (subTask == null)
            {
                return NotFound(subTask);  
            }
            return Ok(subTask);
        }
    }
}