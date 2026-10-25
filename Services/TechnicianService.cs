using Microsoft.EntityFrameworkCore;
using ServiceDesk.Data;
using ServiceDesk.Data.Models.Enums;
using ServiceDesk.Services.Interfaces;
using ServiceDesk.ViewModels.Technicians;

namespace ServiceDesk.Services;

public class TechnicianService : ITechnicianService
{
    private readonly ApplicationDbContext context;
    public TechnicianService(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<TechnicianIndexViewModel>> GetAllAsync()
    {
        return await context.Technicians
            .AsNoTracking()
            .OrderBy(t => t.FullName)
            .Select(t => new TechnicianIndexViewModel
            {
                Id = t.Id,
                FullName = t.FullName,
                ActiveRequestsCount = t.ServiceRequests
                    .Count(sr => sr.Status != RequestStatus.Completed
                              && sr.Status != RequestStatus.Cancelled),
                Specialization = t.Specialization,
                PhoneNumber = t.PhoneNumber
            })
            .ToListAsync();
    }
}