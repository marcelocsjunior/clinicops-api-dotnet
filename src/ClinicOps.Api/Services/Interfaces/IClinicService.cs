using ClinicOps.Api.DTOs.Clinics;

namespace ClinicOps.Api.Services.Interfaces;

public enum DeleteClinicResult
{
    Deleted,
    NotFound,
    HasLinkedAssets
}

public interface IClinicService
{
    Task<IReadOnlyList<ClinicResponse>> GetAllAsync();
    Task<ClinicResponse?> GetByIdAsync(int id);
    Task<ClinicResponse> CreateAsync(CreateClinicRequest request);
    Task<ClinicResponse?> UpdateAsync(int id, UpdateClinicRequest request);
    Task<DeleteClinicResult> DeleteAsync(int id);
}
