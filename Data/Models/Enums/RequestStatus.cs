using System.ComponentModel.DataAnnotations;

namespace ServiceDesk.Data.Models.Enums;

public enum RequestStatus
{
    [Display(Name = "Нова")]
    New,

    [Display(Name = "В процес")]
    InProgress,

    [Display(Name = "Чака части")]
    WaitingForParts,

    [Display(Name = "Завършена")]
    Completed,

    [Display(Name = "Отказана")]
    Cancelled
}