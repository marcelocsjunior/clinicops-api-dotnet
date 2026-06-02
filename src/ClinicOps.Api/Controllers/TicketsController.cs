using ClinicOps.Api.DTOs.Tickets;
using ClinicOps.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicOps.Api.Controllers;

[ApiController]
[Route("api/tickets")]
public class TicketsController : ControllerBase
{
    private readonly ITicketService _ticketService;

    public TicketsController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<TicketResponse>>> GetAll()
    {
        var tickets = await _ticketService.GetAllAsync();

        return Ok(tickets);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TicketResponse>> GetById(int id)
    {
        var ticket = await _ticketService.GetByIdAsync(id);

        return ticket is null ? NotFound() : Ok(ticket);
    }

    [HttpPost]
    public async Task<ActionResult<TicketResponse>> Create(CreateTicketRequest request)
    {
        var ticket = await _ticketService.CreateAsync(request);

        return CreatedAtAction(nameof(GetById), new { id = ticket.Id }, ticket);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<TicketResponse>> Update(int id, UpdateTicketRequest request)
    {
        var ticket = await _ticketService.UpdateAsync(id, request);

        return ticket is null ? NotFound() : Ok(ticket);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _ticketService.DeleteAsync(id);

        return deleted ? NoContent() : NotFound();
    }
}
