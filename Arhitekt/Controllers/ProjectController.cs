using Microsoft.AspNetCore.Mvc;
using Arhitekt.Data;
using Arhitekt.Models;

namespace Arhitekt.Controllers;

public class ProjectController : Controller
{
    private readonly ArhitektContext _context;

    public ProjectController(ArhitektContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var projects = _context.Projects.ToList();
        return View(projects);
    }

    public IActionResult Details(int id)
    {
        var project = _context.Projects.FirstOrDefault(p => p.ProjectID == id);
        if (project == null) return NotFound();
        return View(project);
    }
}
