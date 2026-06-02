using ClinicOps.Api.DTOs.Assets;

namespace ClinicOps.Api.Services.Interfaces;

public enum DeleteAssetResult
{
    Deleted,
    NotFound,
    HasLinkedMaintenanceLogs
}

public interface IAssetService
{
    Task<IReadOnlyList<AssetResponse>> GetAllAsync();
    Task<AssetResponse?> GetByIdAsync(int id);
    Task<AssetResponse?> CreateAsync(CreateAssetRequest request);
    Task<AssetResponse?> UpdateAsync(int id, UpdateAssetRequest request);
    Task<DeleteAssetResult> DeleteAsync(int id);
}
