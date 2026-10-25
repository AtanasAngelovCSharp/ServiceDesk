using ServiceDesk.ViewModels.Technicians;

namespace ServiceDesk.Services.Interfaces;

public interface ITechnicianService
{
    Task<IEnumerable<TechnicianIndexViewModel>> GetAllAsync();
    Task CreateAsync(TechnicianFormViewModel model);
    Task<TechnicianDetailsViewModel?> GetByIdAsync(int id);
    Task<TechnicianFormViewModel?> GetForEditAsync(int id);
    Task<bool> EditAsync(int id, TechnicianFormViewModel model);
    Task<bool> DeleteAsync(int id);
}