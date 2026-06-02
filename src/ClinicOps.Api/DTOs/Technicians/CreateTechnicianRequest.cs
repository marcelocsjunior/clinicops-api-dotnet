using System.ComponentModel.DataAnnotations;

namespace ClinicOps.Api.DTOs.Technicians;

public class CreateTechnicianRequest
{
    [Required]
    [MaxLength(120)]
    public string FullName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [MaxLength(120)]
    public string Email { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;
}
