using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjectManagement.Models;
public class Project
{
    public Guid Id { get; set; } = Guid.Empty;
    [Required(AllowEmptyStrings = false ,ErrorMessage = "Project name is required")]
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTimeOffset Deadline { get; set; }
    public List<ProjectTask>? Tasks { get; set; } = [];
    public int? StatusId {get; set; } 
    [JsonIgnore]
    public Status? Status { get; set; }
}