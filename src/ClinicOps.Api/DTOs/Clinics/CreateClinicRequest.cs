using System.ComponentModel.DataAnnotations;

namespace ClinicOps.Api.DTOs.Clinics;

public class CreateClinicRequest
{
    [Required]
    [MaxLength(120)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(80)]
    public string City { get; set; } = string.Empty;

    [Required]
    [MaxLength(2)]
    public string State { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;
}
