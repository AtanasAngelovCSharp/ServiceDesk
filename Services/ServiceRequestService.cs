using Microsoft.EntityFrameworkCore;
using ServiceDesk.Data;
using ServiceDesk.Services.Interfaces;
using ServiceDesk.ViewModels.ServiceRequests;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceDesk.Data.Models;
using ServiceDesk.Data.Models.Enums;
using ServiceDesk.ViewModels.Home;

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

    public async Task<ServiceRequestFormViewModel?> GetForEditAsync(int id)
    {
        return await context.ServiceRequests
            .AsNoTracking()
            .Where(sr => sr.Id == id)
            .Select(sr => new ServiceRequestFormViewModel
            {
                Title = sr.Title,
                Status = sr.Status,
                ProblemDescription = sr.ProblemDescription,
                EstimatedPrice = sr.EstimatedPrice,
                DeviceId = sr.DeviceId,
                TechnicianId = sr.TechnicianId
            })
            .FirstOrDefaultAsync();
    }

    public async Task<bool> EditAsync(int id, ServiceRequestFormViewModel model)
    {
        var request = await context.ServiceRequests.FindAsync(id);
        if (request == null)
        {
            return false;
        }

        request.Title = model.Title;
        request.ProblemDescription = model.ProblemDescription;
        request.Status = model.Status;
        request.EstimatedPrice = model.EstimatedPrice;
        request.DeviceId = model.DeviceId;
        request.TechnicianId = model.TechnicianId;

        if (request.Status == RequestStatus.Completed && request.CompletedOn == null)
        {
            request.CompletedOn = DateTime.Now;
        }
        else if (request.Status != RequestStatus.Completed)
        {
            request.CompletedOn = null;
        }
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var request = await context.ServiceRequests.FindAsync(id);
        if (request == null)
        {
            return false;
        }

        context.ServiceRequests.Remove(request);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<HomeIndexViewModel> GetDashboardAsync()
    {
        return new HomeIndexViewModel
        {
            NewCount = await context.ServiceRequests.CountAsync(sr => sr.Status == RequestStatus.New),
            InProgressCount = await context.ServiceRequests.CountAsync(sr => sr.Status == RequestStatus.InProgress),
            WaitingForPartsCount = await context.ServiceRequests.CountAsync(sr => sr.Status == RequestStatus.WaitingForParts),
            CompletedCount = await context.ServiceRequests.CountAsync(sr => sr.Status == RequestStatus.Completed)
        };
    }
}