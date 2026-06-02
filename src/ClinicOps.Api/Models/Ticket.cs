namespace ClinicOps.Api.Models;

public class Ticket
{
    public int Id { get; set; }
    public int? ClinicId { get; set; }
    public int? AssetId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Priority { get; set; } = "Medium";
    public string Status { get; set; } = "Open";
    public DateTime OpenedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ClosedAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
