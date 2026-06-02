using ClinicOps.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicOps.Api.Data;

public class ClinicOpsDbContext : DbContext
{
    public ClinicOpsDbContext(DbContextOptions<ClinicOpsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Ticket> Tickets => Set<Ticket>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.Property(ticket => ticket.Title)
                .IsRequired()
                .HasMaxLength(120);

            entity.Property(ticket => ticket.Description)
                .IsRequired()
                .HasMaxLength(1000);

            entity.Property(ticket => ticket.Priority)
                .IsRequired()
                .HasMaxLength(20);

            entity.Property(ticket => ticket.Status)
                .IsRequired()
                .HasMaxLength(30);

            entity.Property(ticket => ticket.OpenedAt)
                .IsRequired();

            entity.Property(ticket => ticket.CreatedAt)
                .IsRequired();
        });
    }
}
