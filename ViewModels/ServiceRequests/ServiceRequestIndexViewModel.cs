namespace ServiceDesk.ViewModels.ServiceRequests;

public class ServiceRequestIndexViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Status { get; set; } = null!;
    public string CreatedOn { get; set; } = null!;
    public string Device { get; set; } = null!;
    public string? TechnicianName { get; set; }
}