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
    public DbSet<Clinic> Clinics => Set<Clinic>();
    public DbSet<Asset> Assets => Set<Asset>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clinic>(entity =>
        {
            entity.Property(clinic => clinic.Name)
                .IsRequired()
                .HasMaxLength(120);

            entity.Property(clinic => clinic.City)
                .IsRequired()
                .HasMaxLength(80);

            entity.Property(clinic => clinic.State)
                .IsRequired()
                .HasMaxLength(2);

            entity.Property(clinic => clinic.IsActive)
                .IsRequired();

            entity.Property(clinic => clinic.CreatedAt)
                .IsRequired();
        });

        modelBuilder.Entity<Asset>(entity =>
        {
            entity.Property(asset => asset.ClinicId)
                .IsRequired();

            entity.Property(asset => asset.Name)
                .IsRequired()
                .HasMaxLength(120);

            entity.Property(asset => asset.AssetType)
                .IsRequired()
                .HasMaxLength(60);

            entity.Property(asset => asset.SerialNumber)
                .IsRequired(false)
                .HasMaxLength(120);

            entity.Property(asset => asset.Location)
                .IsRequired(false)
                .HasMaxLength(120);

            entity.Property(asset => asset.IsActive)
                .IsRequired();

            entity.Property(asset => asset.CreatedAt)
                .IsRequired();

            entity.HasOne(asset => asset.Clinic)
                .WithMany(clinic => clinic.Assets)
                .HasForeignKey(asset => asset.ClinicId)
                .OnDelete(DeleteBehavior.Restrict);
        });

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
