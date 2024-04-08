using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Dto
{
    public class ProjectTaskDto
    {
        public Guid Id { get; set; }
        [Required(AllowEmptyStrings = false ,ErrorMessage = "Task name is required")]
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        
        // Sub Tasks
        public Guid? ParentTaskId { get; set; }
        public ProjectTaskDto? ParentTask { get; set; } 
        public List<ProjectTaskDto>? SubTasks { get; set; } = [];

        public Guid ProjectID { get; set; }
        public ProjectDto? Project { get; set; }
        public int? StatusId {get; set; }
        public StatusDto? Status { get; set; }
    }
}