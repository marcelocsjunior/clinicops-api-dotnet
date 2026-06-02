using ClinicOps.Api.Data;
using ClinicOps.Api.DTOs.Dashboard;
using ClinicOps.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicOps.Api.Services.Implementations;

public class DashboardService : IDashboardService
{
    private readonly ClinicOpsDbContext _dbContext;

    public DashboardService(ClinicOpsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<DashboardSummaryResponse> GetSummaryAsync()
    {
        return new DashboardSummaryResponse
        {
            TotalClinics = await _dbContext.Clinics.CountAsync(),
            ActiveClinics = await _dbContext.Clinics.CountAsync(clinic => clinic.IsActive),
            TotalAssets = await _dbContext.Assets.CountAsync(),
            ActiveAssets = await _dbContext.Assets.CountAsync(asset => asset.IsActive),
            TotalTickets = await _dbContext.Tickets.CountAsync(),
            OpenTickets = await _dbContext.Tickets.CountAsync(ticket => ticket.Status == "Open"),
            InProgressTickets = await _dbContext.Tickets.CountAsync(ticket => ticket.Status == "InProgress"),
            ClosedTickets = await _dbContext.Tickets.CountAsync(ticket => ticket.Status == "Closed"),
            TotalTechnicians = await _dbContext.Technicians.CountAsync(),
            ActiveTechnicians = await _dbContext.Technicians.CountAsync(technician => technician.IsActive),
            TotalMaintenanceLogs = await _dbContext.MaintenanceLogs.CountAsync(),
            LastUpdatedUtc = DateTime.UtcNow
        };
    }
}
