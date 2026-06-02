namespace ClinicOps.Api.DTOs.Tickets;

public class CreateTicketRequest
{
    public int? ClinicId { get; set; }
    public int? AssetId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Priority { get; set; } = string.Empty;
}
