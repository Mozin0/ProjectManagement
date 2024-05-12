using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Dto;
public class StatusDto
{
    public int? Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
}