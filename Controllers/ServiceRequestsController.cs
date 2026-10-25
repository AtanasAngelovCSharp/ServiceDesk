using Microsoft.AspNetCore.Mvc;
using ServiceDesk.Services.Interfaces;

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
}
