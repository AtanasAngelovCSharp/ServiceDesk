using Microsoft.AspNetCore.Mvc;
using ServiceDesk.Services.Interfaces;
using ServiceDesk.ViewModels.Technicians;

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

    public IActionResult Create()
    {
        return View(new TechnicianFormViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TechnicianFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        await technicianService.CreateAsync(model);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int id)
    {
        var technician = await technicianService.GetByIdAsync(id);
        if (technician == null)
        {
            return NotFound();
        }

        return View(technician);
    }
}