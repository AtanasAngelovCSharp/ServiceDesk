namespace ServiceDesk.ViewModels.ServiceRequests;

public class ServiceRequestDetailsViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Status { get; set; } = null!;
    public string ProblemDescription { get; set; } = null!;
    public string CreatedOn { get; set; } = null!;
    public string? CompletedOn { get; set; }
    public decimal EstimatedPrice { get; set; }
    public string Device { get; set; } = null!;
    public string CustomerName { get; set; } = null!;
    public string? TechnicianName { get; set; }
}