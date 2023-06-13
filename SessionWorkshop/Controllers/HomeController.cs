using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionWorkshop.Models;

namespace SessionWorkshop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("addInfo")]
    public IActionResult AddInfo(string name)
    {
        if (ModelState.IsValid)
        {
            HttpContext.Session.SetString("Name", name);
            HttpContext.Session.SetInt32("Number", 22);
            return RedirectToAction("Dashboard");
        }
        return View("Index");
    }

    [HttpPost("addNumber")]
    public IActionResult AddNumber(int val)
    {
        if (ModelState.IsValid)
        {
            HttpContext.Session.SetInt32("Number", (int)HttpContext.Session.GetInt32("Number") + val);
            return RedirectToAction("Dashboard");
        }
        return View("Index");
    }

    [HttpGet("dashboard")]
    public ViewResult Dashboard()
    {
        return View("Dashboard");
    }

    [HttpPost("clearSession")]
    public IActionResult ClearSession()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
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
}