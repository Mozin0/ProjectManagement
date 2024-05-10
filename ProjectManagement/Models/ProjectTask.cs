using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjectManagement.Models;
public class ProjectTask
{
    public Guid Id { get; set; } = Guid.Empty;
    [Required(AllowEmptyStrings = false ,ErrorMessage = "Task name is required")]
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime Deadline { get; set; }

    // Sub Tasks
    public Guid? ParentTaskId { get; set; } = Guid.Empty;
    [JsonIgnore]
    public ProjectTask? ParentTask { get; set; } 
    public List<ProjectTask>? SubTasks { get; set; } = [];

    public Guid ProjectID { get; set; } = Guid.Empty;
    [JsonIgnore]
    public Project? Project { get; set; }
    public int? StatusId {get; set; }
    [JsonIgnore]
    public Status? Status { get; set; }
}