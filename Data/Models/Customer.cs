using System.ComponentModel.DataAnnotations;
using static ServiceDesk.Common.ValidationConstants;

namespace ServiceDesk.Data.Models;

public class Customer
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(CustomerFullNameMaxLength)]
    public string FullName { get; set; } = null!;

    [Required]
    [MaxLength(PhoneNumberMaxLength)]
    public string PhoneNumber { get; set; } = null!;

    [MaxLength(EmailMaxLength)]
    public string? Email { get; set; }

    [MaxLength(AddressMaxLength)]
    public string? Address { get; set; }

    public ICollection<Device> Devices { get; set; } = new HashSet<Device>();
}