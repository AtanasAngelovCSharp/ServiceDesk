using Microsoft.EntityFrameworkCore;
using ServiceDesk.Data;
using ServiceDesk.Data.Models.Enums;
using ServiceDesk.Services.Interfaces;
using ServiceDesk.ViewModels.Technicians;
using ServiceDesk.Data.Models;
using ServiceDesk.ViewModels.ServiceRequests;

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

    public async Task CreateAsync(TechnicianFormViewModel model)
    {
        var technician = new Technician
        {
            FullName = model.FullName,
            Specialization = model.Specialization,
            PhoneNumber = model.PhoneNumber
        };

        await context.Technicians.AddAsync(technician);
        await context.SaveChangesAsync();
    }

    public async Task<TechnicianDetailsViewModel?> GetByIdAsync(int id)
    {
        return await context.Technicians
            .AsNoTracking()
            .Where(t => t.Id == id)
            .Select(t => new TechnicianDetailsViewModel
            {
                Id = t.Id,
                FullName = t.FullName,
                Specialization = t.Specialization,
                PhoneNumber = t.PhoneNumber,
                Requests = t.ServiceRequests
                    .OrderByDescending(sr => sr.CreatedOn)
                    .Select(sr => new ServiceRequestIndexViewModel
                    {
                        Id = sr.Id,
                        Title = sr.Title,
                        Status = sr.Status.ToString(),
                        CreatedOn = sr.CreatedOn.ToString("dd.MM.yyyy"),
                        Device = sr.Device.Brand + " " + sr.Device.Model,
                        TechnicianName = t.FullName
                    })
                    .ToList()
            })
            .FirstOrDefaultAsync();
    }
}