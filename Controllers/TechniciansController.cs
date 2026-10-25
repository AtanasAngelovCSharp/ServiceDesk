using Microsoft.AspNetCore.Mvc;
using ServiceDesk.Services.Interfaces;

namespace ServiceDesk.Controllers;

public class TechniciansController : Controller
{
    private readonly ITechnicianService technicianService;

    public TechniciansController(ITechnicianService technicianService)
    {
        this.technicianService = technicianService;
    }

    public async Task<IActionResult> Index()
    {
        var technicians = await technicianService.GetAllAsync();
        return View(technicians);
    }
}