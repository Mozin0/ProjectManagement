using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Models;
public class Status
{
    public int? Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
}