namespace ServiceDesk.ViewModels.Technicians;

public class TechnicianIndexViewModel
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string? Specialization { get; set; }
    public string PhoneNumber { get; set; } = null!;
    public int ActiveRequestsCount { get; set; }
}