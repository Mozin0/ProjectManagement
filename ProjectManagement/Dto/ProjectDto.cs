using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Dto
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public List<ProjectTaskDto>? Tasks { get; set; } = [];
        public int? StatusId {get; set; }
        public StatusDto? Status { get; set; }
    }
}