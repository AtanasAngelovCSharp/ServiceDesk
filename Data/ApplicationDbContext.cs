using Microsoft.EntityFrameworkCore;
using ServiceDesk.Data.Models;

namespace ServiceDesk.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Device> Devices { get; set; } = null!;
    public DbSet<Technician> Technicians { get; set; } = null!;
    public DbSet<ServiceRequest> ServiceRequests { get; set; } = null!;
}