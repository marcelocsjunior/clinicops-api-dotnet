namespace ClinicOps.Api.DTOs.Dashboard;

public class DashboardSummaryResponse
{
    public int TotalClinics { get; set; }
    public int ActiveClinics { get; set; }
    public int TotalAssets { get; set; }
    public int ActiveAssets { get; set; }
    public int TotalTickets { get; set; }
    public int OpenTickets { get; set; }
    public int InProgressTickets { get; set; }
    public int ClosedTickets { get; set; }
    public int TotalTechnicians { get; set; }
    public int ActiveTechnicians { get; set; }
    public int TotalMaintenanceLogs { get; set; }
    public DateTime LastUpdatedUtc { get; set; }
}
