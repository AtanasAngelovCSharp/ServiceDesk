using System.ComponentModel.DataAnnotations;
using static ServiceDesk.Common.ValidationConstants;

namespace ServiceDesk.Data.Models;

public class Technician
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(TechnicianFullNameMaxLength)]
    public string FullName { get; set; } = null!;

    [MaxLength(SpecializationMaxLength)]
    public string? Specialization { get; set; }

    [Required]
    [MaxLength(PhoneNumberMaxLength)]
    public string PhoneNumber { get; set; } = null!;

    public ICollection<ServiceRequest> ServiceRequests { get; set; } = new HashSet<ServiceRequest>();
}