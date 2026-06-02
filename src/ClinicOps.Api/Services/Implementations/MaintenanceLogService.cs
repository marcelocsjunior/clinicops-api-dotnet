using ClinicOps.Api.Data;
using ClinicOps.Api.DTOs.MaintenanceLogs;
using ClinicOps.Api.Models;
using ClinicOps.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicOps.Api.Services.Implementations;

public class MaintenanceLogService : IMaintenanceLogService
{
    private readonly ClinicOpsDbContext _dbContext;

    public MaintenanceLogService(ClinicOpsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<MaintenanceLogResponse>> GetAllAsync()
    {
        return await _dbContext.MaintenanceLogs
            .AsNoTracking()
            .Include(log => log.Asset)
            .Include(log => log.Technician)
            .OrderBy(log => log.Id)
            .Select(log => ToResponse(log))
            .ToListAsync();
    }

    public async Task<MaintenanceLogResponse?> GetByIdAsync(int id)
    {
        var maintenanceLog = await _dbContext.MaintenanceLogs
            .AsNoTracking()
            .Include(log => log.Asset)
            .Include(log => log.Technician)
            .FirstOrDefaultAsync(log => log.Id == id);

        return maintenanceLog is null ? null : ToResponse(maintenanceLog);
    }

    public async Task<CreateMaintenanceLogResult> CreateAsync(CreateMaintenanceLogRequest request)
    {
        var assetExists = await _dbContext.Assets
            .AnyAsync(asset => asset.Id == request.AssetId);

        if (!assetExists)
        {
            return new CreateMaintenanceLogResult { Status = CreateMaintenanceLogResultStatus.AssetNotFound };
        }

        var technicianExists = await _dbContext.Technicians
            .AnyAsync(technician => technician.Id == request.TechnicianId);

        if (!technicianExists)
        {
            return new CreateMaintenanceLogResult { Status = CreateMaintenanceLogResultStatus.TechnicianNotFound };
        }

        var now = DateTime.UtcNow;
        var maintenanceLog = new MaintenanceLog
        {
            AssetId = request.AssetId,
            TechnicianId = request.TechnicianId,
            Description = request.Description,
            PerformedAt = request.PerformedAt ?? now,
            CreatedAt = now
        };

        _dbContext.MaintenanceLogs.Add(maintenanceLog);
        await _dbContext.SaveChangesAsync();

        var response = await GetByIdAsync(maintenanceLog.Id);

        return new CreateMaintenanceLogResult
        {
            Status = CreateMaintenanceLogResultStatus.Created,
            MaintenanceLog = response
        };
    }

    private static MaintenanceLogResponse ToResponse(MaintenanceLog maintenanceLog)
    {
        return new MaintenanceLogResponse
        {
            Id = maintenanceLog.Id,
            AssetId = maintenanceLog.AssetId,
            AssetName = maintenanceLog.Asset?.Name ?? string.Empty,
            TechnicianId = maintenanceLog.TechnicianId,
            TechnicianName = maintenanceLog.Technician?.FullName ?? string.Empty,
            Description = maintenanceLog.Description,
            PerformedAt = maintenanceLog.PerformedAt,
            CreatedAt = maintenanceLog.CreatedAt
        };
    }
}
