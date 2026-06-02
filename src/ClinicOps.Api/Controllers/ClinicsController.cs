using ClinicOps.Api.DTOs.Clinics;
using ClinicOps.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicOps.Api.Controllers;

[ApiController]
[Route("api/clinics")]
public class ClinicsController : ControllerBase
{
    private readonly IClinicService _clinicService;

    public ClinicsController(IClinicService clinicService)
    {
        _clinicService = clinicService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ClinicResponse>>> GetAll()
    {
        var clinics = await _clinicService.GetAllAsync();

        return Ok(clinics);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ClinicResponse>> GetById(int id)
    {
        var clinic = await _clinicService.GetByIdAsync(id);

        return clinic is null ? NotFound() : Ok(clinic);
    }

    [HttpPost]
    public async Task<ActionResult<ClinicResponse>> Create(CreateClinicRequest request)
    {
        var clinic = await _clinicService.CreateAsync(request);

        return CreatedAtAction(nameof(GetById), new { id = clinic.Id }, clinic);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<ClinicResponse>> Update(int id, UpdateClinicRequest request)
    {
        var clinic = await _clinicService.UpdateAsync(id, request);

        return clinic is null ? NotFound() : Ok(clinic);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _clinicService.DeleteAsync(id);

        return result switch
        {
            DeleteClinicResult.Deleted => NoContent(),
            DeleteClinicResult.HasLinkedAssets => Conflict(new { message = "Clinic has linked assets and cannot be deleted." }),
            _ => NotFound()
        };
    }
}
