using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ServiceDesk.Data.Models.Enums;
using static ServiceDesk.Common.ValidationConstants;

namespace ServiceDesk.Data.Models;

public class ServiceRequest
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(RequestTitleMaxLength)]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(ProblemDescriptionMaxLength)]
    public string ProblemDescription { get; set; } = null!;

    [Required]
    public RequestStatus Status { get; set; }

    [Required]
    public DateTime CreatedOn { get; set; }

    public DateTime? CompletedOn { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal EstimatedPrice { get; set; }

    [Required]
    public int DeviceId { get; set; }

    [ForeignKey(nameof(DeviceId))]
    public Device Device { get; set; } = null!;

    public int? TechnicianId { get; set; }

    [ForeignKey(nameof(TechnicianId))]
    public Technician? Technician { get; set; }
}