using Microsoft.EntityFrameworkCore;
using ServiceDesk.Data;
using ServiceDesk.Services.Interfaces;
using ServiceDesk.ViewModels.ServiceRequests;

namespace ServiceDesk.Services;

public class ServiceRequestService : IServiceRequestService
{
    private readonly ApplicationDbContext context;

    public ServiceRequestService(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<ServiceRequestIndexViewModel>> GetAllAsync()
    {
        return await context.ServiceRequests
            .AsNoTracking()
            .OrderByDescending(sr => sr.CreatedOn)
            .Select(sr => new ServiceRequestIndexViewModel
            {
                Id = sr.Id,
                Title = sr.Title,
                Status = sr.Status.ToString(),
                CreatedOn = sr.CreatedOn.ToString("dd.MM.yyyy"),
                Device = sr.Device.Brand + " " + sr.Device.Model,
                TechnicianName = sr.Technician == null ? null : sr.Technician.FullName
            })
            .ToListAsync();
    }
}