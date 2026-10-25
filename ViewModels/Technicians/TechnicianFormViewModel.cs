using System.ComponentModel.DataAnnotations;
using static ServiceDesk.Common.ValidationConstants;

namespace ServiceDesk.ViewModels.Technicians;

public class TechnicianFormViewModel
{
    [Required(ErrorMessage = "Името е задължително.")]
    [StringLength(TechnicianFullNameMaxLength, MinimumLength = TechnicianFullNameMinLength,
        ErrorMessage = "Името трябва да е между {2} и {1} символа.")]
    public string FullName { get; set; } = null!;

    [StringLength(SpecializationMaxLength, ErrorMessage = "Специализацията може да е до {1} символа.")]
    public string? Specialization { get; set; }

    [Required(ErrorMessage = "Телефонът е задължителен.")]
    [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength,
    ErrorMessage = "Телефонът трябва да е между {2} и {1} символа.")]
    [Phone(ErrorMessage = "Невалиден телефонен номер.")]
    public string PhoneNumber { get; set; } = null!;
}