using Microsoft.EntityFrameworkCore;
using ServiceDesk.Data;
using ServiceDesk.Services.Interfaces;
using ServiceDesk.ViewModels.ServiceRequests;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceDesk.Data.Models;
using ServiceDesk.Data.Models.Enums;

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

    public async Task<ServiceRequestDetailsViewModel?> GetByIdAsync(int id)
    {
        return await context.ServiceRequests
            .AsNoTracking()
            .Where(sr => sr.Id == id)
            .Select(sr => new ServiceRequestDetailsViewModel
            {
                Id = sr.Id,
                Title = sr.Title,
                Status = sr.Status.ToString(),
                ProblemDescription = sr.ProblemDescription,
                CreatedOn = sr.CreatedOn.ToString("dd.MM.yyyy"),
                CompletedOn = sr.CompletedOn == null ? null : sr.CompletedOn.Value.ToString("dd.MM.yyyy HH:mm"),
                EstimatedPrice = sr.EstimatedPrice,
                Device = sr.Device.Brand + " " + sr.Device.Model,
                CustomerName = sr.Device.Customer.FullName,
                TechnicianName = sr.Technician == null ? null : sr.Technician.FullName
            })
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<SelectListItem>> GetTechniciansAsync()
    {
        return await context.Technicians
            .AsNoTracking()
            .OrderBy(t => t.FullName)
            .Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.FullName
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<SelectListItem>> GetDevicesAsync()
    {
        return await context.Devices
            .AsNoTracking()
            .OrderBy(d => d.Brand)
            .Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Brand + " " + d.Model + " (" + d.Customer.FullName + ")"
            })
            .ToListAsync();
    }

    public async Task CreateAsync(ServiceRequestFormViewModel model)
    {
        var request = new ServiceRequest
        {
            Title = model.Title,
            ProblemDescription = model.ProblemDescription,
            CreatedOn = DateTime.Now,
            Status = model.Status,
            EstimatedPrice = model.EstimatedPrice,
            DeviceId = model.DeviceId,
            TechnicianId = model.TechnicianId,
            CompletedOn = model.Status == RequestStatus.Completed ? DateTime.Now : null
        };

        await context.ServiceRequests.AddAsync(request);
        await context.SaveChangesAsync();
    }
}