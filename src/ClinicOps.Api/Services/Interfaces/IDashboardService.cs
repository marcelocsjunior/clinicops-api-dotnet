using ClinicOps.Api.DTOs.Dashboard;

namespace ClinicOps.Api.Services.Interfaces;

public interface IDashboardService
{
    Task<DashboardSummaryResponse> GetSummaryAsync();
}
