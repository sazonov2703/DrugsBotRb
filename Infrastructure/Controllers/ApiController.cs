using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Controllers;

public class ApiController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}