using ClinicOps.Api.Data;
using ClinicOps.Api.Services.Implementations;
using ClinicOps.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ClinicOpsDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ITicketService, TicketService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/api/status", (IHostEnvironment environment) =>
{
    return Results.Ok(new
    {
        status = "ok",
        service = "ClinicOps API",
        environment = environment.EnvironmentName,
        timestampUtc = DateTime.UtcNow
    });
})
.WithName("GetApiStatus")
.WithOpenApi();

app.MapControllers();

app.Run();
