using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ServiceDesk.Models;
using ServiceDesk.Services.Interfaces;

namespace ServiceDesk.Controllers;

public class HomeController : Controller
{
    private readonly IServiceRequestService serviceRequestService;

    public HomeController(IServiceRequestService serviceRequestService)
    {
        this.serviceRequestService = serviceRequestService;
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public async Task<IActionResult> Index()
    {
        var model = await serviceRequestService.GetDashboardAsync();
        return View(model);
    }
}
