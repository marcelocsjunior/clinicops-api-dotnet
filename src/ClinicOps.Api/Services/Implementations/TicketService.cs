using ClinicOps.Api.Data;
using ClinicOps.Api.DTOs.Tickets;
using ClinicOps.Api.Models;
using ClinicOps.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicOps.Api.Services.Implementations;

public class TicketService : ITicketService
{
    private const string ClosedStatus = "Closed";
    private readonly ClinicOpsDbContext _dbContext;

    public TicketService(ClinicOpsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<TicketResponse>> GetAllAsync()
    {
        return await _dbContext.Tickets
            .AsNoTracking()
            .OrderBy(ticket => ticket.Id)
            .Select(ticket => ToResponse(ticket))
            .ToListAsync();
    }

    public async Task<TicketResponse?> GetByIdAsync(int id)
    {
        var ticket = await _dbContext.Tickets
            .AsNoTracking()
            .FirstOrDefaultAsync(ticket => ticket.Id == id);

        return ticket is null ? null : ToResponse(ticket);
    }

    public async Task<TicketResponse> CreateAsync(CreateTicketRequest request)
    {
        var now = DateTime.UtcNow;
        var ticket = new Ticket
        {
            ClinicId = request.ClinicId,
            AssetId = request.AssetId,
            Title = request.Title,
            Description = request.Description,
            Priority = string.IsNullOrWhiteSpace(request.Priority) ? "Medium" : request.Priority,
            Status = "Open",
            OpenedAt = now,
            CreatedAt = now
        };

        _dbContext.Tickets.Add(ticket);
        await _dbContext.SaveChangesAsync();

        return ToResponse(ticket);
    }

    public async Task<TicketResponse?> UpdateAsync(int id, UpdateTicketRequest request)
    {
        var ticket = await _dbContext.Tickets.FindAsync(id);

        if (ticket is null)
        {
            return null;
        }

        ticket.Title = request.Title;
        ticket.Description = request.Description;
        ticket.Priority = request.Priority;
        ticket.Status = request.Status;
        ticket.UpdatedAt = DateTime.UtcNow;

        if (string.Equals(ticket.Status, ClosedStatus, StringComparison.OrdinalIgnoreCase))
        {
            ticket.ClosedAt ??= DateTime.UtcNow;
        }
        else
        {
            ticket.ClosedAt = null;
        }

        await _dbContext.SaveChangesAsync();

        return ToResponse(ticket);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var ticket = await _dbContext.Tickets.FindAsync(id);

        if (ticket is null)
        {
            return false;
        }

        _dbContext.Tickets.Remove(ticket);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    private static TicketResponse ToResponse(Ticket ticket)
    {
        return new TicketResponse
        {
            Id = ticket.Id,
            ClinicId = ticket.ClinicId,
            AssetId = ticket.AssetId,
            Title = ticket.Title,
            Description = ticket.Description,
            Priority = ticket.Priority,
            Status = ticket.Status,
            OpenedAt = ticket.OpenedAt,
            ClosedAt = ticket.ClosedAt,
            CreatedAt = ticket.CreatedAt,
            UpdatedAt = ticket.UpdatedAt
        };
    }
}
