using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Arhitekt.Models;
using Arhitekt.Data;

namespace Arhitekt.Controllers;

public class HomeController : Controller
{
    private readonly ArhitektContext _context;

    public HomeController(ArhitektContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        // Naloži 10 projektov iz baze
        var projects = _context.Projects
            .Take(10)
            .ToList();

        return View(projects);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
