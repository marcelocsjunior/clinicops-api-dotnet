using ClinicOps.Api.DTOs.Technicians;

namespace ClinicOps.Api.Services.Interfaces;

public enum DeleteTechnicianResult
{
    Deleted,
    NotFound,
    HasLinkedMaintenanceLogs
}

public interface ITechnicianService
{
    Task<IReadOnlyList<TechnicianResponse>> GetAllAsync();
    Task<TechnicianResponse?> GetByIdAsync(int id);
    Task<TechnicianResponse> CreateAsync(CreateTechnicianRequest request);
    Task<TechnicianResponse?> UpdateAsync(int id, UpdateTechnicianRequest request);
    Task<DeleteTechnicianResult> DeleteAsync(int id);
}
