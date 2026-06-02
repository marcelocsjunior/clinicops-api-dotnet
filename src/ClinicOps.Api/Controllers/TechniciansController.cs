using ClinicOps.Api.DTOs.Technicians;
using ClinicOps.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicOps.Api.Controllers;

[ApiController]
[Route("api/technicians")]
public class TechniciansController : ControllerBase
{
    private readonly ITechnicianService _technicianService;

    public TechniciansController(ITechnicianService technicianService)
    {
        _technicianService = technicianService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<TechnicianResponse>>> GetAll()
    {
        var technicians = await _technicianService.GetAllAsync();

        return Ok(technicians);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TechnicianResponse>> GetById(int id)
    {
        var technician = await _technicianService.GetByIdAsync(id);

        return technician is null ? NotFound() : Ok(technician);
    }

    [HttpPost]
    public async Task<ActionResult<TechnicianResponse>> Create(CreateTechnicianRequest request)
    {
        var technician = await _technicianService.CreateAsync(request);

        return CreatedAtAction(nameof(GetById), new { id = technician.Id }, technician);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<TechnicianResponse>> Update(int id, UpdateTechnicianRequest request)
    {
        var technician = await _technicianService.UpdateAsync(id, request);

        return technician is null ? NotFound() : Ok(technician);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _technicianService.DeleteAsync(id);

        return result switch
        {
            DeleteTechnicianResult.Deleted => NoContent(),
            DeleteTechnicianResult.HasLinkedMaintenanceLogs => Conflict(new { message = "Technician has linked maintenance logs and cannot be deleted." }),
            _ => NotFound()
        };
    }
}
