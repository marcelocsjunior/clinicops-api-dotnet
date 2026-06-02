using System.ComponentModel.DataAnnotations;

namespace ClinicOps.Api.DTOs.Tickets;

public class UpdateTicketRequest
{
    [Required]
    [MaxLength(120)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [MaxLength(1000)]
    public string Description { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string Priority { get; set; } = string.Empty;

    [Required]
    [MaxLength(30)]
    public string Status { get; set; } = string.Empty;
}
