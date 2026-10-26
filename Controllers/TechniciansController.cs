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

    public async Task<IActionResult> Edit(int id)
    {
        var model = await technicianService.GetForEditAsync(id);
        if (model == null)
        {
            return NotFound();
        }

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, TechnicianFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        bool success = await technicianService.EditAsync(id, model);
        if (!success)
        {
            return NotFound();
        }

        return RedirectToAction(nameof(Details), new { id });
    }

    public async Task<IActionResult> Delete(int id)
    {
        var technician = await technicianService.GetByIdAsync(id);
        if (technician == null)
        {
            return NotFound();
        }

        return View(technician);
    }

    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        bool success = await technicianService.DeleteAsync(id);
        if (!success)
        {
            return NotFound();
        }

        return RedirectToAction(nameof(Index));
    }
}