using ClinicOps.Api.DTOs.MaintenanceLogs;

namespace ClinicOps.Api.Services.Interfaces;

public enum CreateMaintenanceLogResultStatus
{
    Created,
    AssetNotFound,
    TechnicianNotFound
}

public class CreateMaintenanceLogResult
{
    public CreateMaintenanceLogResultStatus Status { get; set; }
    public MaintenanceLogResponse? MaintenanceLog { get; set; }
}

public interface IMaintenanceLogService
{
    Task<IReadOnlyList<MaintenanceLogResponse>> GetAllAsync();
    Task<MaintenanceLogResponse?> GetByIdAsync(int id);
    Task<CreateMaintenanceLogResult> CreateAsync(CreateMaintenanceLogRequest request);
}
