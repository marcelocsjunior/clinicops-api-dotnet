using ClinicOps.Api.Data;
using ClinicOps.Api.DTOs.Clinics;
using ClinicOps.Api.Models;
using ClinicOps.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicOps.Api.Services.Implementations;

public class ClinicService : IClinicService
{
    private readonly ClinicOpsDbContext _dbContext;

    public ClinicService(ClinicOpsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<ClinicResponse>> GetAllAsync()
    {
        return await _dbContext.Clinics
            .AsNoTracking()
            .OrderBy(clinic => clinic.Id)
            .Select(clinic => ToResponse(clinic))
            .ToListAsync();
    }

    public async Task<ClinicResponse?> GetByIdAsync(int id)
    {
        var clinic = await _dbContext.Clinics
            .AsNoTracking()
            .FirstOrDefaultAsync(clinic => clinic.Id == id);

        return clinic is null ? null : ToResponse(clinic);
    }

    public async Task<ClinicResponse> CreateAsync(CreateClinicRequest request)
    {
        var clinic = new Clinic
        {
            Name = request.Name,
            City = request.City,
            State = request.State,
            IsActive = request.IsActive,
            CreatedAt = DateTime.UtcNow
        };

        _dbContext.Clinics.Add(clinic);
        await _dbContext.SaveChangesAsync();

        return ToResponse(clinic);
    }

    public async Task<ClinicResponse?> UpdateAsync(int id, UpdateClinicRequest request)
    {
        var clinic = await _dbContext.Clinics.FindAsync(id);

        if (clinic is null)
        {
            return null;
        }

        clinic.Name = request.Name;
        clinic.City = request.City;
        clinic.State = request.State;
        clinic.IsActive = request.IsActive;
        clinic.UpdatedAt = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync();

        return ToResponse(clinic);
    }

    public async Task<DeleteClinicResult> DeleteAsync(int id)
    {
        var clinic = await _dbContext.Clinics.FindAsync(id);

        if (clinic is null)
        {
            return DeleteClinicResult.NotFound;
        }

        var hasLinkedAssets = await _dbContext.Assets
            .AnyAsync(asset => asset.ClinicId == id);

        if (hasLinkedAssets)
        {
            return DeleteClinicResult.HasLinkedAssets;
        }

        _dbContext.Clinics.Remove(clinic);
        await _dbContext.SaveChangesAsync();

        return DeleteClinicResult.Deleted;
    }

    private static ClinicResponse ToResponse(Clinic clinic)
    {
        return new ClinicResponse
        {
            Id = clinic.Id,
            Name = clinic.Name,
            City = clinic.City,
            State = clinic.State,
            IsActive = clinic.IsActive,
            CreatedAt = clinic.CreatedAt,
            UpdatedAt = clinic.UpdatedAt
        };
    }
}
