using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChefsNDishes.Models;
using Microsoft.Extensions.Logging;


namespace ChefsNDishes.Controllers;

public class HomeController : Controller
{
  private readonly ILogger<HomeController> _logger;
  private MyContext db;

  public HomeController(ILogger<HomeController> logger, MyContext context)
  {
    _logger = logger;
    db = context;
  }

  [HttpGet("")]
public IActionResult Index()
{
    List<Chef> allChefs = db.Chefs.Include(chef => chef.Dishes).ToList();
    return View("AllChefs", allChefs);
}


  [HttpGet("dishes")]
  public IActionResult AllDishes()
  {
    List<Dish> allDishes = db.Dishes.Include(c => c.Creator).ToList();
    return View(allDishes);
  }

  [HttpGet("dishes/new")]
  public IActionResult NewDish()
  {
    List<Chef> allChefs = db.Chefs.ToList();
    ViewData["Chefs"] = allChefs;
    return View("NewDish");
  }

  [HttpPost("dishes/create")]
public IActionResult CreateDish(Dish dish)
{
    if (ModelState.IsValid)
    {
        int chefId = dish.ChefId;

        Chef chef = db.Chefs.Find(chefId);

        if (chef != null)
        {
            dish.Creator = chef;

            db.Dishes.Add(dish);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }

    List<Chef> allChefs = db.Chefs.ToList();
    ViewData["Chefs"] = allChefs;
    return View("NewDish");
}




  [HttpGet("chefs/new")]
  public IActionResult NewChef()
  {
    return View("NewChef");
  }

 [HttpPost("chefs/create")]
  public IActionResult CreateChef(Chef chef)
  {
    if (!ModelState.IsValid)
    {
      return View("NewChef");
    }
    db.Chefs.Add(chef);
    db.SaveChanges();
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