using ClinicOps.Api.DTOs.MaintenanceLogs;
using ClinicOps.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicOps.Api.Controllers;

[ApiController]
[Route("api/maintenance-logs")]
public class MaintenanceLogsController : ControllerBase
{
    private readonly IMaintenanceLogService _maintenanceLogService;

    public MaintenanceLogsController(IMaintenanceLogService maintenanceLogService)
    {
        _maintenanceLogService = maintenanceLogService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<MaintenanceLogResponse>>> GetAll()
    {
        var maintenanceLogs = await _maintenanceLogService.GetAllAsync();

        return Ok(maintenanceLogs);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<MaintenanceLogResponse>> GetById(int id)
    {
        var maintenanceLog = await _maintenanceLogService.GetByIdAsync(id);

        return maintenanceLog is null ? NotFound() : Ok(maintenanceLog);
    }

    [HttpPost]
    public async Task<ActionResult<MaintenanceLogResponse>> Create(CreateMaintenanceLogRequest request)
    {
        var result = await _maintenanceLogService.CreateAsync(request);

        return result.Status switch
        {
            CreateMaintenanceLogResultStatus.AssetNotFound => BadRequest(new { message = "AssetId does not reference an existing asset." }),
            CreateMaintenanceLogResultStatus.TechnicianNotFound => BadRequest(new { message = "TechnicianId does not reference an existing technician." }),
            _ => CreatedAtAction(nameof(GetById), new { id = result.MaintenanceLog!.Id }, result.MaintenanceLog)
        };
    }
}
