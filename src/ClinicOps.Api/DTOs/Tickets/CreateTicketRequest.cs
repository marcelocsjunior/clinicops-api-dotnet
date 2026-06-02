using System.ComponentModel.DataAnnotations;

namespace ClinicOps.Api.DTOs.Tickets;

public class CreateTicketRequest
{
    public int? ClinicId { get; set; }

    public int? AssetId { get; set; }

    [Required]
    [MaxLength(120)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [MaxLength(1000)]
    public string Description { get; set; } = string.Empty;

    [MaxLength(20)]
    public string Priority { get; set; } = string.Empty;
}
