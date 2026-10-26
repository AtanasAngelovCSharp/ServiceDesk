using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ServiceDesk.Data.Models.Enums;
using static ServiceDesk.Common.ValidationConstants;

namespace ServiceDesk.Data.Models;

public class Device
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DeviceType Type { get; set; }

    [Required]
    [MaxLength(DeviceBrandMaxLength)]
    public string Brand { get; set; } = null!;

    [Required]
    [MaxLength(DeviceModelMaxLength)]
    public string Model { get; set; } = null!;

    [MaxLength(SerialNumberMaxLength)]
    public string? SerialNumber { get; set; }

    [Required]
    public int CustomerId { get; set; }

    [ForeignKey(nameof(CustomerId))]
    public Customer Customer { get; set; } = null!;

    public ICollection<ServiceRequest> ServiceRequests { get; set; } = new HashSet<ServiceRequest>();
}