using System.ComponentModel.DataAnnotations;

namespace ClinicOps.Api.DTOs.MaintenanceLogs;

public class CreateMaintenanceLogRequest
{
    [Range(1, int.MaxValue)]
    public int AssetId { get; set; }

    [Range(1, int.MaxValue)]
    public int TechnicianId { get; set; }

    [Required]
    [MaxLength(1000)]
    public string Description { get; set; } = string.Empty;

    public DateTime? PerformedAt { get; set; }
}
