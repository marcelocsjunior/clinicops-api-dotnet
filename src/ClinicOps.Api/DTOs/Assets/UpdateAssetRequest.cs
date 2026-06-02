using System.ComponentModel.DataAnnotations;

namespace ClinicOps.Api.DTOs.Assets;

public class UpdateAssetRequest
{
    [Range(1, int.MaxValue)]
    public int ClinicId { get; set; }

    [Required]
    [MaxLength(120)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(60)]
    public string AssetType { get; set; } = string.Empty;

    [MaxLength(120)]
    public string SerialNumber { get; set; } = string.Empty;

    [MaxLength(120)]
    public string Location { get; set; } = string.Empty;

    public bool IsActive { get; set; }
}
