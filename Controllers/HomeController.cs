using GameSphere.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GameSphere.Controllers;

public class HomeController(ILogger<HomeController> logger) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;

    public IActionResult Index() => View();

    public IActionResult Camp() => View();

    public IActionResult Privacy() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(int? statusCode) =>
        View(new ErrorViewModel(Activity.Current?.Id ?? HttpContext.TraceIdentifier, statusCode));
}
