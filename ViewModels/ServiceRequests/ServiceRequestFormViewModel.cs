using System.ComponentModel.DataAnnotations;
using ServiceDesk.Data.Models.Enums;
using static ServiceDesk.Common.ValidationConstants;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceDesk.ViewModels.ServiceRequests;

public class ServiceRequestFormViewModel
{
    [Required(ErrorMessage = "Заглавието е задължително.")]
    [StringLength(RequestTitleMaxLength, MinimumLength = RequestTitleMinLength,
    ErrorMessage = "Заглавието трябва да е между {2} и {1} символа.")]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = "Описанието на проблема е задължително.")]
    [StringLength(ProblemDescriptionMaxLength, MinimumLength = ProblemDescriptionMinLength,
    ErrorMessage = "Описанието трябва да е между {2} и {1} символа.")]
    public string ProblemDescription { get; set; } = null!;

    [Required(ErrorMessage = "Статусът е задължителен.")]
    public RequestStatus Status { get; set; }

    [Range(EstimatedPriceMinValue, EstimatedPriceMaxValue,
    ErrorMessage = "Цената трябва да е между {1} и {2} €.")]
    public decimal EstimatedPrice { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Изберете устройство.")]
    public int DeviceId { get; set; }

    public int? TechnicianId { get; set; }

    public IEnumerable<SelectListItem> Devices { get; set; } = new List<SelectListItem>();
    public IEnumerable<SelectListItem> Technicians { get; set; } = new List<SelectListItem>();
}

