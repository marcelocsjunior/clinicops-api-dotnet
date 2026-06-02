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
    public DbSet<Technician> Technicians => Set<Technician>();
    public DbSet<MaintenanceLog> MaintenanceLogs => Set<MaintenanceLog>();

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

            entity.HasMany(asset => asset.MaintenanceLogs)
                .WithOne(log => log.Asset)
                .HasForeignKey(log => log.AssetId)
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

        modelBuilder.Entity<Technician>(entity =>
        {
            entity.Property(technician => technician.FullName)
                .IsRequired()
                .HasMaxLength(120);

            entity.Property(technician => technician.Email)
                .IsRequired()
                .HasMaxLength(120);

            entity.Property(technician => technician.IsActive)
                .IsRequired();

            entity.Property(technician => technician.CreatedAt)
                .IsRequired();

            entity.HasMany(technician => technician.MaintenanceLogs)
                .WithOne(log => log.Technician)
                .HasForeignKey(log => log.TechnicianId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<MaintenanceLog>(entity =>
        {
            entity.Property(log => log.AssetId)
                .IsRequired();

            entity.Property(log => log.TechnicianId)
                .IsRequired();

            entity.Property(log => log.Description)
                .IsRequired()
                .HasMaxLength(1000);

            entity.Property(log => log.PerformedAt)
                .IsRequired();

            entity.Property(log => log.CreatedAt)
                .IsRequired();

            entity.HasOne(log => log.Asset)
                .WithMany(asset => asset.MaintenanceLogs)
                .HasForeignKey(log => log.AssetId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(log => log.Technician)
                .WithMany(technician => technician.MaintenanceLogs)
                .HasForeignKey(log => log.TechnicianId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
