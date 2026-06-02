namespace ClinicOps.Api.Models;

public class MaintenanceLog
{
    public int Id { get; set; }
    public int AssetId { get; set; }
    public int TechnicianId { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime PerformedAt { get; set; } = DateTime.UtcNow;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Asset? Asset { get; set; }
    public Technician? Technician { get; set; }
}
