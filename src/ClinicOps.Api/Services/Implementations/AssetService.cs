using ClinicOps.Api.Data;
using ClinicOps.Api.DTOs.Assets;
using ClinicOps.Api.Models;
using ClinicOps.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicOps.Api.Services.Implementations;

public class AssetService : IAssetService
{
    private readonly ClinicOpsDbContext _dbContext;

    public AssetService(ClinicOpsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<AssetResponse>> GetAllAsync()
    {
        return await _dbContext.Assets
            .AsNoTracking()
            .OrderBy(asset => asset.Id)
            .Select(asset => ToResponse(asset))
            .ToListAsync();
    }

    public async Task<AssetResponse?> GetByIdAsync(int id)
    {
        var asset = await _dbContext.Assets
            .AsNoTracking()
            .FirstOrDefaultAsync(asset => asset.Id == id);

        return asset is null ? null : ToResponse(asset);
    }

    public async Task<AssetResponse?> CreateAsync(CreateAssetRequest request)
    {
        var clinicExists = await _dbContext.Clinics
            .AnyAsync(clinic => clinic.Id == request.ClinicId);

        if (!clinicExists)
        {
            return null;
        }

        var asset = new Asset
        {
            ClinicId = request.ClinicId,
            Name = request.Name,
            AssetType = request.AssetType,
            SerialNumber = request.SerialNumber,
            Location = request.Location,
            IsActive = request.IsActive,
            CreatedAt = DateTime.UtcNow
        };

        _dbContext.Assets.Add(asset);
        await _dbContext.SaveChangesAsync();

        return ToResponse(asset);
    }

    public async Task<AssetResponse?> UpdateAsync(int id, UpdateAssetRequest request)
    {
        var asset = await _dbContext.Assets.FindAsync(id);

        if (asset is null)
        {
            return null;
        }

        var clinicExists = await _dbContext.Clinics
            .AnyAsync(clinic => clinic.Id == request.ClinicId);

        if (!clinicExists)
        {
            return null;
        }

        asset.ClinicId = request.ClinicId;
        asset.Name = request.Name;
        asset.AssetType = request.AssetType;
        asset.SerialNumber = request.SerialNumber;
        asset.Location = request.Location;
        asset.IsActive = request.IsActive;
        asset.UpdatedAt = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync();

        return ToResponse(asset);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var asset = await _dbContext.Assets.FindAsync(id);

        if (asset is null)
        {
            return false;
        }

        _dbContext.Assets.Remove(asset);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    private static AssetResponse ToResponse(Asset asset)
    {
        return new AssetResponse
        {
            Id = asset.Id,
            ClinicId = asset.ClinicId,
            Name = asset.Name,
            AssetType = asset.AssetType,
            SerialNumber = asset.SerialNumber,
            Location = asset.Location,
            IsActive = asset.IsActive,
            CreatedAt = asset.CreatedAt,
            UpdatedAt = asset.UpdatedAt
        };
    }
}
