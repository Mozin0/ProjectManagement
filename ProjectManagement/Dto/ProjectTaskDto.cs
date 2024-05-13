using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjectManagement.Dto;
public class ProjectTaskDto
{
    public Guid Id { get; set; } = Guid.Empty;
    [Required(AllowEmptyStrings = false ,ErrorMessage = "Task name is required")]
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime Deadline { get; set; }
    
    
    // Sub Tasks
    public Guid? ParentTaskId { get; set; } = Guid.Empty;
    [JsonIgnore]
    public ProjectTaskDto? ParentTask { get; set; } 
    public List<ProjectTaskDto>? SubTasks { get; set; } = [];

    public Guid ProjectID { get; set; } = Guid.Empty;
    [JsonIgnore]
    public ProjectDto? Project { get; set; }
    public int? StatusId {get; set; }
    [JsonIgnore]
    public StatusDto? Status { get; set; }
}