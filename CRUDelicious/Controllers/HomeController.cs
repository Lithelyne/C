using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext db;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        db = context;
    }

    [HttpGet("/")]
    public IActionResult Index()
    {
        List<Dish> allDishes = db.Dishes.ToList();
        return View("AllDishes", allDishes);
    }

    [HttpGet("dish/new")]
    public IActionResult NewDish()
    {
        return View("New");
    }

    [HttpPost("dish/create")]
    public IActionResult CreateDish(Dish newDish)

    {
        if(!ModelState.IsValid)
        {
            return View("New");
        }

        db.Dishes.Add(newDish);

        db.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpGetAttribute("dish/{id}")]
    public IActionResult ViewDish(int id)
    {
        Dish? dish = db.Dishes.FirstOrDefault(dish => dish.PostID == id);

        if(dish == null)
        {
            return RedirectToAction("Index");
        }

        return View("Details", dish);
    }

    [HttpPost("dish/{postID}/delete")]
    public IActionResult DeleteDish(int postID)
    {
        Dish? dish = db.Dishes.FirstOrDefault(dish => dish.PostID == postID);

        if(postID != null)
        {
            db.Dishes.Remove(dish);
            db.SaveChanges();
        }
        return RedirectToAction("Index");
    }

    [HttpGet("dish/{postID}/edit")]
    public IActionResult EditDish(int postID)
    {
        Dish? dish = db.Dishes.FirstOrDefault(dish => dish.PostID == postID);

        if(dish == null)
        {
            return RedirectToAction("Index");
        }
        return View("Edit", dish);
    }

    [HttpPost("dish/{postID}/edit")]
    public IActionResult UpdateDish(int postID, Dish updatedDish)
    {
        if(!ModelState.IsValid)
        {
            // Dish? originalDish = db.Dishes.FirstOrDefault(dish => dish.PostID == postID);
            // return View("Edit", originalDish);
            //this bottom line does the job of the top two, referring to edit Dish
            return EditDish(postID);
        }
        Dish? dbDish = db.Dishes.FirstOrDefault(dish => dish.PostID == postID);

        if (dbDish == null)
        {
            return RedirectToAction("Index");
        }

        dbDish.Name = updatedDish.Name;
        dbDish.Chef = updatedDish.Chef;
        dbDish.Tastiness = updatedDish.Tastiness;
        dbDish.Calories = updatedDish.Calories;
        dbDish.Description = updatedDish.Description;
        dbDish.UpdatedAT = DateTime.Now;

        db.Dishes.Update(dbDish);
        db.SaveChanges();
        return RedirectToAction("ViewDish", new { id= dbDish.PostID });
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
