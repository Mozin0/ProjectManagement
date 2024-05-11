using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjectManagement.Dto;
public class ProjectDto
{
    public Guid Id { get; set; } = Guid.Empty;
    [Required]
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTimeOffset Deadline { get; set; }

    public List<ProjectTaskDto>? Tasks { get; set; } = [];
    public int? StatusId {get; set; }
    [JsonIgnore]
    public StatusDto? Status { get; set; }
}