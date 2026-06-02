using ClinicOps.Api.DTOs.Assets;
using ClinicOps.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicOps.Api.Controllers;

[ApiController]
[Route("api/assets")]
public class AssetsController : ControllerBase
{
    private readonly IAssetService _assetService;

    public AssetsController(IAssetService assetService)
    {
        _assetService = assetService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<AssetResponse>>> GetAll()
    {
        var assets = await _assetService.GetAllAsync();

        return Ok(assets);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<AssetResponse>> GetById(int id)
    {
        var asset = await _assetService.GetByIdAsync(id);

        return asset is null ? NotFound() : Ok(asset);
    }

    [HttpPost]
    public async Task<ActionResult<AssetResponse>> Create(CreateAssetRequest request)
    {
        var asset = await _assetService.CreateAsync(request);

        if (asset is null)
        {
            return BadRequest(new { message = "ClinicId does not reference an existing clinic." });
        }

        return CreatedAtAction(nameof(GetById), new { id = asset.Id }, asset);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<AssetResponse>> Update(int id, UpdateAssetRequest request)
    {
        var existingAsset = await _assetService.GetByIdAsync(id);

        if (existingAsset is null)
        {
            return NotFound();
        }

        var asset = await _assetService.UpdateAsync(id, request);

        if (asset is null)
        {
            return BadRequest(new { message = "ClinicId does not reference an existing clinic." });
        }

        return Ok(asset);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _assetService.DeleteAsync(id);

        return result switch
        {
            DeleteAssetResult.Deleted => NoContent(),
            DeleteAssetResult.HasLinkedMaintenanceLogs => Conflict(new { message = "Asset has linked maintenance logs and cannot be deleted." }),
            _ => NotFound()
        };
    }
}
