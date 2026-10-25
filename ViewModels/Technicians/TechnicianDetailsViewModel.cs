using ServiceDesk.ViewModels.ServiceRequests;

namespace ServiceDesk.ViewModels.Technicians;

public class TechnicianDetailsViewModel
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string? Specialization{ get; set; }
    public string PhoneNumber { get; set; } = null!;

    public IEnumerable<ServiceRequestIndexViewModel> Requests { get; set; }
        = new List<ServiceRequestIndexViewModel>();
}