using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Dto;
using ProjectManagement.ManagerInterfaces;
using ProjectManagement.Managers;

namespace ProjectManagement.Controllers
{
    [ApiController]
    [Route("api/v1/projects")]
    public class ProjectController(IProjectManager manager) : ControllerBase
    {
        private readonly IProjectManager _manager = manager;

        [HttpGet]
        public IActionResult Get()
        {
            var projects = _manager.GetProjectsList();
            if (projects == null)
            {
                return NotFound(projects);  
            }
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var project = await _manager.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound(project);  
            }
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(ProjectDto projectDto)
        {
            var project = await _manager.PostProjectAsync(projectDto);
            if (project == null)
            {
                return NotFound(project);  
            }
            return Created(string.Empty, project);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, ProjectDto project)
        {
            var projectObj = await _manager.PutProjectAsync(id, project);
            if (projectObj == null)
            {
                return NotFound(projectObj);  
            }
            return Ok(projectObj);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _manager.DeleteProjectAsync(id);
            return Ok();
        }
    }
}