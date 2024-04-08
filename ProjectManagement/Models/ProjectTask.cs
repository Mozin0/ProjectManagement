using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Models
{
    public class ProjectTask
    {
        public Guid Id { get; set; }
        [Required(AllowEmptyStrings = false ,ErrorMessage = "Task name is required")]
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }

        // Sub Tasks
        public Guid? ParentTaskId { get; set; }
        public ProjectTask? ParentTask { get; set; } 
        public List<ProjectTask>? SubTasks { get; set; } = [];

        public Guid ProjectID { get; set; }
        public Project? Project { get; set; }
        public int? StatusId {get; set; }
        public Status? Status { get; set; }
    }
}