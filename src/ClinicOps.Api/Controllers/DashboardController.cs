using ClinicOps.Api.DTOs.Dashboard;
using ClinicOps.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicOps.Api.Controllers;

[ApiController]
[Route("api/dashboard")]
public class DashboardController : ControllerBase
{
    private readonly IDashboardService _dashboardService;

    public DashboardController(IDashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }

    [HttpGet("summary")]
    public async Task<ActionResult<DashboardSummaryResponse>> GetSummary()
    {
        var summary = await _dashboardService.GetSummaryAsync();

        return Ok(summary);
    }
}
