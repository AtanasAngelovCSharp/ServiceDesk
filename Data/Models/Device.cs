using ServiceDesk.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using static ServiceDesk.Common.ValidationConstants;
using System.ComponentModel.DataAnnotations.Schema;

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
}