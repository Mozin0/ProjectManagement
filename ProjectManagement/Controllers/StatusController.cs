using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Dto;

using ProjectManagement.Managers;

namespace ProjectManagement.Controllers
{
    [ApiController]
    [Route("api/v1/statuses")]
    public class StatusController(StatusManager manager) : ControllerBase
    {
        private readonly StatusManager _manager = manager;

        [HttpGet]
        public IActionResult Get()
        {
            var status = _manager.GetStatuses();
            if (status == null)
            {
                return NotFound(status);  
            }
            return Ok(status);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var status = await _manager.GetStatusByIdAsync(id);
            if (status == null)
            {
                return NotFound(status);  
            }
            return Ok(status);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(StatusDto statusDto)
        {
            var status = await _manager.PostStatusAsync(statusDto);
            if (status == null)
            {
                return NotFound(status);  
            }
            return Created(string.Empty, status);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _manager.DeleteStatusAsync(id);
            return Ok();
        }
    }
}