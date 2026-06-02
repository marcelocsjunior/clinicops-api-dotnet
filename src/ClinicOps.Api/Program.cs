var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
