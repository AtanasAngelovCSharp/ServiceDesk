using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceDesk.ViewModels.ServiceRequests;
using ServiceDesk.ViewModels.Home;


namespace ServiceDesk.Services.Interfaces;

public interface IServiceRequestService
{
    Task<IEnumerable<ServiceRequestIndexViewModel>> GetAllAsync();
    Task<ServiceRequestDetailsViewModel?> GetByIdAsync(int id);
    Task<IEnumerable<SelectListItem>> GetDevicesAsync();
    Task<IEnumerable<SelectListItem>> GetTechniciansAsync();
    Task CreateAsync(ServiceRequestFormViewModel model);
    Task<ServiceRequestFormViewModel?> GetForEditAsync(int id);
    Task<bool> EditAsync(int id, ServiceRequestFormViewModel model);
    Task<bool> DeleteAsync(int id);
    Task<HomeIndexViewModel> GetDashboardAsync();
    Task<bool> DeviceExistsAsync(int id);
    Task<bool> TechnicianExistsAsync(int id);
}