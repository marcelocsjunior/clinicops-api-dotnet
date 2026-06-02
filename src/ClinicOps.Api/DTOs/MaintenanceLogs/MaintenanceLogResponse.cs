namespace ClinicOps.Api.DTOs.MaintenanceLogs;

public class MaintenanceLogResponse
{
    public int Id { get; set; }
    public int AssetId { get; set; }
    public string AssetName { get; set; } = string.Empty;
    public int TechnicianId { get; set; }
    public string TechnicianName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime PerformedAt { get; set; }
    public DateTime CreatedAt { get; set; }
}
