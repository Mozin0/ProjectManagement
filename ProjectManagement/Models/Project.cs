using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Models
{
    public class Project
    {
        public Guid Id { get; set; }
        [Required(AllowEmptyStrings = false ,ErrorMessage = "Project name is required")]
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public List<ProjectTask>? Tasks { get; set; } = [];
        public int? StatusId {get; set; } 
        public Status? Status { get; set; }
    }
}