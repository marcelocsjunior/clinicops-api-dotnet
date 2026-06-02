using ClinicOps.Api.Data;
using ClinicOps.Api.DTOs.Technicians;
using ClinicOps.Api.Models;
using ClinicOps.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicOps.Api.Services.Implementations;

public class TechnicianService : ITechnicianService
{
    private readonly ClinicOpsDbContext _dbContext;

    public TechnicianService(ClinicOpsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<TechnicianResponse>> GetAllAsync()
    {
        return await _dbContext.Technicians
            .AsNoTracking()
            .OrderBy(technician => technician.Id)
            .Select(technician => ToResponse(technician))
            .ToListAsync();
    }

    public async Task<TechnicianResponse?> GetByIdAsync(int id)
    {
        var technician = await _dbContext.Technicians
            .AsNoTracking()
            .FirstOrDefaultAsync(technician => technician.Id == id);

        return technician is null ? null : ToResponse(technician);
    }

    public async Task<TechnicianResponse> CreateAsync(CreateTechnicianRequest request)
    {
        var technician = new Technician
        {
            FullName = request.FullName,
            Email = request.Email,
            IsActive = request.IsActive,
            CreatedAt = DateTime.UtcNow
        };

        _dbContext.Technicians.Add(technician);
        await _dbContext.SaveChangesAsync();

        return ToResponse(technician);
    }

    public async Task<TechnicianResponse?> UpdateAsync(int id, UpdateTechnicianRequest request)
    {
        var technician = await _dbContext.Technicians.FindAsync(id);

        if (technician is null)
        {
            return null;
        }

        technician.FullName = request.FullName;
        technician.Email = request.Email;
        technician.IsActive = request.IsActive;
        technician.UpdatedAt = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync();

        return ToResponse(technician);
    }

    public async Task<DeleteTechnicianResult> DeleteAsync(int id)
    {
        var technician = await _dbContext.Technicians.FindAsync(id);

        if (technician is null)
        {
            return DeleteTechnicianResult.NotFound;
        }

        var hasMaintenanceLogs = await _dbContext.MaintenanceLogs
            .AnyAsync(log => log.TechnicianId == id);

        if (hasMaintenanceLogs)
        {
            return DeleteTechnicianResult.HasLinkedMaintenanceLogs;
        }

        _dbContext.Technicians.Remove(technician);
        await _dbContext.SaveChangesAsync();

        return DeleteTechnicianResult.Deleted;
    }

    private static TechnicianResponse ToResponse(Technician technician)
    {
        return new TechnicianResponse
        {
            Id = technician.Id,
            FullName = technician.FullName,
            Email = technician.Email,
            IsActive = technician.IsActive,
            CreatedAt = technician.CreatedAt,
            UpdatedAt = technician.UpdatedAt
        };
    }
}
