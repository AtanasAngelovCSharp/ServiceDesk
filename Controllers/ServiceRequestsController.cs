using Microsoft.AspNetCore.Mvc;
using ServiceDesk.Services.Interfaces;
using ServiceDesk.ViewModels.ServiceRequests;

namespace ServiceDesk.Controllers;

public class ServiceRequestsController : Controller
{
    private readonly IServiceRequestService serviceRequestService;

    public ServiceRequestsController(IServiceRequestService serviceRequestService)
    {
        this.serviceRequestService = serviceRequestService;
    }

    public async Task<IActionResult> Index()
    {
        var requests = await serviceRequestService.GetAllAsync();
        return View(requests);
    }

    public async Task<IActionResult> Details(int id)
    {
        var request = await serviceRequestService.GetByIdAsync(id);
        if (request == null)
        {
            return NotFound();
        }
        else
        {
            return View(request);
        }
    }

    public async Task<IActionResult> Create()
    {
        var model = new ServiceRequestFormViewModel();
        model.Devices = await serviceRequestService.GetDevicesAsync();
        model.Technicians = await serviceRequestService.GetTechniciansAsync();

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ServiceRequestFormViewModel model)
    {
        if (!await serviceRequestService.DeviceExistsAsync(model.DeviceId))
        {
            ModelState.AddModelError(nameof(model.DeviceId), "Избраното устройство не съществува.");
        }

        if (model.TechnicianId.HasValue && !await serviceRequestService.TechnicianExistsAsync(model.TechnicianId.Value))
        {
            ModelState.AddModelError(nameof(model.TechnicianId), "Избраният техник не съществува.");
        }

        if (!ModelState.IsValid)
        {
            model.Devices = await serviceRequestService.GetDevicesAsync();
            model.Technicians = await serviceRequestService.GetTechniciansAsync();
            return View(model);
        }

        await serviceRequestService.CreateAsync(model);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var model = await serviceRequestService.GetForEditAsync(id);
        if (model == null)
        {
            return NotFound();
        }

        model.Devices = await serviceRequestService.GetDevicesAsync();
        model.Technicians = await serviceRequestService.GetTechniciansAsync();
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ServiceRequestFormViewModel model)
    {
        if (!await serviceRequestService.DeviceExistsAsync(model.DeviceId))
        {
            ModelState.AddModelError(nameof(model.DeviceId), "Избраното устройство не съществува.");
        }

        if (model.TechnicianId.HasValue && !await serviceRequestService.TechnicianExistsAsync(model.TechnicianId.Value))
        {
            ModelState.AddModelError(nameof(model.TechnicianId), "Избраният техник не съществува.");
        }

        if (!ModelState.IsValid)
        {
            model.Devices = await serviceRequestService.GetDevicesAsync();
            model.Technicians = await serviceRequestService.GetTechniciansAsync();
            return View(model);
        }

        bool success = await serviceRequestService.EditAsync(id, model);
        if (!success)
        {
            return NotFound();
        }

        return RedirectToAction(nameof(Details), new { id });
    }

    public async Task<IActionResult> Delete(int id)
    {
        var request = await serviceRequestService.GetByIdAsync(id);
        if (request == null)
        {
            return NotFound();
        }
        return View(request);
    }

    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        bool success = await serviceRequestService.DeleteAsync(id);
        if (!success)
        {
            return NotFound();
        }

        return RedirectToAction(nameof(Index));
    }
}
