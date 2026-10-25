using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceDesk.ViewModels.ServiceRequests;

namespace ServiceDesk.Services.Interfaces;

public interface IServiceRequestService
{
    Task<IEnumerable<ServiceRequestIndexViewModel>> GetAllAsync();
    Task<ServiceRequestDetailsViewModel?> GetByIdAsync(int id);
    Task<IEnumerable<SelectListItem>> GetDevicesAsync();
    Task<IEnumerable<SelectListItem>> GetTechniciansAsync();
    Task CreateAsync(ServiceRequestFormViewModel model);
}