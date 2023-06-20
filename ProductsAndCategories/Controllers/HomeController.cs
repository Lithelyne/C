using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAndCategories.Models;

namespace ProductsAndCategories.Controllers;

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
    List<Product> allProducts = db.Products.ToList();
    return View("Index", allProducts);
  }

  // Create
  [HttpPost("products/create")]
  public IActionResult CreateProduct(Product product)
  {
    if (!ModelState.IsValid)
    {
      List<Product> allProducts = db.Products.ToList();
      return View("Index", allProducts);
    }
    db.Products.Add(product);
    db.SaveChanges();
    return RedirectToAction("Index");
  }

  // Read
  [HttpGet("products/{ProductId}")]
  public IActionResult ShowProduct(int ProductId)
  {
    Product? product = db.Products
        .Include(product => product.AllAssociations)
        .ThenInclude(association => association.Category)
        .FirstOrDefault(first => first.ProductId == ProductId);
    if (product == null)
    {
      return RedirectToAction("Index");
    }
    List<Category> availableCategories = db.Categories.ToList();
    ViewData["AvailableCategories"] = availableCategories;
    return View("ViewProduct", product);
  }

  [HttpPost("/products/addcategory")]
  public IActionResult AddCategoryToProduct(int ProductId, int CategoryId)
  {
    Product? product = db.Products
      .Include(product => product.AllAssociations)
      .FirstOrDefault(product => product.ProductId == ProductId);
    if (product == null)
    {
      return RedirectToAction("Index");
    }
    Category? category = db.Categories.FirstOrDefault(c => c.CategoryId == CategoryId);
    if (category == null)
    {
      return RedirectToAction("Index");
    }
    if (product.AllAssociations.Any(association => association.CategoryId == CategoryId))
    {
      return RedirectToAction("ShowProduct", new { ProductId = ProductId });
    }
    Association newAssociation = new Association
    {
      Product = product,
      Category = category
    };
    db.Associations.Add(newAssociation);
    db.SaveChanges();
    return RedirectToAction("ShowProduct", new { ProductId = ProductId });
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