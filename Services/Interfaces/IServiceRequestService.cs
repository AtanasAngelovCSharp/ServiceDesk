using ServiceDesk.ViewModels.ServiceRequests;

namespace ServiceDesk.Services.Interfaces;

public interface IServiceRequestService
{
    Task<IEnumerable<ServiceRequestIndexViewModel>> GetAllAsync();
}