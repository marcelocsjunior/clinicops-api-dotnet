using ClinicOps.Api.DTOs.Tickets;

namespace ClinicOps.Api.Services.Interfaces;

public interface ITicketService
{
    Task<IReadOnlyList<TicketResponse>> GetAllAsync();
    Task<TicketResponse?> GetByIdAsync(int id);
    Task<TicketResponse> CreateAsync(CreateTicketRequest request);
    Task<TicketResponse?> UpdateAsync(int id, UpdateTicketRequest request);
    Task<bool> DeleteAsync(int id);
}
